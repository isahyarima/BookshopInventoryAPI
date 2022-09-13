using Common.TableEnum;
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
    public class SaleIssueRegisterRepository : ISaleIssueRegisterRepository
    {
        private readonly DataContext context;
        public SaleIssueRegisterRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<SaleIssueRegister> CreateSaleIssueRegisterAsync(SaleIssueRegisterVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new SaleIssueRegister
            {
                SaleIssueRegisterId = model.saleIssueRegisterId,
                CustomerId = model.customerId,
                PartyName = model.partyName,
                IssueDate = model.issueDate,
                IssueTime = model.issueTime,
                DocumentNumber = model.documentNumber,
                IssueStatusId = model.issueStatusId,
                DateRegistered = DateTime.Now,
                TenantId = model.tenantId,
                Createby = model.createby,
                StatusId = (int)StatusEnum.Active
            };

            var persistance = context.SaleIssueRegister.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new SaleIssueRegister();
        }

        public async Task<bool> DeleteSaleIssueRegister(int saleIssueRegisterId)
        {
            var exist = await context.SaleIssueRegister.FindAsync(saleIssueRegisterId);

            if (exist == null) throw new Exception("No Record Found!");

            context.SaleIssueRegister.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<SaleIssueRegisterVM> GetSaleIssueRegister(int saleIssueRegisterId, int tenantId)
        {
            return await (from x in context.SaleIssueRegister
                          where x.SaleIssueRegisterId == saleIssueRegisterId
                                && x.TenantId == tenantId
                          select new SaleIssueRegisterVM
                          {
                              saleIssueRegisterId = x.SaleIssueRegisterId,
                              customerId = x.CustomerId,
                              partyName = x.PartyName,
                              issueDate = x.IssueDate,
                              issueTime = x.IssueTime,
                              documentNumber = x.DocumentNumber,
                              issueStatusId = x.IssueStatusId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createby = x.Createby,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SaleIssueRegisterVM>> GetSaleIssueRegister(int tenantId)
        {
            return await (from x in context.SaleIssueRegister
                          where x.TenantId == tenantId
                       //   && x.SaleIssueRegisterId == saleIssueRegisterId
                          select new SaleIssueRegisterVM
                          {
                              saleIssueRegisterId = x.SaleIssueRegisterId,
                              customerId = x.CustomerId,
                              partyName = x.PartyName,
                              issueDate = x.IssueDate,
                              issueTime = x.IssueTime,
                              documentNumber = x.DocumentNumber,
                              issueStatusId = x.IssueStatusId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createby = x.Createby,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleIssueRegisterId).ToListAsync();
        }

        public async Task<IEnumerable<SaleIssueRegisterVM>> GetSaleIssueRegisterById(int saleIssueRegisterId, int tenantId)
        {
            return await (from x in context.SaleIssueRegister
                          where x.TenantId == tenantId
                          select new SaleIssueRegisterVM
                          {
                              saleIssueRegisterId = x.SaleIssueRegisterId,
                              customerId = x.CustomerId,
                              partyName = x.PartyName,
                              issueDate = x.IssueDate,
                              issueTime = x.IssueTime,
                              documentNumber = x.DocumentNumber,
                              issueStatusId = x.IssueStatusId,
                              dateRegistered = x.DateRegistered,
                              tenantId = x.TenantId,
                              createby = x.Createby,
                              status = context.Status.Where(o => o.StatusId == x.StatusId).Select(o => o.StatusName).FirstOrDefault(),


                          }).OrderBy(o => o.saleIssueRegisterId).ToListAsync();
        }

        public async Task<bool> UpdateSaleIssueRegister(int saleIssueRegisterId, SaleIssueRegisterVM model)
        {
            var record = await context.SaleIssueRegister.FindAsync(saleIssueRegisterId);

            if (record == null) throw new Exception("No Record Found!");


            record.CustomerId = model.customerId;
            record.PartyName = model.partyName;
            record.IssueDate = model.issueDate;
            record.IssueTime = model.issueTime;
            record.DocumentNumber = model.documentNumber;
            record.IssueStatusId = model.issueStatusId;
            record.DateRegistered = DateTime.Now;
            record.Createby = model.createby;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






