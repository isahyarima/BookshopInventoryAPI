using Data.TransferObject.ViewModel;
using DataModel.Models;
using Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly DataContext context;
        public PublisherRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Publisher> CreatePublisherAsync(PublisherVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Publisher
            {
                PublisherId = model.publisherId,
                PublisherName = model.publisherName,
                Address = model.address,
                DateCreated = DateTime.Now,
                TenantId = model.tenantId,
            };

            var persistance = context.Publisher.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Publisher();
        }

        public async Task<bool> DeletePublisher(int publisherId)
        {
            var exist = await context.Publisher.FindAsync(publisherId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Publisher.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<PublisherVM> GetPublisher(int publisherId, int tenantId)
        {
            return await (from x in context.Publisher
                          where x.PublisherId == publisherId
                                && x.TenantId == tenantId
                          select new PublisherVM
                          {
                              publisherId = x.PublisherId,
                              publisherName = x.PublisherName,
                              address = x.Address,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PublisherVM>> GetPublisher(int tenantId)
        {
            return await (from x in context.Publisher
                          where x.TenantId == tenantId
                         // && x.PublisherId == publisherId
                          select new PublisherVM
                          {
                              publisherId = x.PublisherId,
                              publisherName = x.PublisherName,
                              address = x.Address,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.publisherId).ToListAsync();
        }

        public async Task<IEnumerable<PublisherVM>> GetPublisherById(int publisherId, int tenantId)
        {
            return await (from x in context.Publisher
                          where x.TenantId == tenantId
                          select new PublisherVM
                          {
                              publisherId = x.PublisherId,
                              publisherName = x.PublisherName,
                              address = x.Address,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.publisherId).ToListAsync();
        }

        public async Task<bool> UpdatePublisher(int publisherId, PublisherVM model)
        {
            var record = await context.Publisher.FindAsync(publisherId);

            if (record == null) throw new Exception("No Record Found!");

            record.PublisherName = model.publisherName;
            record.Address = model.address;
            record.DateCreated = DateTime.Now;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






