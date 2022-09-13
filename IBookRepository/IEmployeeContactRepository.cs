using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IEmployeeContactRepository
    {
        Task<EmployeeContact> CreateEmployeeContactAsync(EmployeeContactVM model);

        Task<EmployeeContactVM> GetEmployeeContact(int employeeContactId, int tenantId);

        Task<IEnumerable<EmployeeContactVM>> GetEmployeeContact(int tenantId);

		 Task<IEnumerable<EmployeeContactVM>> GetEmployeeContactById(int employeeContactId,int tenantId);

        Task<bool> UpdateEmployeeContact(int employeeContactId, EmployeeContactVM model);

        Task<bool> DeleteEmployeeContact(int employeeContactId);
    }
}



     
