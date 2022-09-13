using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IPurchaseReturnDetailRepository
    {
        Task<PurchaseReturnDetail> CreatePurchaseReturnDetailAsync(PurchaseReturnDetailVM model);

        Task<PurchaseReturnDetailVM> GetPurchaseReturnDetail(int purchaseReturnDetailId, int tenantId);

        Task<IEnumerable<PurchaseReturnDetailVM>> GetPurchaseReturnDetail(int tenantId);

		 Task<IEnumerable<PurchaseReturnDetailVM>> GetPurchaseReturnDetailById(int purchaseReturnDetailId,int tenantId);

        Task<bool> UpdatePurchaseReturnDetail(int purchaseReturnDetailId, PurchaseReturnDetailVM model);

        Task<bool> DeletePurchaseReturnDetail(int purchaseReturnDetailId);
    }
}



     
