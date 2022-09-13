using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAuthorAsync(AuthorVM model);

        Task<AuthorVM> GetAuthor(int authorId, int tenantId);

        Task<IEnumerable<AuthorVM>> GetAuthor(int tenantId);

		 Task<IEnumerable<AuthorVM>> GetAuthorById(int authorId,int tenantId);

        Task<bool> UpdateAuthor(int authorId, AuthorVM model);

        Task<bool> DeleteAuthor(int authorId);
    }
}



     
