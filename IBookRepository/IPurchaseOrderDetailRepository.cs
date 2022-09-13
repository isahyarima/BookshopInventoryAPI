using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IPurchaseOrderDetailRepository
    {
        Task<PurchaseOrderDetail> CreatePurchaseOrderDetailAsync(PurchaseOrderDetailVM model);

      
        Task<IEnumerable<PurchaseOrderDetailVM>> GetPurchaseOrderDetail(int tenantId, int purchaseOrderId);

        Task<IEnumerable<PurchaseOrderDetailVM>> GetPurchaseOrderDetailById(int purchaseOrderDetailId,int tenantId);

        Task<bool> UpdatePurchaseOrderDetail(int purchaseOrderDetailId, PurchaseOrderDetailVM model);

        Task<bool> DeletePurchaseOrderDetail(int purchaseOrderDetailId);
    }
}



     
