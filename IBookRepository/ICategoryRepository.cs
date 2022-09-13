using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(CategoryVM model);

        Task<CategoryVM> GetCategory(int categoryId, int tenantId);

        Task<IEnumerable<CategoryVM>> GetCategory(int tenantId);

		 Task<IEnumerable<CategoryVM>> GetCategoryById(int categoryId,int tenantId);

        Task<bool> UpdateCategory(int categoryId, CategoryVM model);

        Task<bool> DeleteCategory(int categoryId);
    }
}



     
