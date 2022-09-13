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
    public class EmployeeContactRepository : IEmployeeContactRepository
    {
        private readonly DataContext context;
        public EmployeeContactRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<EmployeeContact> CreateEmployeeContactAsync(EmployeeContactVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new EmployeeContact
            {
                EmployeeContactId = model.employeeContactId,
                Email = model.email,
                HomeAddress = model.homeAddress,
                PhoneNumber = model.phoneNumber,
                EmployeeId = model.employeeId,
                TenantId = model.tenantId,
            };

            var persistance = context.EmployeeContact.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new EmployeeContact();
        }

        public async Task<bool> DeleteEmployeeContact(int employeeContactId)
        {
            var exist = await context.EmployeeContact.FindAsync(employeeContactId);

            if (exist == null) throw new Exception("No Record Found!");

            context.EmployeeContact.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<EmployeeContactVM> GetEmployeeContact(int employeeContactId, int tenantId)
        {
            return await (from x in context.EmployeeContact
                          where x.EmployeeContactId == employeeContactId
                                && x.TenantId == tenantId
                          select new EmployeeContactVM
                          {
                              employeeContactId = x.EmployeeContactId,
                              email = x.Email,
                              homeAddress = x.HomeAddress,
                              phoneNumber = x.PhoneNumber,
                              employeeId = x.EmployeeId,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeContactVM>> GetEmployeeContact(int tenantId)
        {
            return await (from x in context.EmployeeContact
                          where x.TenantId == tenantId
                        //  && x.EmployeeContactId == employeeContactId
                          select new EmployeeContactVM
                          {
                              employeeContactId = x.EmployeeContactId,
                              email = x.Email,
                              homeAddress = x.HomeAddress,
                              phoneNumber = x.PhoneNumber,
                              employeeId = x.EmployeeId,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.employeeContactId).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeContactVM>> GetEmployeeContactById(int employeeContactId, int tenantId)
        {
            return await (from x in context.EmployeeContact
                          where x.TenantId == tenantId
                          select new EmployeeContactVM
                          {
                              employeeContactId = x.EmployeeContactId,
                              email = x.Email,
                              homeAddress = x.HomeAddress,
                              phoneNumber = x.PhoneNumber,
                              employeeId = x.EmployeeId,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.employeeContactId).ToListAsync();
        }

        public async Task<bool> UpdateEmployeeContact(int employeeContactId, EmployeeContactVM model)
        {
            var record = await context.EmployeeContact.FindAsync(employeeContactId);

            if (record == null) throw new Exception("No Record Found!");

            record.Email = model.email;
            record.HomeAddress = model.homeAddress;
            record.PhoneNumber = model.phoneNumber;
            record.EmployeeId = model.employeeId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






