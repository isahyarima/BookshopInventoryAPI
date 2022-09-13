using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;


namespace Interface
{
    public interface IBookItemRepository
    {
        Task<Book> CreateBookAsync(BookVM model);

        Task<BookVM> GetBook(int bookId, int tenantId);

        Task<IEnumerable<BookVM>> GetBook(int tenantId);

		 Task<IEnumerable<BookVM>> GetBookById(int bookId,int tenantId);

        Task<bool> UpdateBook(int bookId, BookVM model);

        Task<bool> DeleteBook(int bookId);
    }
}



     
