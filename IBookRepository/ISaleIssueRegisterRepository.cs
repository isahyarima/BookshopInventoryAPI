using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ISaleIssueRegisterRepository
    {
        Task<SaleIssueRegister> CreateSaleIssueRegisterAsync(SaleIssueRegisterVM model);

        Task<SaleIssueRegisterVM> GetSaleIssueRegister(int saleIssueRegisterId, int tenantId);

        Task<IEnumerable<SaleIssueRegisterVM>> GetSaleIssueRegister(int tenantId);

		 Task<IEnumerable<SaleIssueRegisterVM>> GetSaleIssueRegisterById(int saleIssueRegisterId,int tenantId);

        Task<bool> UpdateSaleIssueRegister(int saleIssueRegisterId, SaleIssueRegisterVM model);

        Task<bool> DeleteSaleIssueRegister(int saleIssueRegisterId);
    }
}



     
