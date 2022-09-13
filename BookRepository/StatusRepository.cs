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
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext context;
        public StatusRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Status> CreateStatusAsync(StatusVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Status
            {
                StatusId = model.statusId,
                ModuleName = model.moduleName,
                StatusName = model.statusName,
            };

            var persistance = context.Status.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Status();
        }

        public async Task<bool> DeleteStatus(int statusId)
        {
            var exist = await context.Status.FindAsync(statusId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Status.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<StatusVM> GetStatus(int statusId, int tenantId)
        {
            return await (from x in context.Status
                          where x.StatusId == statusId
                                && x.TenantId == tenantId
                          select new StatusVM
                          {
                              statusId = x.StatusId,
                              moduleName = x.ModuleName,
                              statusName = x.StatusName,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StatusVM>> GetStatus(int tenantId)
        {
            return await (from x in context.Status
                          where x.TenantId == tenantId
                        //  && x.StatusId == statusId
                          select new StatusVM
                          {
                              statusId = x.StatusId,
                              moduleName = x.ModuleName,
                              statusName = x.StatusName,

                          }).OrderBy(o => o.statusId).ToListAsync();
        }

        public async Task<IEnumerable<StatusVM>> GetStatusById(int statusId, int tenantId)
        {
            return await (from x in context.Status
                          where x.TenantId == tenantId
                          select new StatusVM
                          {
                              statusId = x.StatusId,
                              moduleName = x.ModuleName,
                              statusName = x.StatusName,

                          }).OrderBy(o => o.statusId).ToListAsync();
        }

        public async Task<bool> UpdateStatus(int statusId, StatusVM model)
        {
            var record = await context.Status.FindAsync(statusId);

            if (record == null) throw new Exception("No Record Found!");

            record.StatusId = model.statusId;
            record.ModuleName = model.moduleName;
            record.StatusName = model.statusName;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






