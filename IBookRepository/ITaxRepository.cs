using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ITaxRepository
    {
        Task<Tax> CreateTaxAsync(TaxVM model);

        Task<TaxVM> GetTax(int taxId, int tenantId);

        Task<IEnumerable<TaxVM>> GetTax(int tenantId);

		 Task<IEnumerable<TaxVM>> GetTaxById(int taxId,int tenantId);

        Task<bool> UpdateTax(int taxId, TaxVM model);

        Task<bool> DeleteTax(int taxId);
    }
}



     
