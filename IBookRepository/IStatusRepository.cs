using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IStatusRepository
    {
        Task<Status> CreateStatusAsync(StatusVM model);

        Task<StatusVM> GetStatus(int statusId, int tenantId);

        Task<IEnumerable<StatusVM>> GetStatus(int tenantId);

		 Task<IEnumerable<StatusVM>> GetStatusById(int statusId,int tenantId);

        Task<bool> UpdateStatus(int statusId, StatusVM model);

        Task<bool> DeleteStatus(int statusId);
    }
}



     
