using Data.TransferObject.ViewModel;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Models;
using System.Data.Entity;

namespace Repository
{
    public class SupplyStatusRepository : ISupplyStatusRepository
    {
        private readonly DataContext context;
        public SupplyStatusRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<SupplyStatus> CreateSupplyStatusAsync(SupplyStatusVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new SupplyStatus
            {
                SupplyStatusId = model.supplyStatusId,
                SupplyStatusName = model.supplyStatusName,
                TenantId = model.tenantId,
            };

            var persistance = context.SupplyStatus.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new SupplyStatus();
        }

        public async Task<bool> DeleteSupplyStatus(int supplyStatusId)
        {
            var exist = await context.SupplyStatus.FindAsync(supplyStatusId);

            if (exist == null) throw new Exception("No Record Found!");

            context.SupplyStatus.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<SupplyStatusVM> GetSupplyStatus(int supplyStatusId, int tenantId)
        {
            return await (from x in context.SupplyStatus
                          where x.SupplyStatusId == supplyStatusId
                                && x.TenantId == tenantId
                          select new SupplyStatusVM
                          {
                              supplyStatusId = x.SupplyStatusId,
                              supplyStatusName = x.SupplyStatusName,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SupplyStatusVM>> GetSupplyStatus(int tenantId)
        {
            return await (from x in context.SupplyStatus
                          where x.TenantId == tenantId
                         // && x.SupplyStatusId == supplyStatusId
                          select new SupplyStatusVM
                          {
                              supplyStatusId = x.SupplyStatusId,
                              supplyStatusName = x.SupplyStatusName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.supplyStatusId).ToListAsync();
        }

        public async Task<IEnumerable<SupplyStatusVM>> GetSupplyStatusById(int supplyStatusId, int tenantId)
        {
            return await (from x in context.SupplyStatus
                          where x.TenantId == tenantId
                          select new SupplyStatusVM
                          {
                              supplyStatusId = x.SupplyStatusId,
                              supplyStatusName = x.SupplyStatusName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.supplyStatusId).ToListAsync();
        }

        public async Task<bool> UpdateSupplyStatus(int supplyStatusId, SupplyStatusVM model)
        {
            var record = await context.SupplyStatus.FindAsync(supplyStatusId);

            if (record == null) throw new Exception("No Record Found!");

            record.SupplyStatusId = model.supplyStatusId;
            record.SupplyStatusName = model.supplyStatusName;
            record.TenantId = model.tenantId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






