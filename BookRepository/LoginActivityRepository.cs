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
    public class LoginActivityRepository : ILoginActivityRepository
    {
        private readonly DataContext context;
        public LoginActivityRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<LoginActivity> CreateLoginActivityAsync(LoginActivityVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new LoginActivity
            {
                LoginActivityId = model.loginActivityId,
                PasswordHash = model.passwordHash,
                PasswordSalt = model.passwordSalt,
                IsLocked = model.isLocked,
                IsActive = model.isActive,
                LastLoginDate = model.lastLoginDate,
                CreationDate = model.creationDate,
                IsDeleted = model.isDeleted,
                EmployeeTypeId = model.employeeTypeId,
                UserName = model.userName,
                RoleId = model.roleId,
                UserId = model.userId,
                LoginTypeId = model.loginTypeId,
                TenantId = model.tenantId,
                IsPasswordReset = model.isPasswordReset,
                ConfirmationId = model.confirmationId,
                ResetExpiryDate = model.resetExpiryDate,
                IsOTPAvailable = model.isOTPAvailable,
                OPTExpirationDate = model.oPTExpirationDate,
            };

            var persistance = context.LoginActivity.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new LoginActivity();
        }

        public async Task<bool> DeleteLoginActivity(int loginActivityId)
        {
            var exist = await context.LoginActivity.FindAsync(loginActivityId);

            if (exist == null) throw new Exception("No Record Found!");

            context.LoginActivity.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<LoginActivityVM> GetLoginActivity(int loginActivityId, int tenantId)
        {
            return await (from x in context.LoginActivity
                          where x.LoginActivityId == loginActivityId
                                && x.TenantId == tenantId
                          select new LoginActivityVM
                          {
                              loginActivityId = x.LoginActivityId,
                              passwordHash = x.PasswordHash,
                              passwordSalt = x.PasswordSalt,
                              isLocked = x.IsLocked,
                              isActive = x.IsActive,
                              lastLoginDate = x.LastLoginDate,
                              creationDate = x.CreationDate,
                              isDeleted = x.IsDeleted,
                              employeeTypeId = x.EmployeeTypeId,
                              userName = x.UserName,
                              roleId = x.RoleId,
                              userId = x.UserId,
                              loginTypeId = x.LoginTypeId,
                              tenantId = x.TenantId,
                              isPasswordReset = x.IsPasswordReset,
                              confirmationId = x.ConfirmationId,
                              resetExpiryDate = x.ResetExpiryDate,
                              isOTPAvailable = x.IsOTPAvailable,
                              oPTExpirationDate = x.OPTExpirationDate,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LoginActivityVM>> GetLoginActivity(int tenantId)
        {
            return await (from x in context.LoginActivity
                          where x.TenantId == tenantId
                         //&& x.LoginActivityId == loginActivityId
                          select new LoginActivityVM
                          {
                              loginActivityId = x.LoginActivityId,
                              passwordHash = x.PasswordHash,
                              passwordSalt = x.PasswordSalt,
                              isLocked = x.IsLocked,
                              isActive = x.IsActive,
                              lastLoginDate = x.LastLoginDate,
                              creationDate = x.CreationDate,
                              isDeleted = x.IsDeleted,
                              employeeTypeId = x.EmployeeTypeId,
                              userName = x.UserName,
                              roleId = x.RoleId,
                              userId = x.UserId,
                              loginTypeId = x.LoginTypeId,
                              tenantId = x.TenantId,
                              isPasswordReset = x.IsPasswordReset,
                              confirmationId = x.ConfirmationId,
                              resetExpiryDate = x.ResetExpiryDate,
                              isOTPAvailable = x.IsOTPAvailable,
                              oPTExpirationDate = x.OPTExpirationDate,

                          }).OrderBy(o => o.loginActivityId).ToListAsync();
        }

        public async Task<IEnumerable<LoginActivityVM>> GetLoginActivityById(int loginActivityId, int tenantId)
        {
            return await (from x in context.LoginActivity
                          where x.TenantId == tenantId
                          select new LoginActivityVM
                          {
                              loginActivityId = x.LoginActivityId,
                              passwordHash = x.PasswordHash,
                              passwordSalt = x.PasswordSalt,
                              isLocked = x.IsLocked,
                              isActive = x.IsActive,
                              lastLoginDate = x.LastLoginDate,
                              creationDate = x.CreationDate,
                              isDeleted = x.IsDeleted,
                              employeeTypeId = x.EmployeeTypeId,
                              userName = x.UserName,
                              roleId = x.RoleId,
                              userId = x.UserId,
                              loginTypeId = x.LoginTypeId,
                              tenantId = x.TenantId,
                              isPasswordReset = x.IsPasswordReset,
                              confirmationId = x.ConfirmationId,
                              resetExpiryDate = x.ResetExpiryDate,
                              isOTPAvailable = x.IsOTPAvailable,
                              oPTExpirationDate = x.OPTExpirationDate,

                          }).OrderBy(o => o.loginActivityId).ToListAsync();
        }

        public async Task<bool> UpdateLoginActivity(int loginActivityId, LoginActivityVM model)
        {
            var record = await context.LoginActivity.FindAsync(loginActivityId);

            if (record == null) throw new Exception("No Record Found!");

            record.LoginActivityId = model.loginActivityId;
            record.PasswordHash = model.passwordHash;
            record.PasswordSalt = model.passwordSalt;
            record.IsLocked = model.isLocked;
            record.IsActive = model.isActive;
            record.LastLoginDate = model.lastLoginDate;
            record.CreationDate = model.creationDate;
            record.IsDeleted = model.isDeleted;
            record.EmployeeTypeId = model.employeeTypeId;
            record.UserName = model.userName;
            record.RoleId = model.roleId;
            record.UserId = model.userId;
            record.LoginTypeId = model.loginTypeId;
            record.TenantId = model.tenantId;
            record.IsPasswordReset = model.isPasswordReset;
            record.ConfirmationId = model.confirmationId;
            record.ResetExpiryDate = model.resetExpiryDate;
            record.IsOTPAvailable = model.isOTPAvailable;
            record.OPTExpirationDate = model.oPTExpirationDate;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






