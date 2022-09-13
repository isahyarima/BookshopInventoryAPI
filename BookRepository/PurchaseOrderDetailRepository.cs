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
    public class PurchaseOrderDetailRepository : IPurchaseOrderDetailRepository
    {
        private readonly DataContext context;
        public PurchaseOrderDetailRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<PurchaseOrderDetail> CreatePurchaseOrderDetailAsync(PurchaseOrderDetailVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new PurchaseOrderDetail
            {
                PurchaseOrderDetailId = model.purchaseOrderDetailId,
                PurchaseOrderId = model.purchaseOrderId,
                BookId = model.bookId,
                ParkSize = model.parkSize,
                LotNumber = model.lotNumber,
                Quantity = model.quantity,
                CostPrice = model.costPrice,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.PurchaseOrderDetail.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new PurchaseOrderDetail();
        }

        public async Task<bool> DeletePurchaseOrderDetail(int purchaseOrderDetailId)
        {
            var exist = await context.PurchaseOrderDetail.FindAsync(purchaseOrderDetailId);

            if (exist == null) throw new Exception("No Record Found!");

            context.PurchaseOrderDetail.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        

        public async Task<IEnumerable<PurchaseOrderDetailVM>> GetPurchaseOrderDetail(int tenantId, int purchaseOrderId)
        {
            return await (from x in context.PurchaseOrderDetail
                          where x.TenantId == tenantId
                          && x.PurchaseOrderId == purchaseOrderId
                          select new PurchaseOrderDetailVM
                          {
                              purchaseOrderDetailId = x.PurchaseOrderDetailId,
                              purchaseOrderId = x.PurchaseOrderId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              costPrice = x.CostPrice,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o=>o.StatusId == x.StatusId).Select(o=>o.StatusName).FirstOrDefault(),
                              bookTitle = context.Book.Where(o => o.BookId == x.BookId).Select(o => o.BookTitle).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseOrderDetailId).ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrderDetailVM>> GetPurchaseOrderDetailById(int purchaseOrderDetailId, int tenantId)
        {
            return await (from x in context.PurchaseOrderDetail
                          where x.TenantId == tenantId
                          select new PurchaseOrderDetailVM
                          {
                              purchaseOrderDetailId = x.PurchaseOrderDetailId,
                              purchaseOrderId = x.PurchaseOrderId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              costPrice = x.CostPrice,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),
                              bookTitle = context.Book.Where(o => o.BookId == x.BookId).Select(o => o.BookTitle).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseOrderDetailId).ToListAsync();
        }

        public async Task<bool> UpdatePurchaseOrderDetail(int purchaseOrderDetailId, PurchaseOrderDetailVM model)
        {
            var record = await context.PurchaseOrderDetail.FindAsync(purchaseOrderDetailId);

            if (record == null) throw new Exception("No Record Found!");

            record.PurchaseOrderId = model.purchaseOrderId;
            record.BookId = model.bookId;
            record.ParkSize = model.parkSize;
            record.LotNumber = model.lotNumber;
            record.Quantity = model.quantity;
            record.CostPrice = model.costPrice;
            record.DateRegistered = DateTime.Now;
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






