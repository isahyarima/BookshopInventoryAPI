using Authentication.ViewModel;
using BookInventory.API.App_Start;
using DataModel.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TokenBasedAuthentication.Providers
{
    public class OAuthCustomeTokenProvider : OAuthAuthorizationServerProvider
    {

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                return Task.Factory.StartNew(() =>
                {
                    var userName = context.UserName.Trim();
                    var password = context.Password.Trim();
                    var user = ValidateToken(userName, password);
                    var roles = "";

                    if (user.IsAuthenticated != false)
                    {
                        var claims = new List<Claim>()
                            {
                                new Claim(ClaimTypes.Sid, Convert.ToString(user.userId)),
                                new Claim(ClaimTypes.Name, user.UserName),
                                new Claim( "idu", user.userId.ToString() ),
                                new Claim( "name", user.UserName ),
                                new Claim( "roleId", user.RoleId.ToString()),
                                new Claim(  "idr", user.RoleId.ToString()),
                                new Claim( "racl", user.RoleLevelAccressId.ToString()),
                                new Claim("m1", user.FacultyId.ToString() ),
                                new Claim("m2", user.DepartmentId.ToString() ),
                                new Claim("m3", user.DepartmentUnitId.ToString() ),
                                new Claim("tenantId", user.TenantId.ToString() ),
                            };

                        var data = new Dictionary<string, string>
                        {
                         { "isAuthenticated", "true" },
                            { "idu", user.userId.ToString() },
                            {  "userName", user.UserName  },
                            {  "idr", user.RoleId.ToString() },
                            { "racl", user.RoleLevelAccressId.ToString() },
                            { "m1", user.FacultyId.ToString() },
                            { "m2", user.DepartmentId.ToString() },
                            { "m3", user.DepartmentUnitId.ToString() },
                            {"tenantId", user.TenantId.ToString()},
                            {"name", user.Name},
                           // {"design",user.Designation },
                            {"role",user.Role },
                        };

                        var properties = new AuthenticationProperties(data);

                        ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                            Startup.OAuthOptions.AuthenticationType);

                        var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                        context.Validated(ticket);
                    }
                    else
                    {
                        var claims = new List<Claim>()
                        {
                        };

                        var data = new Dictionary<string, string>
                        {
                         { "isAuthenticated", "false" },
                         { "message", user.ErrorMessage },
                        };

                        var properties = new AuthenticationProperties(data);

                        ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                            Startup.OAuthOptions.AuthenticationType);

                        var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                        context.Validated(ticket);

                    }

                });

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }


        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        public AppUserAuth ValidateToken(string userName, string pasword)
        {
            AppUserAuth response = new AppUserAuth();

            using (DataContext context = new DataContext())
            {
                var user = context.LoginActivity.Where(x => x.UserName == userName).FirstOrDefault();
                bool result = false;
                
                if (user != null)
                {
                    try
                    {
                        result = VerifyPasswordHash(pasword, user.PasswordHash, user.PasswordSalt);
                    }
                    catch (Exception ex)
                    {
                        response.IsAuthenticated = false;
                        response.ErrorMessage = ex.Message;
                        return response;
                    }
                }
                else
                {
                    response.IsAuthenticated = false;
                    response.ErrorMessage = "Username / Password is invalid";
                    return response;
                }
                
                if (result != false)
                {
                    var name = context.Employee.Where(x => x.EmployeeId == user.UserId).Select(x => x).FirstOrDefault();
                   // var Designation = context.HR_Designation.Where(x => x.DesignationId == name.DesignationId).Select(x => x.DesignationName).FirstOrDefault();
                    var UserRole = context.Role.Where(x => x.RoleId == user.RoleId).Select(x => x).FirstOrDefault();
                    var Role = UserRole.RoleName;

                    response.IsAuthenticated = true;
                    response.userId = user.UserId;
                    response.UserName = user.UserName;
                    response.RoleId = user.RoleId;
                    response.TenantId = user.TenantId;
                    response.Name = name.FirstName + " " + name.LastName;
                    response.Role = Role;
                    response.RoleLevelAccressId = UserRole.RoleLevelAccressId;

                    context.SaveChanges();

                    return response;

                }
                else
                {
                    response.IsAuthenticated = false;
                    response.ErrorMessage = "Username / Password is invalid";
                    return response;
                }

            }
            return new AppUserAuth();

        }

        private Token CreateRefreshToken(int userId, double tokenExpiryTime)
        {
            return new Token()
            {
                UserId = userId,
                Value = Guid.NewGuid().ToString("N"),
                CreatedDate = DateTime.UtcNow,
                ExpiryTime = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
            };
        }

        public List<string> GetUserActivites(int roleId)
        {
            using (DataContext context = new DataContext())
            {
                List<string> activities = new List<string>();
                activities = context.ActivitiesAssigned.Where(o => o.RoleId == roleId)
                    .Select(o => context.Activity.Where(x => x.ActivityId == o.ActivityId).Select(x => x.ActivityName).FirstOrDefault()).ToList();

                return activities;
            }

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
    }


}
