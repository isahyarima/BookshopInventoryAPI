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
    public class AuditTrailTypeRepository : IAuditTrailTypeRepository
    {
        private readonly DataContext context;
        public AuditTrailTypeRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<AuditTrailType> CreateAuditTrailTypeAsync(AuditTrailTypeVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new AuditTrailType
            {
                AuditTrailTypeId = model.auditTrailTypeId,
                Module = model.module,
                AuditTrailTypeName = model.auditTrailTypeName,
                TenantId = model.tenantId,
            };

            var persistance = context.AuditTrailType.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new AuditTrailType();
        }

        public async Task<bool> DeleteAuditTrailType(int auditTrailTypeId)
        {
            var exist = await context.AuditTrailType.FindAsync(auditTrailTypeId);

            if (exist == null) throw new Exception("No Record Found!");

            context.AuditTrailType.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<AuditTrailTypeVM> GetAuditTrailType(int auditTrailTypeId, int tenantId)
        {
            return await (from x in context.AuditTrailType
                          where x.AuditTrailTypeId == auditTrailTypeId
                                && x.TenantId == tenantId
                          select new AuditTrailTypeVM
                          {
                              auditTrailTypeId = x.AuditTrailTypeId,
                              module = x.Module,
                              auditTrailTypeName = x.AuditTrailTypeName,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AuditTrailTypeVM>> GetAuditTrailType(int tenantId)
        {
            return await (from x in context.AuditTrailType
                          where x.TenantId == tenantId
                        //  && x.AuditTrailTypeId == auditTrailTypeId
                          select new AuditTrailTypeVM
                          {
                              auditTrailTypeId = x.AuditTrailTypeId,
                              module = x.Module,
                              auditTrailTypeName = x.AuditTrailTypeName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.auditTrailTypeId).ToListAsync();
        }

        public async Task<IEnumerable<AuditTrailTypeVM>> GetAuditTrailTypeById(int auditTrailTypeId, int tenantId)
        {
            return await (from x in context.AuditTrailType
                          where x.TenantId == tenantId
                          select new AuditTrailTypeVM
                          {
                              auditTrailTypeId = x.AuditTrailTypeId,
                              module = x.Module,
                              auditTrailTypeName = x.AuditTrailTypeName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.auditTrailTypeId).ToListAsync();
        }

        public async Task<bool> UpdateAuditTrailType(int auditTrailTypeId, AuditTrailTypeVM model)
        {
            var record = await context.AuditTrailType.FindAsync(auditTrailTypeId);

            if (record == null) throw new Exception("No Record Found!");

            record.AuditTrailTypeId = model.auditTrailTypeId;
            record.Module = model.module;
            record.AuditTrailTypeName = model.auditTrailTypeName;
            record.TenantId = model.tenantId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






