using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface ITitleRepository
    {
        Task<Title> CreateTitleAsync(TitleVM model);

        Task<TitleVM> GetTitle(int titleId, int tenantId);

        Task<IEnumerable<TitleVM>> GetTitle(int tenantId);

		 Task<IEnumerable<TitleVM>> GetTitleById(int titleId,int tenantId);

        Task<bool> UpdateTitle(int titleId, TitleVM model);

        Task<bool> DeleteTitle(int titleId);
    }
}



     
