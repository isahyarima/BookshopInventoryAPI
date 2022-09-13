using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IRoleRepository
    {
        Task<Role> CreateRoleAsync(RoleVM model);

        Task<RoleVM> GetRole(int roleId, int tenantId);

        Task<IEnumerable<RoleVM>> GetRole(int tenantId);

		 Task<IEnumerable<RoleVM>> GetRoleById(int roleId,int tenantId);

        Task<bool> UpdateRole(int roleId, RoleVM model);

        Task<bool> DeleteRole(int roleId);
    }
}



     
