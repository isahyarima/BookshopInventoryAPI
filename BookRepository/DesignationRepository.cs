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
    public class DesignationRepository : IDesignationRepository
    {
        private readonly DataContext context;
        public DesignationRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Designation> CreateDesignationAsync(DesignationVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Designation
            {
                DesignationId = model.designationId,
                DesignationName = model.designationName,
                TenantId = model.tenantId,
            };

            var persistance = context.Designation.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Designation();
        }

        public async Task<bool> DeleteDesignation(int designationId)
        {
            var exist = await context.Designation.FindAsync(designationId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Designation.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<DesignationVM> GetDesignation(int designationId, int tenantId)
        {
            return await (from x in context.Designation
                          where x.DesignationId == designationId
                                && x.TenantId == tenantId
                          select new DesignationVM
                          {
                              designationId = x.DesignationId,
                              designationName = x.DesignationName,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DesignationVM>> GetDesignation(int tenantId)
        {
            return await (from x in context.Designation
                          where x.TenantId == tenantId
                         // && x.DesignationId == designationId
                          select new DesignationVM
                          {
                              designationId = x.DesignationId,
                              designationName = x.DesignationName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.designationId).ToListAsync();
        }

        public async Task<IEnumerable<DesignationVM>> GetDesignationById(int designationId, int tenantId)
        {
            return await (from x in context.Designation
                          where x.TenantId == tenantId
                          select new DesignationVM
                          {
                              designationId = x.DesignationId,
                              designationName = x.DesignationName,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.designationId).ToListAsync();
        }

        public async Task<bool> UpdateDesignation(int designationId, DesignationVM model)
        {
            var record = await context.Designation.FindAsync(designationId);

            if (record == null) throw new Exception("No Record Found!");

            record.DesignationId = model.designationId;
            record.DesignationName = model.designationName;
            record.TenantId = model.tenantId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






