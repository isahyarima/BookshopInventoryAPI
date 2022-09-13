using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(CustomerVM model);

        Task<CustomerVM> GetCustomer(int customerId, int tenantId);

        Task<IEnumerable<CustomerVM>> GetCustomer(int tenantId);

		 Task<IEnumerable<CustomerVM>> GetCustomerById(int customerId,int tenantId);

        Task<bool> UpdateCustomer(int customerId, CustomerVM model);

        Task<bool> DeleteCustomer(int customerId);
    }
}



     
