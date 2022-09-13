using Data.TransferObject.ViewModel;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Models;
using System.Data.Entity;
using Common.TableEnum;

namespace Repository
{
    public class SaleInvoiceDetailRepository : ISaleInvoiceDetailRepository
    {
        private readonly DataContext context;
        public SaleInvoiceDetailRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<SaleInvoiceDetail> CreateSaleInvoiceDetailAsync(SaleInvoiceDetailVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new SaleInvoiceDetail
            {
                SaleInvoiceDetailId = model.saleInvoiceDetailId,
                SaleInvoiceId = model.saleInvoiceId,
                BookId = model.bookId,
                ParkSize = model.parkSize,
                LotNumber = model.lotNumber,
                Quantity = model.quantity,
                BasicRate = model.basicRate,
                PurchaseRate = model.purchaseRate,
                SaleRate = model.saleRate,
                MRP = model.mRP,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active

            };

            var persistance = context.SaleInvoiceDetail.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new SaleInvoiceDetail();
        }

        public async Task<bool> DeleteSaleInvoiceDetail(int saleInvoiceDetailId)
        {
            var exist = await context.SaleInvoiceDetail.FindAsync(saleInvoiceDetailId);

            if (exist == null) throw new Exception("No Record Found!");

            context.SaleInvoiceDetail.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<SaleInvoiceDetailVM> GetSaleInvoiceDetail(int saleInvoiceDetailId, int tenantId)
        {
            return await (from x in context.SaleInvoiceDetail
                          where x.SaleInvoiceDetailId == saleInvoiceDetailId
                                && x.TenantId == tenantId
                          select new SaleInvoiceDetailVM
                          {
                              saleInvoiceDetailId = x.SaleInvoiceDetailId,
                              saleInvoiceId = x.SaleInvoiceId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              basicRate = x.BasicRate,
                              purchaseRate = x.PurchaseRate,
                              saleRate = x.SaleRate,
                              mRP = x.MRP,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SaleInvoiceDetailVM>> GetSaleInvoiceDetail(int tenantId)
        {
            return await (from x in context.SaleInvoiceDetail
                          where x.TenantId == tenantId
                         // && x.SaleInvoiceDetailId == saleInvoiceDetailId
                          select new SaleInvoiceDetailVM
                          {
                              saleInvoiceDetailId = x.SaleInvoiceDetailId,
                              saleInvoiceId = x.SaleInvoiceId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              basicRate = x.BasicRate,
                              purchaseRate = x.PurchaseRate,
                              saleRate = x.SaleRate,
                              mRP = x.MRP,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleInvoiceDetailId).ToListAsync();
        }

        public async Task<IEnumerable<SaleInvoiceDetailVM>> GetSaleInvoiceDetailById(int saleInvoiceDetailId, int tenantId)
        {
            return await (from x in context.SaleInvoiceDetail
                          where x.TenantId == tenantId
                          select new SaleInvoiceDetailVM
                          {
                              saleInvoiceDetailId = x.SaleInvoiceDetailId,
                              saleInvoiceId = x.SaleInvoiceId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              basicRate = x.BasicRate,
                              purchaseRate = x.PurchaseRate,
                              saleRate = x.SaleRate,
                              mRP = x.MRP,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleInvoiceDetailId).ToListAsync();
        }

        public async Task<bool> UpdateSaleInvoiceDetail(int saleInvoiceDetailId, SaleInvoiceDetailVM model)
        {
            var record = await context.SaleInvoiceDetail.FindAsync(saleInvoiceDetailId);

            if (record == null) throw new Exception("No Record Found!");

      
            record.SaleInvoiceId = model.saleInvoiceId;
            record.BookId = model.bookId;
            record.ParkSize = model.parkSize;
            record.LotNumber = model.lotNumber;
            record.Quantity = model.quantity;
            record.BasicRate = model.basicRate;
            record.PurchaseRate = model.purchaseRate;
            record.SaleRate = model.saleRate;
            record.MRP = model.mRP;
            record.DateRegistered = DateTime.Now;
          
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






