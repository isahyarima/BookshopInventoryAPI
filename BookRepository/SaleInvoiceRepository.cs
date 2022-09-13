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
    public class SaleInvoiceRepository : ISaleInvoiceRepository
    {
        private readonly DataContext context;
        public SaleInvoiceRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<SaleInvoice> CreateSaleInvoiceAsync(SaleInvoiceVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new SaleInvoice
            {
                SaleInvoiceId = model.saleInvoiceId,
                SupplierId = model.supplierId,
                TaxId = model.taxId,
                BillNumber = model.billNumber,
                BillDate = model.billDate,
                PaymentId = model.paymentId,
                Agent = model.agent,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.SaleInvoice.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new SaleInvoice();
        }

        public async Task<bool> DeleteSaleInvoice(int saleInvoiceId)
        {
            var exist = await context.SaleInvoice.FindAsync(saleInvoiceId);

            if (exist == null) throw new Exception("No Record Found!");

            context.SaleInvoice.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<SaleInvoiceVM> GetSaleInvoice(int saleInvoiceId, int tenantId)
        {
            return await (from x in context.SaleInvoice
                          where x.SaleInvoiceId == saleInvoiceId
                                && x.TenantId == tenantId
                          select new SaleInvoiceVM
                          {
                              saleInvoiceId = x.SaleInvoiceId,
                              supplierId = x.SupplierId,
                              taxId = x.TaxId,
                              billNumber = x.BillNumber,
                              billDate = x.BillDate,
                              paymentId = x.PaymentId,
                              agent = x.Agent,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SaleInvoiceVM>> GetSaleInvoice(int tenantId)
        {
            return await (from x in context.SaleInvoice
                          where x.TenantId == tenantId
                          //&& x.SaleInvoiceId == saleInvoiceId
                          select new SaleInvoiceVM
                          {
                              saleInvoiceId = x.SaleInvoiceId,
                              supplierId = x.SupplierId,
                              taxId = x.TaxId,
                              billNumber = x.BillNumber,
                              billDate = x.BillDate,
                              paymentId = x.PaymentId,
                              agent = x.Agent,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleInvoiceId).ToListAsync();
        }

        public async Task<IEnumerable<SaleInvoiceVM>> GetSaleInvoiceById(int saleInvoiceId, int tenantId)
        {
            return await (from x in context.SaleInvoice
                          where x.TenantId == tenantId
                          select new SaleInvoiceVM
                          {
                              saleInvoiceId = x.SaleInvoiceId,
                              supplierId = x.SupplierId,
                              taxId = x.TaxId,
                              billNumber = x.BillNumber,
                              billDate = x.BillDate,
                              paymentId = x.PaymentId,
                              agent = x.Agent,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleInvoiceId).ToListAsync();
        }

        public async Task<bool> UpdateSaleInvoice(int saleInvoiceId, SaleInvoiceVM model)
        {
            var record = await context.SaleInvoice.FindAsync(saleInvoiceId);

            if (record == null) throw new Exception("No Record Found!");

            record.SaleInvoiceId = model.saleInvoiceId;
            record.SupplierId = model.supplierId;
            record.TaxId = model.taxId;
            record.BillNumber = model.billNumber;
            record.BillDate = model.billDate;
            record.PaymentId = model.paymentId;
            record.Agent = model.agent;
            record.DateRegistered = DateTime.Now;
   
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






