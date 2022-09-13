using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IAuditTrailTypeRepository
    {
        Task<AuditTrailType> CreateAuditTrailTypeAsync(AuditTrailTypeVM model);

        Task<AuditTrailTypeVM> GetAuditTrailType(int auditTrailTypeId, int tenantId);

        Task<IEnumerable<AuditTrailTypeVM>> GetAuditTrailType(int tenantId);

		 Task<IEnumerable<AuditTrailTypeVM>> GetAuditTrailTypeById(int auditTrailTypeId,int tenantId);

        Task<bool> UpdateAuditTrailType(int auditTrailTypeId, AuditTrailTypeVM model);

        Task<bool> DeleteAuditTrailType(int auditTrailTypeId);
    }
}



     
