using Data.TransferObject.ViewModel;
using DataModel.Models;
using Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly DataContext context;
        public TokenRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Token> CreateTokenAsync(TokenVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Token
            {
                TokenId = model.tokenId,
                Name = model.name,
                Email = model.email,
                Value = model.value,
                CreatedDate = model.createdDate,
                UserId = model.userId,
                LastModifiedDate = model.lastModifiedDate,
                ExpiryTime = model.expiryTime,
                UserName = model.userName,
                TenantId = model.tenantId,
            };

            var persistance = context.Token.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Token();
        }

        public async Task<bool> DeleteToken(int tokenId)
        {
            var exist = await context.Token.FindAsync(tokenId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Token.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<TokenVM> GetToken(int tokenId, int tenantId)
        {
            return await (from x in context.Token
                          where x.TokenId == tokenId
                                && x.TenantId == tenantId
                          select new TokenVM
                          {
                              tokenId = x.TokenId,
                              name = x.Name,
                              email = x.Email,
                              value = x.Value,
                              createdDate = x.CreatedDate,
                              userId = x.UserId,
                              lastModifiedDate = x.LastModifiedDate,
                              expiryTime = x.ExpiryTime,
                              userName = x.UserName,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TokenVM>> GetToken(int tenantId)
        {
            return await (from x in context.Token
                          where x.TenantId == tenantId
                          //&& x.TokenId == tokenId
                          select new TokenVM
                          {
                              tokenId = x.TokenId,
                              name = x.Name,
                              email = x.Email,
                              value = x.Value,
                              createdDate = x.CreatedDate,
                              userId = x.UserId,
                              lastModifiedDate = x.LastModifiedDate,
                              expiryTime = x.ExpiryTime,
                              userName = x.UserName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.tokenId).ToListAsync();
        }

        public async Task<IEnumerable<TokenVM>> GetTokenById(int tokenId, int tenantId)
        {
            return await (from x in context.Token
                          where x.TenantId == tenantId
                          select new TokenVM
                          {
                              tokenId = x.TokenId,
                              name = x.Name,
                              email = x.Email,
                              value = x.Value,
                              createdDate = x.CreatedDate,
                              userId = x.UserId,
                              lastModifiedDate = x.LastModifiedDate,
                              expiryTime = x.ExpiryTime,
                              userName = x.UserName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.tokenId).ToListAsync();
        }

        public async Task<bool> UpdateToken(int tokenId, TokenVM model)
        {
            var record = await context.Token.FindAsync(tokenId);

            if (record == null) throw new Exception("No Record Found!");

            record.TokenId = model.tokenId;
            record.Name = model.name;
            record.Email = model.email;
            record.Value = model.value;
            record.CreatedDate = model.createdDate;
            record.UserId = model.userId;
            record.LastModifiedDate = model.lastModifiedDate;
            record.ExpiryTime = model.expiryTime;
            record.UserName = model.userName;
            record.TenantId = model.tenantId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






