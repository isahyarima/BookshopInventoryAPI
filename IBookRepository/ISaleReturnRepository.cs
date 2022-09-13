using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ISaleReturnRepository
    {
        Task<SaleReturn> CreateSaleReturnAsync(SaleReturnVM model);

        Task<SaleReturnVM> GetSaleReturn(int saleReturnId, int tenantId);

        Task<IEnumerable<SaleReturnVM>> GetSaleReturn(int tenantId);

		 Task<IEnumerable<SaleReturnVM>> GetSaleReturnById(int saleReturnId,int tenantId);

        Task<bool> UpdateSaleReturn(int saleReturnId, SaleReturnVM model);

        Task<bool> DeleteSaleReturn(int saleReturnId);
    }
}



     
