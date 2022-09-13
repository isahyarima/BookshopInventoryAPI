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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext context;
        public EmployeeRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Employee
            {
                EmployeeId = model.employeeId,
                FirstName = model.firstName,
                MiddleName = model.middleName,
                LastName = model.lastName,
                Gender = model.gender,
                DateOfBirth = model.dateOfBirth,
                CreationDate = DateTime.Now,
                CreaterUserId = model.createrUserId,
                IsDeleted = model.isDeleted,
                DeletionDate = model.deletionDate,
                DeleterUserId = model.deleterUserId,
                IsApproved = model.isApproved,
                ApproveDate = model.approveDate,
                ApproverUserId = model.approverUserId,
                StatusId = model.statusId,
                StateId = model.stateId,
                LocalGovtId = model.localGovtId,
                TenantId = model.tenantId,
                NationaliltyId = model.nationaliltyId,
                Email = model.email,
                HomeAddress = model.homeAddress,
                PhoneNumber = model.phoneNumber,
                DesignationId = model.designationId,
                EmployeeNumber = model.employeeNumber,
                TitleId = model.titleId,
            };

            var persistance = context.Employee.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Employee();
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var exist = await context.Employee.FindAsync(employeeId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Employee.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<EmployeeVM> GetEmployee(int employeeId, int tenantId)
        {
            return await (from x in context.Employee
                          where x.EmployeeId == employeeId
                                && x.TenantId == tenantId
                          select new EmployeeVM
                          {
                              employeeId = x.EmployeeId,
                              firstName = x.FirstName,
                              middleName = x.MiddleName,
                              lastName = x.LastName,
                              gender = x.Gender,
                              dateOfBirth = x.DateOfBirth,
                              creationDate = x.CreationDate,
                              createrUserId = x.CreaterUserId,
                              isDeleted = x.IsDeleted,
                              deletionDate = x.DeletionDate,
                              deleterUserId = x.DeleterUserId,
                              isApproved = x.IsApproved,
                              approveDate = x.ApproveDate,
                              approverUserId = x.ApproverUserId,
                              statusId = x.StatusId,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              tenantId = x.TenantId,
                              nationaliltyId = x.NationaliltyId,
                              email = x.Email,
                              homeAddress = x.HomeAddress,
                              phoneNumber = x.PhoneNumber,
                              designationId = x.DesignationId,
                              employeeNumber = x.EmployeeNumber,
                              titleId = x.TitleId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeVM>> GetEmployee(int tenantId)
        {
            return await (from x in context.Employee
                          where x.TenantId == tenantId
                         //&& x.EmployeeId == employeeId
                          select new EmployeeVM
                          {
                              employeeId = x.EmployeeId,
                              firstName = x.FirstName,
                              middleName = x.MiddleName,
                              lastName = x.LastName,
                              gender = x.Gender,
                              dateOfBirth = x.DateOfBirth,
                              creationDate = x.CreationDate,
                              createrUserId = x.CreaterUserId,
                              isDeleted = x.IsDeleted,
                              deletionDate = x.DeletionDate,
                              deleterUserId = x.DeleterUserId,
                              isApproved = x.IsApproved,
                              approveDate = x.ApproveDate,
                              approverUserId = x.ApproverUserId,
                              statusId = x.StatusId,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              tenantId = x.TenantId,
                              nationaliltyId = x.NationaliltyId,
                              email = x.Email,
                              homeAddress = x.HomeAddress,
                              phoneNumber = x.PhoneNumber,
                              designationId = x.DesignationId,
                              employeeNumber = x.EmployeeNumber,
                              titleId = x.TitleId,

                          }).OrderBy(o => o.employeeId).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeVM>> GetEmployeeById(int employeeId, int tenantId)
        {
            return await (from x in context.Employee
                          where x.TenantId == tenantId
                          select new EmployeeVM
                          {
                              employeeId = x.EmployeeId,
                              firstName = x.FirstName,
                              middleName = x.MiddleName,
                              lastName = x.LastName,
                              gender = x.Gender,
                              dateOfBirth = x.DateOfBirth,
                              creationDate = x.CreationDate,
                              createrUserId = x.CreaterUserId,
                              isDeleted = x.IsDeleted,
                              deletionDate = x.DeletionDate,
                              deleterUserId = x.DeleterUserId,
                              isApproved = x.IsApproved,
                              approveDate = x.ApproveDate,
                              approverUserId = x.ApproverUserId,
                              statusId = x.StatusId,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              tenantId = x.TenantId,
                              nationaliltyId = x.NationaliltyId,
                              email = x.Email,
                              homeAddress = x.HomeAddress,
                              phoneNumber = x.PhoneNumber,
                              designationId = x.DesignationId,
                              employeeNumber = x.EmployeeNumber,
                              titleId = x.TitleId,

                          }).OrderBy(o => o.employeeId).ToListAsync();
        }

        public async Task<bool> UpdateEmployee(int employeeId, EmployeeVM model)
        {
            var record = await context.Employee.FindAsync(employeeId);

            if (record == null) throw new Exception("No Record Found!");

            record.FirstName = model.firstName;
            record.MiddleName = model.middleName;
            record.LastName = model.lastName;
            record.Gender = model.gender;
            record.DateOfBirth = model.dateOfBirth;
            record.CreationDate =DateTime.Now;
            record.CreaterUserId = model.createrUserId;
            record.IsDeleted = model.isDeleted;
            record.DeletionDate = model.deletionDate;
            record.DeleterUserId = model.deleterUserId;
            record.IsApproved = model.isApproved;
            record.ApproveDate = model.approveDate;
            record.ApproverUserId = model.approverUserId;
            record.StatusId = model.statusId;
            record.StateId = model.stateId;
            record.LocalGovtId = model.localGovtId;
            record.NationaliltyId = model.nationaliltyId;
            record.Email = model.email;
            record.HomeAddress = model.homeAddress;
            record.PhoneNumber = model.phoneNumber;
            record.DesignationId = model.designationId;
            record.EmployeeNumber = model.employeeNumber;
            record.TitleId = model.titleId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






