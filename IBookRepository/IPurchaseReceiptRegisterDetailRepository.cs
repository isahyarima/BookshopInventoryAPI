using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IPurchaseReceiptRegisterDetailRepository
    {
        Task<PurchaseReceiptRegisterDetail> CreatePurchaseReceiptRegisterDetailAsync(PurchaseReceiptRegisterDetailVM model);

        Task<PurchaseReceiptRegisterDetailVM> GetPurchaseReceiptRegisterDetail(int purchaseReceiptRegisterDetailId, int tenantId);

        Task<IEnumerable<PurchaseReceiptRegisterDetailVM>> GetPurchaseReceiptRegisterDetail(int tenantId);

		 Task<IEnumerable<PurchaseReceiptRegisterDetailVM>> GetPurchaseReceiptRegisterDetailById(int purchaseReceiptRegisterDetailId,int tenantId);

        Task<bool> UpdatePurchaseReceiptRegisterDetail(int purchaseReceiptRegisterDetailId, PurchaseReceiptRegisterDetailVM model);

        Task<bool> DeletePurchaseReceiptRegisterDetail(int purchaseReceiptRegisterDetailId);
    }
}



     
