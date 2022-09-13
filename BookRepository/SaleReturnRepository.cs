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
    public class SaleReturnRepository : ISaleReturnRepository
    {
        private readonly DataContext context;
        public SaleReturnRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<SaleReturn> CreateSaleReturnAsync(SaleReturnVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new SaleReturn
            {
                SaleReturnId = model.saleReturnId,
                CustomerId = model.customerId,
                TaxId = model.taxId,
                ReturnNumber = model.returnNumber,
                ReturnDate = model.returnDate,
                PaymentId = model.paymentId,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.SaleReturn.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new SaleReturn();
        }

        public async Task<bool> DeleteSaleReturn(int saleReturnId)
        {
            var exist = await context.SaleReturn.FindAsync(saleReturnId);

            if (exist == null) throw new Exception("No Record Found!");

            context.SaleReturn.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<SaleReturnVM> GetSaleReturn(int saleReturnId, int tenantId)
        {
            return await (from x in context.SaleReturn
                          where x.SaleReturnId == saleReturnId
                                && x.TenantId == tenantId
                          select new SaleReturnVM
                          {
                              saleReturnId = x.SaleReturnId,
                              customerId = x.CustomerId,
                              taxId = x.TaxId,
                              returnNumber = x.ReturnNumber,
                              returnDate = x.ReturnDate,
                              paymentId = x.PaymentId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SaleReturnVM>> GetSaleReturn(int tenantId)
        {
            return await (from x in context.SaleReturn
                          where x.TenantId == tenantId
                       //   && x.SaleReturnId == saleReturnId
                          select new SaleReturnVM
                          {
                              saleReturnId = x.SaleReturnId,
                              customerId = x.CustomerId,
                              taxId = x.TaxId,
                              returnNumber = x.ReturnNumber,
                              returnDate = x.ReturnDate,
                              paymentId = x.PaymentId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleReturnId).ToListAsync();
        }

        public async Task<IEnumerable<SaleReturnVM>> GetSaleReturnById(int saleReturnId, int tenantId)
        {
            return await (from x in context.SaleReturn
                          where x.TenantId == tenantId
                          select new SaleReturnVM
                          {
                              saleReturnId = x.SaleReturnId,
                              customerId = x.CustomerId,
                              taxId = x.TaxId,
                              returnNumber = x.ReturnNumber,
                              returnDate = x.ReturnDate,
                              paymentId = x.PaymentId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleReturnId).ToListAsync();
        }

        public async Task<bool> UpdateSaleReturn(int saleReturnId, SaleReturnVM model)
        {
            var record = await context.SaleReturn.FindAsync(saleReturnId);

            if (record == null) throw new Exception("No Record Found!");

            record.CustomerId = model.customerId;
            record.TaxId = model.taxId;
            record.ReturnNumber = model.returnNumber;
            record.ReturnDate = model.returnDate;
            record.PaymentId = model.paymentId;
            record.DateRegistered = DateTime.Now;
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






