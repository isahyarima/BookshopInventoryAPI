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
    public class PurchaseReceiptRegisterDetailRepository : IPurchaseReceiptRegisterDetailRepository
    {
        private readonly DataContext context;
        public PurchaseReceiptRegisterDetailRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<PurchaseReceiptRegisterDetail> CreatePurchaseReceiptRegisterDetailAsync(PurchaseReceiptRegisterDetailVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new PurchaseReceiptRegisterDetail
            {
                PurchaseReceiptRegisterDetailId = model.purchaseReceiptRegisterDetailId,
                PurchaseReceiptRegisterId = model.purchaseReceiptRegisterId,
                BookId = model.bookId,
                ParkSize = model.parkSize,
                LotNumber = model.lotNumber,
                Quantity = model.quantity,
                PurchaseRate = model.purchaseRate,
                SaleRate = model.saleRate,
                SupplyStatusId = model.supplyStatusId,
                StoreId = model.storeId,
                MinQuantityToAlert = model.minQuantityToAlert,
                TenantId = model.tenantId,
                DateRegistered = DateTime.Now,
                IsAvailable = model.isAvailable,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.PurchaseReceiptRegisterDetail.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new PurchaseReceiptRegisterDetail();
        }

        public async Task<bool> DeletePurchaseReceiptRegisterDetail(int purchaseReceiptRegisterDetailId)
        {
            var exist = await context.PurchaseReceiptRegisterDetail.FindAsync(purchaseReceiptRegisterDetailId);

            if (exist == null) throw new Exception("No Record Found!");

            context.PurchaseReceiptRegisterDetail.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<PurchaseReceiptRegisterDetailVM> GetPurchaseReceiptRegisterDetail(int purchaseReceiptRegisterDetailId, int tenantId)
        {
            return await (from x in context.PurchaseReceiptRegisterDetail
                          where x.PurchaseReceiptRegisterDetailId == purchaseReceiptRegisterDetailId
                                && x.TenantId == tenantId
                          select new PurchaseReceiptRegisterDetailVM
                          {
                              purchaseReceiptRegisterDetailId = x.PurchaseReceiptRegisterDetailId,
                              purchaseReceiptRegisterId = x.PurchaseReceiptRegisterId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              purchaseRate = x.PurchaseRate,
                              saleRate = x.SaleRate,
                              supplyStatusId = x.SupplyStatusId,
                              storeId = x.StoreId,
                              minQuantityToAlert = x.MinQuantityToAlert,
                              tenantId = x.TenantId,
                              dateRegistered = x.DateRegistered,
                              isAvailable = x.IsAvailable,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),
                              bookTitle = context.Book.Where(o => o.BookId == x.BookId).Select(o => o.BookTitle).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PurchaseReceiptRegisterDetailVM>> GetPurchaseReceiptRegisterDetail(int tenantId)
        {
            return await (from x in context.PurchaseReceiptRegisterDetail
                          where x.TenantId == tenantId
                          // && x.PurchaseReceiptRegisterDetailId == purchaseReceiptRegisterDetailId
                          select new PurchaseReceiptRegisterDetailVM
                          {
                              purchaseReceiptRegisterDetailId = x.PurchaseReceiptRegisterDetailId,
                              purchaseReceiptRegisterId = x.PurchaseReceiptRegisterId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              purchaseRate = x.PurchaseRate,
                              saleRate = x.SaleRate,
                              supplyStatusId = x.SupplyStatusId,
                              storeId = x.StoreId,
                              minQuantityToAlert = x.MinQuantityToAlert,
                              tenantId = x.TenantId,
                              dateRegistered = x.DateRegistered,
                              isAvailable = x.IsAvailable,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),
                              bookTitle = context.Book.Where(o => o.BookId == x.BookId).Select(o => o.BookTitle).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseReceiptRegisterDetailId).ToListAsync();
        }

        public async Task<IEnumerable<PurchaseReceiptRegisterDetailVM>> GetPurchaseReceiptRegisterDetailById(int purchaseReceiptRegisterDetailId, int tenantId)
        {
            return await (from x in context.PurchaseReceiptRegisterDetail
                          where x.TenantId == tenantId
                          select new PurchaseReceiptRegisterDetailVM
                          {
                              purchaseReceiptRegisterDetailId = x.PurchaseReceiptRegisterDetailId,
                              purchaseReceiptRegisterId = x.PurchaseReceiptRegisterId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              purchaseRate = x.PurchaseRate,
                              saleRate = x.SaleRate,
                              supplyStatusId = x.SupplyStatusId,
                              storeId = x.StoreId,
                              minQuantityToAlert = x.MinQuantityToAlert,
                              tenantId = x.TenantId,
                              dateRegistered = x.DateRegistered,
                              isAvailable = x.IsAvailable,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),
                              bookTitle = context.Book.Where(o => o.BookId == x.BookId).Select(o => o.BookTitle).FirstOrDefault(),


                          }).OrderBy(o => o.purchaseReceiptRegisterDetailId).ToListAsync();
        }

        public async Task<bool> UpdatePurchaseReceiptRegisterDetail(int purchaseReceiptRegisterDetailId, PurchaseReceiptRegisterDetailVM model)
        {
            var record = await context.PurchaseReceiptRegisterDetail.FindAsync(purchaseReceiptRegisterDetailId);

            if (record == null) throw new Exception("No Record Found!");

         
            
            record.BookId = model.bookId;
            record.ParkSize = model.parkSize;
            record.LotNumber = model.lotNumber;
            record.Quantity = model.quantity;
            record.PurchaseRate = model.purchaseRate;
            record.SaleRate = model.saleRate;
            record.SupplyStatusId = model.supplyStatusId;
            record.StoreId = model.storeId;
            record.MinQuantityToAlert = model.minQuantityToAlert;
            record.TenantId = model.tenantId;
            record.DateRegistered = DateTime.Now;
            record.IsAvailable = model.isAvailable;
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






