using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IPurchaseReceiptRegisterRepository
    {
        Task<PurchaseReceiptRegister> CreatePurchaseReceiptRegisterAsync(PurchaseReceiptRegisterVM model);

        Task<PurchaseReceiptRegisterVM> GetPurchaseReceiptRegister(int purchaseReceiptRegisterId, int tenantId);

        Task<IEnumerable<PurchaseReceiptRegisterVM>> GetPurchaseReceiptRegister(int tenantId);

		 Task<IEnumerable<PurchaseReceiptRegisterVM>> GetPurchaseReceiptRegisterById(int purchaseReceiptRegisterId,int tenantId);

        Task<bool> UpdatePurchaseReceiptRegister(int purchaseReceiptRegisterId, PurchaseReceiptRegisterVM model);

        Task<bool> DeletePurchaseReceiptRegister(int purchaseReceiptRegisterId);
    }
}



     
