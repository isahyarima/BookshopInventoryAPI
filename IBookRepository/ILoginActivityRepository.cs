using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ILoginActivityRepository
    {
        Task<LoginActivity> CreateLoginActivityAsync(LoginActivityVM model);

        Task<LoginActivityVM> GetLoginActivity(int loginActivityId, int tenantId);

        Task<IEnumerable<LoginActivityVM>> GetLoginActivity(int tenantId);

		 Task<IEnumerable<LoginActivityVM>> GetLoginActivityById(int loginActivityId,int tenantId);

        Task<bool> UpdateLoginActivity(int loginActivityId, LoginActivityVM model);

        Task<bool> DeleteLoginActivity(int loginActivityId);
    }
}



     
