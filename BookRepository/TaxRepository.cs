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
    public class TaxRepository : ITaxRepository
    {
        private readonly DataContext context;
        public TaxRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Tax> CreateTaxAsync(TaxVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Tax
            {
                TaxId = model.taxId,
                TaxName = model.taxName,
                TaxValue = model.taxValue,
            };

            var persistance = context.Tax.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Tax();
        }

        public async Task<bool> DeleteTax(int taxId)
        {
            var exist = await context.Tax.FindAsync(taxId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Tax.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<TaxVM> GetTax(int taxId, int tenantId)
        {
            return await (from x in context.Tax
                          where x.TaxId == taxId
                                && x.TenantId == tenantId
                          select new TaxVM
                          {
                              taxId = x.TaxId,
                              taxName = x.TaxName,
                              taxValue = x.TaxValue,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TaxVM>> GetTax(int tenantId)
        {
            return await (from x in context.Tax
                          where x.TenantId == tenantId
                          select new TaxVM
                          {
                              taxId = x.TaxId,
                              taxName = x.TaxName,
                              taxValue = x.TaxValue,

                          }).OrderBy(o => o.taxId).ToListAsync();
        }

        public async Task<IEnumerable<TaxVM>> GetTaxById(int taxId, int tenantId)
        {
            return await (from x in context.Tax
                          where x.TenantId == tenantId
                          select new TaxVM
                          {
                              taxId = x.TaxId,
                              taxName = x.TaxName,
                              taxValue = x.TaxValue,

                          }).OrderBy(o => o.taxId).ToListAsync();
        }

        public async Task<bool> UpdateTax(int taxId, TaxVM model)
        {
            var record = await context.Tax.FindAsync(taxId);

            if (record == null) throw new Exception("No Record Found!");

            record.TaxId = model.taxId;
            record.TaxName = model.taxName;
            record.TaxValue = model.taxValue;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






