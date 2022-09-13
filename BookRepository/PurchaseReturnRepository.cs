using Common.TableEnum;
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
    public class PurchaseReturnRepository : IPurchaseReturnRepository
    {
        private readonly DataContext context;
        public PurchaseReturnRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<PurchaseReturn> CreatePurchaseReturnAsync(PurchaseReturnVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new PurchaseReturn
            {
                PurchaseReturnId = model.purchaseReturnId,
                SupplierId = model.supplierId,
                TaxId = model.taxId,
                ReturnNumber = model.returnNumber,
                PurchaseOrderId = model.purchaseOrderId,
                ReturnDate = model.returnDate,
                PaymentId = model.paymentId,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.PurchaseReturn.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new PurchaseReturn();
        }

        public async Task<bool> DeletePurchaseReturn(int purchaseReturnId)
        {
            var exist = await context.PurchaseReturn.FindAsync(purchaseReturnId);

            if (exist == null) throw new Exception("No Record Found!");

            context.PurchaseReturn.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<PurchaseReturnVM> GetPurchaseReturn(int purchaseReturnId, int tenantId)
        {
            return await (from x in context.PurchaseReturn
                          where x.PurchaseReturnId == purchaseReturnId
                                && x.TenantId == tenantId
                          select new PurchaseReturnVM
                          {
                              purchaseReturnId = x.PurchaseReturnId,
                              supplierId = x.SupplierId,
                              taxId = x.TaxId,
                              returnNumber = x.ReturnNumber,
                              purchaseOrderId = x.PurchaseOrderId,
                              returnDate = x.ReturnDate,
                              paymentId = x.PaymentId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PurchaseReturnVM>> GetPurchaseReturn(int tenantId)
        {
            return await (from x in context.PurchaseReturn
                          where x.TenantId == tenantId
                         // && x.PurchaseReturnId == purchaseReturnId
                          select new PurchaseReturnVM
                          {
                              purchaseReturnId = x.PurchaseReturnId,
                              supplierId = x.SupplierId,
                              taxId = x.TaxId,
                              returnNumber = x.ReturnNumber,
                              purchaseOrderId = x.PurchaseOrderId,
                              returnDate = x.ReturnDate,
                              paymentId = x.PaymentId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseReturnId).ToListAsync();
        }

        public async Task<IEnumerable<PurchaseReturnVM>> GetPurchaseReturnById(int purchaseReturnId, int tenantId)
        {
            return await (from x in context.PurchaseReturn
                          where x.TenantId == tenantId
                          select new PurchaseReturnVM
                          {
                              purchaseReturnId = x.PurchaseReturnId,
                              supplierId = x.SupplierId,
                              taxId = x.TaxId,
                              returnNumber = x.ReturnNumber,
                              purchaseOrderId = x.PurchaseOrderId,
                              returnDate = x.ReturnDate,
                              paymentId = x.PaymentId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseReturnId).ToListAsync();
        }

        public async Task<bool> UpdatePurchaseReturn(int purchaseReturnId, PurchaseReturnVM model)
        {
            var record = await context.PurchaseReturn.FindAsync(purchaseReturnId);

            if (record == null) throw new Exception("No Record Found!");

   record.SupplierId = model.supplierId;
            record.TaxId = model.taxId;
            record.ReturnNumber = model.returnNumber;
            record.PurchaseOrderId = model.purchaseOrderId;
            record.ReturnDate = model.returnDate;
            record.PaymentId = model.paymentId;
            record.DateRegistered = DateTime.Now;
          
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






