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
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext context;
        public RoleRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Role> CreateRoleAsync(RoleVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Role
            {
                RoleId = model.roleId,
                RoleName = model.roleName,
                EmployeeTypeId = model.employeeTypeId,
                RoleLevelAccressId = model.roleLevelAccressId,
                TenantId = model.tenantId,
                DateCreated = model.dateCreated,
            };

            var persistance = context.Role.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Role();
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var exist = await context.Role.FindAsync(roleId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Role.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<RoleVM> GetRole(int roleId, int tenantId)
        {
            return await (from x in context.Role
                          where x.RoleId == roleId
                                && x.TenantId == tenantId
                          select new RoleVM
                          {
                              roleId = x.RoleId,
                              roleName = x.RoleName,
                              employeeTypeId = x.EmployeeTypeId,
                              roleLevelAccressId = x.RoleLevelAccressId,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RoleVM>> GetRole(int tenantId)
        {
            return await (from x in context.Role
                          where x.TenantId == tenantId
                         // && x.RoleId == roleId
                          select new RoleVM
                          {
                              roleId = x.RoleId,
                              roleName = x.RoleName,
                              employeeTypeId = x.EmployeeTypeId,
                              roleLevelAccressId = x.RoleLevelAccressId,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.roleId).ToListAsync();
        }

        public async Task<IEnumerable<RoleVM>> GetRoleById(int roleId, int tenantId)
        {
            return await (from x in context.Role
                          where x.TenantId == tenantId
                          select new RoleVM
                          {
                              roleId = x.RoleId,
                              roleName = x.RoleName,
                              employeeTypeId = x.EmployeeTypeId,
                              roleLevelAccressId = x.RoleLevelAccressId,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.roleId).ToListAsync();
        }

        public async Task<bool> UpdateRole(int roleId, RoleVM model)
        {
            var record = await context.Role.FindAsync(roleId);

            if (record == null) throw new Exception("No Record Found!");

            record.RoleId = model.roleId;
            record.RoleName = model.roleName;
            record.EmployeeTypeId = model.employeeTypeId;
            record.RoleLevelAccressId = model.roleLevelAccressId;
            record.TenantId = model.tenantId;
            record.DateCreated = model.dateCreated;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






