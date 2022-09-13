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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext context;
        public CustomerRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Customer
            {
                CustomerId = model.customerId,
                CustomerName = model.customerName,
                PhoneNumber = model.phoneNumber,
                Email = model.email,
                Address = model.address,
                TenantId = model.tenantId,
                DateCreated = DateTime.Now,
            };

            var persistance = context.Customer.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Customer();
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var exist = await context.Customer.FindAsync(customerId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Customer.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<CustomerVM> GetCustomer(int customerId, int tenantId)
        {
            return await (from x in context.Customer
                          where x.CustomerId == customerId
                                && x.TenantId == tenantId
                          select new CustomerVM
                          {
                              customerId = x.CustomerId,
                              customerName = x.CustomerName,
                              phoneNumber = x.PhoneNumber,
                              email = x.Email,
                              address = x.Address,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerVM>> GetCustomer(int tenantId)
        {
            return await (from x in context.Customer
                          where x.TenantId == tenantId
                        //  && x.CustomerId == customerId
                          select new CustomerVM
                          {
                              customerId = x.CustomerId,
                              customerName = x.CustomerName,
                              phoneNumber = x.PhoneNumber,
                              email = x.Email,
                              address = x.Address,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.customerId).ToListAsync();
        }

        public async Task<IEnumerable<CustomerVM>> GetCustomerById(int customerId, int tenantId)
        {
            return await (from x in context.Customer
                          where x.TenantId == tenantId
                          select new CustomerVM
                          {
                              customerId = x.CustomerId,
                              customerName = x.CustomerName,
                              phoneNumber = x.PhoneNumber,
                              email = x.Email,
                              address = x.Address,
                              tenantId = x.TenantId,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.customerId).ToListAsync();
        }

        public async Task<bool> UpdateCustomer(int customerId, CustomerVM model)
        {
            var record = await context.Customer.FindAsync(customerId);

            if (record == null) throw new Exception("No Record Found!");

            record.CustomerName = model.customerName;
            record.PhoneNumber = model.phoneNumber;
            record.Email = model.email;
            record.Address = model.address;
            record.DateCreated = DateTime.Now;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






