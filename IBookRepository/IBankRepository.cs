using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IBankRepository
    {
        Task<Bank> CreateBankAsync(BankVM model);

        Task<BankVM> GetBank(int bankId, int tenantId);

        Task<IEnumerable<BankVM>> GetBank(int tenantId);

		 Task<IEnumerable<BankVM>> GetBankById(int bankId,int tenantId);

        Task<bool> UpdateBank(int bankId, BankVM model);

        Task<bool> DeleteBank(int bankId);
    }
}



     
