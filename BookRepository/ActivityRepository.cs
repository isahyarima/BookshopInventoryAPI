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
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext context;
        public ActivityRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Activity> CreateActivityAsync(ActivityVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Activity
            {
                ActivityId = model.activityId,
                ActivityTypeId = model.activityTypeId,
                ActivityName = model.activityName,
                TenantId = model.tenantId,
                ActivityLabel = model.activityLabel,
                DepartmentId = model.departmentId,
                IsActive = model.isActive,
            };

            var persistance = context.Activity.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Activity();
        }

        public async Task<bool> DeleteActivity(int activityId)
        {
            var exist = await context.Activity.FindAsync(activityId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Activity.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<ActivityVM> GetActivity(int activityId, int tenantId)
        {
            return await (from x in context.Activity
                          where x.ActivityId == activityId
                                && x.TenantId == tenantId
                          select new ActivityVM
                          {
                              activityId = x.ActivityId,
                              activityTypeId = x.ActivityTypeId,
                              activityName = x.ActivityName,
                              tenantId = x.TenantId,
                              activityLabel = x.ActivityLabel,
                              departmentId = x.DepartmentId,
                              isActive = x.IsActive,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ActivityVM>> GetActivity(int tenantId)
        {
            return await (from x in context.Activity
                          where x.TenantId == tenantId
                         //&& x.ActivityId == activityId
                          select new ActivityVM
                          {
                              activityId = x.ActivityId,
                              activityTypeId = x.ActivityTypeId,
                              activityName = x.ActivityName,
                              tenantId = x.TenantId,
                              activityLabel = x.ActivityLabel,
                              departmentId = x.DepartmentId,
                              isActive = x.IsActive,

                          }).OrderBy(o => o.activityId).ToListAsync();
        }

        public async Task<IEnumerable<ActivityVM>> GetActivityById(int activityId, int tenantId)
        {
            return await (from x in context.Activity
                          where x.TenantId == tenantId
                          select new ActivityVM
                          {
                              activityId = x.ActivityId,
                              activityTypeId = x.ActivityTypeId,
                              activityName = x.ActivityName,
                              tenantId = x.TenantId,
                              activityLabel = x.ActivityLabel,
                              departmentId = x.DepartmentId,
                              isActive = x.IsActive,

                          }).OrderBy(o => o.activityId).ToListAsync();
        }

        public async Task<bool> UpdateActivity(int activityId, ActivityVM model)
        {
            var record = await context.Activity.FindAsync(activityId);

            if (record == null) throw new Exception("No Record Found!");

            record.ActivityId = model.activityId;
            record.ActivityTypeId = model.activityTypeId;
            record.ActivityName = model.activityName;
            record.TenantId = model.tenantId;
            record.ActivityLabel = model.activityLabel;
            record.DepartmentId = model.departmentId;
            record.IsActive = model.isActive;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






