using Authentication.ViewModel;
using DataModel.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Provider
{
   public class SecurityManager : ISecurityManager
    {
        private DataContext context;

        public SecurityManager(DataContext _context)
        {
            context = _context;
        }

        public UserLoginVm FindByUsername(string Username)
        {
            return (from u in context.LoginActivity
                    where u.UserName.ToLower() == Username.ToLower()
                    select
                    new UserLoginVm { UserName = u.UserName }).FirstOrDefault();
        }

        public AppUserAuth ValidateUser(string UserName, string Password)
        {
            AppUserAuth response = new AppUserAuth();
            LoginActivity authUser = null;
            var result = false;

            // Attempt to validate user
            authUser = (from u in context.LoginActivity
                        where u.UserName.ToLower() == UserName.ToLower() && u.IsDeleted == false && u.IsActive == true
                        select (u)).FirstOrDefault();

            if (authUser != null)
            {
                result = VerifyPasswordHash(Password, authUser.PasswordHash, authUser.PasswordSalt);
                if (result == false) return response;

                response.IsAuthenticated = true;
                response.UserName = authUser.UserName;
                response.userId = authUser.LoginActivityId;
                // response.Email = authUser.EmailAddress;
                response.RoleId = authUser.RoleId;
                //response.PhoneNumber = authUser.PhoneNumber;
            }

            return response;
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        public async Task<bool> Logout(string userName)
        {
            var user = await context.LoginActivity.Where(x => x.UserName == userName.ToLower()).FirstOrDefaultAsync();
            if (user != null)
            {
                // user.IsLogout = true;
                user.LastLoginDate = DateTime.Now;
            }
            if (await context.SaveChangesAsync() > 0)
                return true;

            return false;

        }

        public string GenerateAuthToken(string username, string secret)
        {
            var user = (from u in context.LoginActivity
                        where u.UserName.ToLower() == username
                        select (u)).FirstOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new Claim("email", user.EmailAddress),
                    //new Claim("username", user.EmailAddress),
                    //new Claim("userId", user.AdminUserId.ToString()),
                    //new Claim("PhoneNumber", user.PhoneNumber),
                }),

                Expires = DateTime.UtcNow.AddDays(15), // Short timeframe to test with
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            "the server key used to sign the JWT token is here, use more than 16 chars")),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (!(securityToken is JwtSecurityToken jwtSecurityToken) ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public Token GetRefreshTokenByToken(string name, string token)
        {
            return context.Token.FirstOrDefault(o => o.Name == name && o.Value == token);
        }

        public void AddRefreshToken(int userId, string name, string token, string username)
        {
            var model = new Token
            {
                UserId = userId,
                Name = name,
                Value = token,
                CreatedDate = DateTime.UtcNow,
                UserName = username
            };
            context.Token.Add(model);
            context.SaveChanges();
        }

        public void RemoveRefreshTokenByUser(int userId, string name)
        {
            var refreshToken = context.Token.FirstOrDefault(o => o.UserId == userId);
            if (refreshToken != null)
            {
                context.Token.Remove(refreshToken);
                context.SaveChanges();
            }
        }

        public void RemoveRefreshToken(string name, string token)
        {
            var refreshToken = context.Token.FirstOrDefault(o => o.Name == name && o.Value == token);
            if (refreshToken != null)
            {
                context.Token.Remove(refreshToken);
                context.SaveChanges();
            }
        }

        public AppUserAuth AddToken(int adminUserId, string token)
        {
            var time = 20;// ConfigurationManager.AppSettings["TokenExpirationTime"];
            var tokenExpirationTime = 0;
            if (time != null)
            {
                tokenExpirationTime = Convert.ToInt32(time);
            }

            AppUserAuth rep = new AppUserAuth();

            var user = context.LoginActivity.Where(x => x.LoginActivityId == adminUserId).FirstOrDefault();
            if (user != null)
            {
                // user.Token = token;
                // user.TokenExpiration = DateTime.Now.AddMinutes(tokenExpirationTime);
            }

            if (context.SaveChanges() > 0)
            {
                rep.IsAuthenticated = true;
                // rep.Email = user.EmailAddress;
                rep.userId = user.LoginActivityId;
                return rep;
            };
            return new AppUserAuth();
        }

        public async Task<bool> PasswordRet(UserLoginVm model)
        {
            var result = context.LoginActivity.Where(x => x.UserName == model.userName).Select(x => x).FirstOrDefault();

            if (result == null)
                throw new Exception("User does not exist!");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(model.password, out passwordHash, out passwordSalt);

            result.PasswordHash = passwordHash;
            result.PasswordSalt = passwordSalt;
            result.IsActive = true;
            result.IsPasswordReset = false;

            return context.SaveChanges() > 0;

        }

        public AppUserAuth ValidateToken(string userName, string token)
        {
            AppUserAuth app = new AppUserAuth();

            var user = context.LoginActivity.Where(x => x.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                //if (user.Token == token)
                //{
                //    if (user.TokenExpiration >= DateTime.Now)
                //    {
                //        app.Email = user.EmailAddress;
                //        app.IsAuthenticated = true;
                //        app.userId = user.LoginActivityId;
                //        app.RoleId = user.RoleId;
                //        app.Ts = user.StateId;
                //        app.Tc = user.CenterId;
                //        app.PhoneNumber = user.PhoneNumber;
                //        app.Name = user.FirstName;
                //        return app;

                //    }
                //    else
                //        throw new Exception("Token has expired, Kindly login try again");
                //}
                //else
                //    throw new Exception("Invalid Token");

            }
            return new AppUserAuth();

        }
        public List<string> GetUserActivites(int roleId)
        {
            List<string> activities = new List<string>();
            activities = context.ActivitiesAssigned.Where(o => o.RoleId == roleId)
                .Select(o => context.Activity.Where(x => x.ActivityId == o.ActivityId).Select(x => x.ActivityName).FirstOrDefault()).ToList();

            return activities;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        Token ISecurityManager.GetRefreshTokenByToken(string name, string token)
        {
            throw new NotImplementedException();
        }
    }
}
