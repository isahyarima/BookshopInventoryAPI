using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrder> CreatePurchaseOrderAsync(PurchaseOrderVM model);

        Task<PurchaseOrderVM> GetPurchaseOrder(int purchaseOrderId, int tenantId);

        Task<IEnumerable<PurchaseOrderVM>> GetPurchaseOrder(int tenantId);

		 Task<IEnumerable<PurchaseOrderVM>> GetPurchaseOrderById(int purchaseOrderId,int tenantId);

        Task<bool> UpdatePurchaseOrder(int purchaseOrderId, PurchaseOrderVM model);

        Task<bool> DeletePurchaseOrder(int purchaseOrderId);

        Task<IEnumerable<PurchaseOrderVM>> SearchPurchaseOrderAsync(PurchaseOrderVM model);
    }
}



     
