using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;


namespace Interface
{
    public interface IPublisherRepository
    {
        Task<Publisher> CreatePublisherAsync(PublisherVM model);

        Task<PublisherVM> GetPublisher(int publisherId, int tenantId);

        Task<IEnumerable<PublisherVM>> GetPublisher(int tenantId);

		 Task<IEnumerable<PublisherVM>> GetPublisherById(int publisherId,int tenantId);

        Task<bool> UpdatePublisher(int publisherId, PublisherVM model);

        Task<bool> DeletePublisher(int publisherId);
    }
}



     
