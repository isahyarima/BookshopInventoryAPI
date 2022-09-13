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
    public class SaleReturnDetailRepository : ISaleReturnDetailRepository
    {
        private readonly DataContext context;
        public SaleReturnDetailRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<SaleReturnDetail> CreateSaleReturnDetailAsync(SaleReturnDetailVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new SaleReturnDetail
            {
                SaleReturnDetailId = model.saleReturnDetailId,
                SaleReturnId = model.saleReturnId,
                BookId = model.bookId,
                ParkSize = model.parkSize,
                LotNumber = model.lotNumber,
                Quantity = model.quantity,
                BasicRate = model.basicRate,
                SaleRate = model.saleRate,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                CreatedBy = model.createdBy,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.SaleReturnDetail.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new SaleReturnDetail();
        }

        public async Task<bool> DeleteSaleReturnDetail(int saleReturnDetailId)
        {
            var exist = await context.SaleReturnDetail.FindAsync(saleReturnDetailId);

            if (exist == null) throw new Exception("No Record Found!");

            context.SaleReturnDetail.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<SaleReturnDetailVM> GetSaleReturnDetail(int saleReturnDetailId, int tenantId)
        {
            return await (from x in context.SaleReturnDetail
                          where x.SaleReturnDetailId == saleReturnDetailId
                                && x.TenantId == tenantId
                          select new SaleReturnDetailVM
                          {
                              saleReturnDetailId = x.SaleReturnDetailId,
                              saleReturnId = x.SaleReturnId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              basicRate = x.BasicRate,
                              saleRate = x.SaleRate,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SaleReturnDetailVM>> GetSaleReturnDetail(int tenantId)
        {
            return await (from x in context.SaleReturnDetail
                          where x.TenantId == tenantId
                        //  && x.SaleReturnDetailId == saleReturnDetailId
                          select new SaleReturnDetailVM
                          {
                              saleReturnDetailId = x.SaleReturnDetailId,
                              saleReturnId = x.SaleReturnId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              basicRate = x.BasicRate,
                              saleRate = x.SaleRate,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleReturnDetailId).ToListAsync();
        }

        public async Task<IEnumerable<SaleReturnDetailVM>> GetSaleReturnDetailById(int saleReturnDetailId, int tenantId)
        {
            return await (from x in context.SaleReturnDetail
                          where x.TenantId == tenantId
                          select new SaleReturnDetailVM
                          {
                              saleReturnDetailId = x.SaleReturnDetailId,
                              saleReturnId = x.SaleReturnId,
                              bookId = x.BookId,
                              parkSize = x.ParkSize,
                              lotNumber = x.LotNumber,
                              quantity = x.Quantity,
                              basicRate = x.BasicRate,
                              saleRate = x.SaleRate,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createdBy = x.CreatedBy,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleReturnDetailId).ToListAsync();
        }

        public async Task<bool> UpdateSaleReturnDetail(int saleReturnDetailId, SaleReturnDetailVM model)
        {
            var record = await context.SaleReturnDetail.FindAsync(saleReturnDetailId);

            if (record == null) throw new Exception("No Record Found!");

           
            record.BookId = model.bookId;
            record.ParkSize = model.parkSize;
            record.LotNumber = model.lotNumber;
            record.Quantity = model.quantity;
            record.BasicRate = model.basicRate;
            record.SaleRate = model.saleRate;
            record.DateRegistered = DateTime.Now;
            record.CreatedBy = model.createdBy;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






