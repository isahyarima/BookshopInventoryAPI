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
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly DataContext context;
        public ActivityTypeRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<ActivityType> CreateActivityTypeAsync(ActivityTypeVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new ActivityType
            {
                ActivityTypeId = model.activityTypeId,
                ActivityTypeName = model.activityTypeName,
                TenantId = model.tenantId,
            };

            var persistance = context.ActivityType.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new ActivityType();
        }

        public async Task<bool> DeleteActivityType(int activityTypeId)
        {
            var exist = await context.ActivityType.FindAsync(activityTypeId);

            if (exist == null) throw new Exception("No Record Found!");

            context.ActivityType.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<ActivityTypeVM> GetActivityType(int activityTypeId, int tenantId)
        {
            return await (from x in context.ActivityType
                          where x.ActivityTypeId == activityTypeId
                                && x.TenantId == tenantId
                          select new ActivityTypeVM
                          {
                              activityTypeId = x.ActivityTypeId,
                              activityTypeName = x.ActivityTypeName,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ActivityTypeVM>> GetActivityType(int tenantId)
        {
            return await (from x in context.ActivityType
                          where x.TenantId == tenantId
                         // && x.ActivityTypeId == activityTypeId
                          select new ActivityTypeVM
                          {
                              activityTypeId = x.ActivityTypeId,
                              activityTypeName = x.ActivityTypeName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.activityTypeId).ToListAsync();
        }

        public async Task<IEnumerable<ActivityTypeVM>> GetActivityTypeById(int activityTypeId, int tenantId)
        {
            return await (from x in context.ActivityType
                          where x.TenantId == tenantId
                          select new ActivityTypeVM
                          {
                              activityTypeId = x.ActivityTypeId,
                              activityTypeName = x.ActivityTypeName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.activityTypeId).ToListAsync();
        }

        public async Task<bool> UpdateActivityType(int activityTypeId, ActivityTypeVM model)
        {
            var record = await context.ActivityType.FindAsync(activityTypeId);

            if (record == null) throw new Exception("No Record Found!");

            record.ActivityTypeId = model.activityTypeId;
            record.ActivityTypeName = model.activityTypeName;
            record.TenantId = model.tenantId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






