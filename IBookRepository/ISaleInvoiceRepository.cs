using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ISaleInvoiceRepository
    {
        Task<SaleInvoice> CreateSaleInvoiceAsync(SaleInvoiceVM model);

        Task<SaleInvoiceVM> GetSaleInvoice(int saleInvoiceId, int tenantId);

        Task<IEnumerable<SaleInvoiceVM>> GetSaleInvoice(int tenantId);

		 Task<IEnumerable<SaleInvoiceVM>> GetSaleInvoiceById(int saleInvoiceId,int tenantId);

        Task<bool> UpdateSaleInvoice(int saleInvoiceId, SaleInvoiceVM model);

        Task<bool> DeleteSaleInvoice(int saleInvoiceId);
    }
}



     
