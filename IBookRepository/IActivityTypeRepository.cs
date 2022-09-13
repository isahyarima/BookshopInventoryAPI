using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IActivityTypeRepository
    {
        Task<ActivityType> CreateActivityTypeAsync(ActivityTypeVM model);

        Task<ActivityTypeVM> GetActivityType(int activityTypeId, int tenantId);

        Task<IEnumerable<ActivityTypeVM>> GetActivityType(int tenantId);

		 Task<IEnumerable<ActivityTypeVM>> GetActivityTypeById(int activityTypeId,int tenantId);

        Task<bool> UpdateActivityType(int activityTypeId, ActivityTypeVM model);

        Task<bool> DeleteActivityType(int activityTypeId);
    }
}



     
