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
    public class AuditTrailRepository : IAuditTrailRepository
    {
        private readonly DataContext context;
        public AuditTrailRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<AuditTrail> CreateAuditTrailAsync(AuditTrailVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new AuditTrail
            {
                AuditTrailId = model.auditTrailId,
                AuditTrailTypeId = model.auditTrailTypeId,
                ActionMethod = model.actionMethod,
                Description = model.description,
                Url = model.url,
                ActionById = model.actionById,
                IP = model.iP,
                TargetId = model.targetId,
                TenantId = model.tenantId,
                DateCreated = model.dateCreated,
            };

            var persistance = context.AuditTrail.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new AuditTrail();
        }

        public async Task<bool> DeleteAuditTrail(int auditTrailId)
        {
            var exist = await context.AuditTrail.FindAsync(auditTrailId);

            if (exist == null) throw new Exception("No Record Found!");

            context.AuditTrail.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<AuditTrailVM> GetAuditTrail(int auditTrailId, int tenantId)
        {
            return await (from x in context.AuditTrail
                          where x.AuditTrailId == auditTrailId
                                && x.TenantId == tenantId
                          select new AuditTrailVM
                          {
                              auditTrailId = x.AuditTrailId,
                              auditTrailTypeId = x.AuditTrailTypeId,
                              actionMethod = x.ActionMethod,
                              description = x.Description,
                              url = x.Url,
                              actionById = x.ActionById,
                              iP = x.IP,
                              targetId = x.TargetId,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AuditTrailVM>> GetAuditTrail(int tenantId)
        {
            return await (from x in context.AuditTrail
                          where x.TenantId == tenantId
                        // && x.AuditTrailId == auditTrailId
                          select new AuditTrailVM
                          {
                              auditTrailId = x.AuditTrailId,
                              auditTrailTypeId = x.AuditTrailTypeId,
                              actionMethod = x.ActionMethod,
                              description = x.Description,
                              url = x.Url,
                              actionById = x.ActionById,
                              iP = x.IP,
                              targetId = x.TargetId,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.auditTrailId).ToListAsync();
        }

        public async Task<IEnumerable<AuditTrailVM>> GetAuditTrailById(int auditTrailId, int tenantId)
        {
            return await (from x in context.AuditTrail
                          where x.TenantId == tenantId
                          select new AuditTrailVM
                          {
                              auditTrailId = x.AuditTrailId,
                              auditTrailTypeId = x.AuditTrailTypeId,
                              actionMethod = x.ActionMethod,
                              description = x.Description,
                              url = x.Url,
                              actionById = x.ActionById,
                              iP = x.IP,
                              targetId = x.TargetId,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.auditTrailId).ToListAsync();
        }

        public async Task<bool> UpdateAuditTrail(int auditTrailId, AuditTrailVM model)
        {
            var record = await context.AuditTrail.FindAsync(auditTrailId);

            if (record == null) throw new Exception("No Record Found!");

            record.AuditTrailId = model.auditTrailId;
            record.AuditTrailTypeId = model.auditTrailTypeId;
            record.ActionMethod = model.actionMethod;
            record.Description = model.description;
            record.Url = model.url;
            record.ActionById = model.actionById;
            record.IP = model.iP;
            record.TargetId = model.targetId;
            record.TenantId = model.tenantId;
            record.DateCreated = model.dateCreated;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






