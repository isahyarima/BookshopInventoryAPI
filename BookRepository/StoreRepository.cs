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
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext context;
        public StoreRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Store> CreateStoreAsync(StoreVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Store
            {
                StoreId = model.storeId,
                StoreName = model.storeName,
                StoreNumber = model.storeNumber,
                StoreAddress = model.storeAddress,
                ContactNumber = model.contactNumber,
                TenantId = model.tenantId,
                IsActive = model.isActive,
            };

            var persistance = context.Store.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Store();
        }

        public async Task<bool> DeleteStore(int storeId)
        {
            var exist = await context.Store.FindAsync(storeId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Store.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<StoreVM> GetStore(int storeId, int tenantId)
        {
            return await (from x in context.Store
                          where x.StoreId == storeId
                                && x.TenantId == tenantId
                          select new StoreVM
                          {
                              storeId = x.StoreId,
                              storeName = x.StoreName,
                              storeNumber = x.StoreNumber,
                              storeAddress = x.StoreAddress,
                              contactNumber = x.ContactNumber,
                              tenantId = x.TenantId,
                              isActive = x.IsActive,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StoreVM>> GetStore(int tenantId)
        {
            return await (from x in context.Store
                          where x.TenantId == tenantId
                         // && x.StoreId == storeId
                          select new StoreVM
                          {
                              storeId = x.StoreId,
                              storeName = x.StoreName,
                              storeNumber = x.StoreNumber,
                              storeAddress = x.StoreAddress,
                              contactNumber = x.ContactNumber,
                              tenantId = x.TenantId,
                              isActive = x.IsActive,

                          }).OrderBy(o => o.storeId).ToListAsync();
        }

        public async Task<IEnumerable<StoreVM>> GetStoreById(int storeId, int tenantId)
        {
            return await (from x in context.Store
                          where x.TenantId == tenantId
                          select new StoreVM
                          {
                              storeId = x.StoreId,
                              storeName = x.StoreName,
                              storeNumber = x.StoreNumber,
                              storeAddress = x.StoreAddress,
                              contactNumber = x.ContactNumber,
                              tenantId = x.TenantId,
                              isActive = x.IsActive,

                          }).OrderBy(o => o.storeId).ToListAsync();
        }

        public async Task<bool> UpdateStore(int storeId, StoreVM model)
        {
            var record = await context.Store.FindAsync(storeId);

            if (record == null) throw new Exception("No Record Found!");

            record.StoreName = model.storeName;
            record.StoreNumber = model.storeNumber;
            record.StoreAddress = model.storeAddress;
            record.ContactNumber = model.contactNumber;
            record.IsActive = model.isActive;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






