using Data.TransferObject.ViewModel;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Models;
using System.Data.Entity;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;
        public CategoryRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Category> CreateCategoryAsync(CategoryVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Category
            {
                CategoryId = model.categoryId,
                CategoryName = model.categoryName,
                DateCreated = DateTime.Now,
                TenantId = model.tenantId,
            };

            var persistance = context.Category.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Category();
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var exist = await context.Category.FindAsync(categoryId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Category.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<CategoryVM> GetCategory(int categoryId, int tenantId)
        {
            return await (from x in context.Category
                          where x.CategoryId == categoryId
                                && x.TenantId == tenantId
                          select new CategoryVM
                          {
                              categoryId = x.CategoryId,
                              categoryName = x.CategoryName,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CategoryVM>> GetCategory(int tenantId)
        {
            return await (from x in context.Category
                          where x.TenantId == tenantId
                         // && x.CategoryId == categoryId
                          select new CategoryVM
                          {
                              categoryId = x.CategoryId,
                              categoryName = x.CategoryName,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.categoryId).ToListAsync();
        }

        public async Task<IEnumerable<CategoryVM>> GetCategoryById(int categoryId, int tenantId)
        {
            return await (from x in context.Category
                          where x.TenantId == tenantId
                          select new CategoryVM
                          {
                              categoryId = x.CategoryId,
                              categoryName = x.CategoryName,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.categoryId).ToListAsync();
        }

        public async Task<bool> UpdateCategory(int categoryId, CategoryVM model)
        {
            var record = await context.Category.FindAsync(categoryId);

            if (record == null) throw new Exception("No Record Found!");

            record.CategoryName = model.categoryName;
            record.DateCreated =DateTime.Now;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






