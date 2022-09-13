using Data.TransferObject.ViewModel;
using DataModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Interface
{
    public interface IActivitiesAssignedRepository
    {
        Task<ActivitiesAssigned> CreateActivitiesAssignedAsync(ActivitiesAssignedVM model);

        Task<ActivitiesAssignedVM> GetActivitiesAssigned(int activitiesAssignedId, int tenantId);

        Task<IEnumerable<ActivitiesAssignedVM>> GetActivitiesAssigned(int tenantId);

		 Task<IEnumerable<ActivitiesAssignedVM>> GetActivitiesAssignedById(int activitiesAssignedId,int tenantId);

        Task<bool> UpdateActivitiesAssigned(int activitiesAssignedId, ActivitiesAssignedVM model);

        Task<bool> DeleteActivitiesAssigned(int activitiesAssignedId);
    }
}



     
