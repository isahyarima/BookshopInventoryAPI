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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext context;
        public SupplierRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Supplier> CreateSupplierAsync(SupplierVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Supplier
            {
                SupplierId = model.supplierId,
                SupplierName = model.supplierName,
                Address = model.address,
                PhoneNumber = model.phoneNumber,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                IsActive = model.isActive,
                EmailAddress = model.emailAddress,
            };

            var persistance = context.Supplier.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Supplier();
        }

        public async Task<bool> DeleteSupplier(int supplierId)
        {
            var exist = await context.Supplier.FindAsync(supplierId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Supplier.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<SupplierVM> GetSupplier(int supplierId, int tenantId)
        {
            return await (from x in context.Supplier
                          where x.SupplierId == supplierId
                                && x.TenantId == tenantId
                          select new SupplierVM
                          {
                              supplierId = x.SupplierId,
                              supplierName = x.SupplierName,
                              address = x.Address,
                              phoneNumber = x.PhoneNumber,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              isActive = x.IsActive,
                              emailAddress = x.EmailAddress,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SupplierVM>> GetSupplier(int tenantId)
        {
            return await (from x in context.Supplier
                          where x.TenantId == tenantId
                         // && x.SupplierId == supplierId
                          select new SupplierVM
                          {
                              supplierId = x.SupplierId,
                              supplierName = x.SupplierName,
                              address = x.Address,
                              phoneNumber = x.PhoneNumber,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              isActive = x.IsActive,
                              emailAddress = x.EmailAddress,

                          }).OrderBy(o => o.supplierId).ToListAsync();
        }

        public async Task<IEnumerable<SupplierVM>> GetSupplierById(int supplierId, int tenantId)
        {
            return await (from x in context.Supplier
                          where x.TenantId == tenantId
                          select new SupplierVM
                          {
                              supplierId = x.SupplierId,
                              supplierName = x.SupplierName,
                              address = x.Address,
                              phoneNumber = x.PhoneNumber,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              isActive = x.IsActive,
                              emailAddress = x.EmailAddress,

                          }).OrderBy(o => o.supplierId).ToListAsync();
        }

        public async Task<bool> UpdateSupplier(int supplierId, SupplierVM model)
        {
            var record = await context.Supplier.FindAsync(supplierId);

            if (record == null) throw new Exception("No Record Found!");

            record.SupplierName = model.supplierName;
            record.Address = model.address;
            record.PhoneNumber = model.phoneNumber;
            record.DateRegistered = DateTime.Now;
            record.IsActive = model.isActive;
            record.EmailAddress = model.emailAddress;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






