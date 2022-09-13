using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ISaleInvoiceDetailRepository
    {
        Task<SaleInvoiceDetail> CreateSaleInvoiceDetailAsync(SaleInvoiceDetailVM model);

        Task<SaleInvoiceDetailVM> GetSaleInvoiceDetail(int saleInvoiceDetailId, int tenantId);

        Task<IEnumerable<SaleInvoiceDetailVM>> GetSaleInvoiceDetail(int tenantId);

		 Task<IEnumerable<SaleInvoiceDetailVM>> GetSaleInvoiceDetailById(int saleInvoiceDetailId,int tenantId);

        Task<bool> UpdateSaleInvoiceDetail(int saleInvoiceDetailId, SaleInvoiceDetailVM model);

        Task<bool> DeleteSaleInvoiceDetail(int saleInvoiceDetailId);
    }
}



     
