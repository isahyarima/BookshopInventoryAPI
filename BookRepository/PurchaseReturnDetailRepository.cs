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
    public class PurchaseReturnDetailRepository : IPurchaseReturnDetailRepository
    {
        private readonly DataContext context;
        public PurchaseReturnDetailRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<PurchaseReturnDetail> CreatePurchaseReturnDetailAsync(PurchaseReturnDetailVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new PurchaseReturnDetail
            {
                PurchaseReturnDetailId = model.purchaseReturnDetailId,
                PurchaseReturnId = model.purchaseReturnId,
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

            var persistance = context.PurchaseReturnDetail.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new PurchaseReturnDetail();
        }

        public async Task<bool> DeletePurchaseReturnDetail(int purchaseReturnDetailId)
        {
            var exist = await context.PurchaseReturnDetail.FindAsync(purchaseReturnDetailId);

            if (exist == null) throw new Exception("No Record Found!");

            context.PurchaseReturnDetail.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<PurchaseReturnDetailVM> GetPurchaseReturnDetail(int purchaseReturnDetailId, int tenantId)
        {
            return await (from x in context.PurchaseReturnDetail
                          where x.PurchaseReturnDetailId == purchaseReturnDetailId
                                && x.TenantId == tenantId
                          select new PurchaseReturnDetailVM
                          {
                              purchaseReturnDetailId = x.PurchaseReturnDetailId,
                              purchaseReturnId = x.PurchaseReturnId,
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

        public async Task<IEnumerable<PurchaseReturnDetailVM>> GetPurchaseReturnDetail(int tenantId)
        {
            return await (from x in context.PurchaseReturnDetail
                          where x.TenantId == tenantId
                        //  && x.PurchaseReturnDetailId == purchaseReturnDetailId
                          select new PurchaseReturnDetailVM
                          {
                              purchaseReturnDetailId = x.PurchaseReturnDetailId,
                              purchaseReturnId = x.PurchaseReturnId,
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


                          }).OrderBy(o => o.purchaseReturnDetailId).ToListAsync();
        }

        public async Task<IEnumerable<PurchaseReturnDetailVM>> GetPurchaseReturnDetailById(int purchaseReturnDetailId, int tenantId)
        {
            return await (from x in context.PurchaseReturnDetail
                          where x.TenantId == tenantId
                          select new PurchaseReturnDetailVM
                          {
                              purchaseReturnDetailId = x.PurchaseReturnDetailId,
                              purchaseReturnId = x.PurchaseReturnId,
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


                          }).OrderBy(o => o.purchaseReturnDetailId).ToListAsync();
        }

        public async Task<bool> UpdatePurchaseReturnDetail(int purchaseReturnDetailId, PurchaseReturnDetailVM model)
        {
            var record = await context.PurchaseReturnDetail.FindAsync(purchaseReturnDetailId);

            if (record == null) throw new Exception("No Record Found!");

            record.PurchaseReturnDetailId = model.purchaseReturnDetailId;
            record.PurchaseReturnId = model.purchaseReturnId;
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






