using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IAuditTrailRepository
    {
        Task<AuditTrail> CreateAuditTrailAsync(AuditTrailVM model);

        Task<AuditTrailVM> GetAuditTrail(int auditTrailId, int tenantId);

        Task<IEnumerable<AuditTrailVM>> GetAuditTrail(int tenantId);

		 Task<IEnumerable<AuditTrailVM>> GetAuditTrailById(int auditTrailId,int tenantId);

        Task<bool> UpdateAuditTrail(int auditTrailId, AuditTrailVM model);

        Task<bool> DeleteAuditTrail(int auditTrailId);
    }
}



     
