using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ITokenRepository
    {
        Task<Token> CreateTokenAsync(TokenVM model);

        Task<TokenVM> GetToken(int tokenId, int tenantId);

        Task<IEnumerable<TokenVM>> GetToken(int tenantId);

		 Task<IEnumerable<TokenVM>> GetTokenById(int tokenId,int tenantId);

        Task<bool> UpdateToken(int tokenId, TokenVM model);

        Task<bool> DeleteToken(int tokenId);
    }
}



     
