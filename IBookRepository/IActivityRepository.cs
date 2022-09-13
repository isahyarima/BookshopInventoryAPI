using Data.TransferObject.ViewModel;
using DataModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Interface
{
    public interface IActivityRepository
    {
        Task<Activity> CreateActivityAsync(ActivityVM model);

        Task<ActivityVM> GetActivity(int activityId, int tenantId);

        Task<IEnumerable<ActivityVM>> GetActivity(int tenantId);

		 Task<IEnumerable<ActivityVM>> GetActivityById(int activityId,int tenantId);

        Task<bool> UpdateActivity(int activityId, ActivityVM model);

        Task<bool> DeleteActivity(int activityId);
    }
}



     
