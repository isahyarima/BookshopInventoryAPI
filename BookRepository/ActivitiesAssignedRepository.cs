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
    public class ActivitiesAssignedRepository : IActivitiesAssignedRepository
    {
        private readonly DataContext context;
        public ActivitiesAssignedRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<ActivitiesAssigned> CreateActivitiesAssignedAsync(ActivitiesAssignedVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new ActivitiesAssigned
            {
                ActivitiesAssignedId = model.activitiesAssignedId,
                ActivityId = model.activityId,
                RoleId = model.roleId,
                DateTimeCreated = model.dateTimeCreated,
                TenantId = model.tenantId,
            };

            var persistance = context.ActivitiesAssigned.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new ActivitiesAssigned();
        }

        public async Task<bool> DeleteActivitiesAssigned(int activitiesAssignedId)
        {
            var exist = await context.ActivitiesAssigned.FindAsync(activitiesAssignedId);

            if (exist == null) throw new Exception("No Record Found!");

            context.ActivitiesAssigned.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<ActivitiesAssignedVM> GetActivitiesAssigned(int activitiesAssignedId, int tenantId)
        {
            return await (from x in context.ActivitiesAssigned
                          where x.ActivitiesAssignedId == activitiesAssignedId
                                && x.TenantId == tenantId
                          select new ActivitiesAssignedVM
                          {
                              activitiesAssignedId = x.ActivitiesAssignedId,
                              activityId = x.ActivityId,
                              roleId = x.RoleId,
                              dateTimeCreated = x.DateTimeCreated,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ActivitiesAssignedVM>> GetActivitiesAssigned(int tenantId)
        {
            return await (from x in context.ActivitiesAssigned
                          where x.TenantId == tenantId
                          //  && x.ActivitiesAssignedId == activitiesAssignedId
                          select new ActivitiesAssignedVM
                          {
                              activitiesAssignedId = x.ActivitiesAssignedId,
                              activityId = x.ActivityId,
                              roleId = x.RoleId,
                              dateTimeCreated = x.DateTimeCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.activitiesAssignedId).ToListAsync();
        }

        public async Task<IEnumerable<ActivitiesAssignedVM>> GetActivitiesAssignedById(int activitiesAssignedId, int tenantId)
        {
            return await (from x in context.ActivitiesAssigned
                          where x.TenantId == tenantId
                          select new ActivitiesAssignedVM
                          {
                              activitiesAssignedId = x.ActivitiesAssignedId,
                              activityId = x.ActivityId,
                              roleId = x.RoleId,
                              dateTimeCreated = x.DateTimeCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.activitiesAssignedId).ToListAsync();
        }

        public async Task<bool> UpdateActivitiesAssigned(int activitiesAssignedId, ActivitiesAssignedVM model)
        {
            var record = await context.ActivitiesAssigned.FindAsync(activitiesAssignedId);

            if (record == null) throw new Exception("No Record Found!");

            record.ActivitiesAssignedId = model.activitiesAssignedId;
            record.ActivityId = model.activityId;
            record.RoleId = model.roleId;
            record.DateTimeCreated = model.dateTimeCreated;
            record.TenantId = model.tenantId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






