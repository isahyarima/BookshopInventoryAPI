using Data.TransferObject.ViewModel;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Models;
using System.Data.Entity;

namespace Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly DataContext context;
        public BankRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Bank> CreateBankAsync(BankVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Bank
            {
                BankId = model.bankId,
                BankName = model.bankName,
                AccountHolder = model.accountHolder,
                BranchName = model.branchName,
                BankAddress = model.bankAddress,
                AccountNumber = model.accountNumber,
                TenantId = model.tenantId,
            };

            var persistance = context.Bank.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Bank();
        }

        public async Task<bool> DeleteBank(int bankId)
        {
            var exist = await context.Bank.FindAsync(bankId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Bank.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<BankVM> GetBank(int bankId, int tenantId)
        {
            return await (from x in context.Bank
                          where x.BankId == bankId
                                && x.TenantId == tenantId
                          select new BankVM
                          {
                              bankId = x.BankId,
                              bankName = x.BankName,
                              accountHolder = x.AccountHolder,
                              branchName = x.BranchName,
                              bankAddress = x.BankAddress,
                              accountNumber = x.AccountNumber,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BankVM>> GetBank(int tenantId)
        {
            return await (from x in context.Bank
                          where x.TenantId == tenantId
                         // && x.BankId == bankId
                          select new BankVM
                          {
                              bankId = x.BankId,
                              bankName = x.BankName,
                              accountHolder = x.AccountHolder,
                              branchName = x.BranchName,
                              bankAddress = x.BankAddress,
                              accountNumber = x.AccountNumber,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.bankId).ToListAsync();
        }

        public async Task<IEnumerable<BankVM>> GetBankById(int bankId, int tenantId)
        {
            return await (from x in context.Bank
                          where x.TenantId == tenantId
                          select new BankVM
                          {
                              bankId = x.BankId,
                              bankName = x.BankName,
                              accountHolder = x.AccountHolder,
                              branchName = x.BranchName,
                              bankAddress = x.BankAddress,
                              accountNumber = x.AccountNumber,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.bankId).ToListAsync();
        }

        public async Task<bool> UpdateBank(int bankId, BankVM model)
        {
            var record = await context.Bank.FindAsync(bankId);

            if (record == null) throw new Exception("No Record Found!");

            record.BankName = model.bankName;
            record.AccountHolder = model.accountHolder;
            record.BranchName = model.branchName;
            record.BankAddress = model.bankAddress;
            record.AccountNumber = model.accountNumber;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






