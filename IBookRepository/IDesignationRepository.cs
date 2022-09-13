using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IDesignationRepository
    {
        Task<Designation> CreateDesignationAsync(DesignationVM model);

        Task<DesignationVM> GetDesignation(int designationId, int tenantId);

        Task<IEnumerable<DesignationVM>> GetDesignation(int tenantId);

		 Task<IEnumerable<DesignationVM>> GetDesignationById(int designationId,int tenantId);

        Task<bool> UpdateDesignation(int designationId, DesignationVM model);

        Task<bool> DeleteDesignation(int designationId);
    }
}



     
