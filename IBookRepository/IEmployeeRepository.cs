using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployeeAsync(EmployeeVM model);

        Task<EmployeeVM> GetEmployee(int employeeId, int tenantId);

        Task<IEnumerable<EmployeeVM>> GetEmployee(int tenantId);

		 Task<IEnumerable<EmployeeVM>> GetEmployeeById(int employeeId,int tenantId);

        Task<bool> UpdateEmployee(int employeeId, EmployeeVM model);

        Task<bool> DeleteEmployee(int employeeId);
    }
}



     
