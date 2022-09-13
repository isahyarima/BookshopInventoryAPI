using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ISaleReturnDetailRepository
    {
        Task<SaleReturnDetail> CreateSaleReturnDetailAsync(SaleReturnDetailVM model);

        Task<SaleReturnDetailVM> GetSaleReturnDetail(int saleReturnDetailId, int tenantId);

        Task<IEnumerable<SaleReturnDetailVM>> GetSaleReturnDetail(int tenantId);

		 Task<IEnumerable<SaleReturnDetailVM>> GetSaleReturnDetailById(int saleReturnDetailId,int tenantId);

        Task<bool> UpdateSaleReturnDetail(int saleReturnDetailId, SaleReturnDetailVM model);

        Task<bool> DeleteSaleReturnDetail(int saleReturnDetailId);
    }
}



     
