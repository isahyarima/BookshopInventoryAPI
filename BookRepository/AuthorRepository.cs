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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext context;
        public AuthorRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Author> CreateAuthorAsync(AuthorVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Author
            {
                AuthorId = model.authorId,
                FirstName = model.firstName,
                LastName = model.lastName,
                DateOfBirth = model.dateOfBirth,
                BioURL = model.bioURL,
                Initial = model.initial,
                Contact = model.contact,
                PhoneNumber = model.phoneNumber,
                EmailAddress = model.emailAddress,
                City = model.city,
                State = model.state,
                CountryId = model.countryId,
                StateId = model.stateId,
                LocalGovtId = model.localGovtId,
                Country = model.country,
                DateCreated = DateTime.Now,
                TenantId = model.tenantId,
            };

            var persistance = context.Author.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Author();
        }

        public async Task<bool> DeleteAuthor(int authorId)
        {
            var exist = await context.Author.FindAsync(authorId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Author.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<AuthorVM> GetAuthor(int authorId, int tenantId)
        {
            return await (from x in context.Author
                          where x.AuthorId == authorId
                                && x.TenantId == tenantId
                          select new AuthorVM
                          {
                              authorId = x.AuthorId,
                              name = x.FirstName + " " + x.LastName,
                              firstName = x.FirstName,
                              lastName = x.LastName,
                              dateOfBirth = x.DateOfBirth,
                              bioURL = x.BioURL,
                              initial = x.Initial,
                              contact = x.Contact,
                              phoneNumber = x.PhoneNumber,
                              emailAddress = x.EmailAddress,
                              city = x.City,
                              state = x.State,
                              countryId = x.CountryId,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              country = x.Country,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AuthorVM>> GetAuthor(int tenantId)
        {
            return await (from x in context.Author
                          where x.TenantId == tenantId
                         // && x.AuthorId == authorId
                          select new AuthorVM
                          {
                              name = x.FirstName + " " + x.LastName,
                              authorId = x.AuthorId,
                              firstName = x.FirstName,
                              lastName = x.LastName,
                              dateOfBirth = x.DateOfBirth,
                              bioURL = x.BioURL,
                              initial = x.Initial,
                              contact = x.Contact,
                              phoneNumber = x.PhoneNumber,
                              emailAddress = x.EmailAddress,
                              city = x.City,
                              state = x.State,
                              countryId = x.CountryId,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              country = x.Country,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.authorId).ToListAsync();
        }

        public async Task<IEnumerable<AuthorVM>> GetAuthorById(int authorId, int tenantId)
        {
            return await (from x in context.Author
                          where x.TenantId == tenantId
                          select new AuthorVM
                          {
                              authorId = x.AuthorId,
                              name = x.FirstName + " " + x.LastName,
                              firstName = x.FirstName,
                              lastName = x.LastName,
                              dateOfBirth = x.DateOfBirth,
                              bioURL = x.BioURL,
                              initial = x.Initial,
                              contact = x.Contact,
                              phoneNumber = x.PhoneNumber,
                              emailAddress = x.EmailAddress,
                              city = x.City,
                              state = x.State,
                              countryId = x.CountryId,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              country = x.Country,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.authorId).ToListAsync();
        }

        public async Task<bool> UpdateAuthor(int authorId, AuthorVM model)
        {
            var record = await context.Author.FindAsync(authorId);

            if (record == null) throw new Exception("No Record Found!");

            record.FirstName = model.firstName;
            record.LastName = model.lastName;
            record.DateOfBirth = model.dateOfBirth;
            record.BioURL = model.bioURL;
            record.Initial = model.initial;
            record.Contact = model.contact;
            record.PhoneNumber = model.phoneNumber;
            record.EmailAddress = model.emailAddress;
            record.City = model.city;
            record.State = model.state;
            record.CountryId = model.countryId;
            record.StateId = model.stateId;
            record.LocalGovtId = model.localGovtId;
            record.Country = model.country;
            record.DateCreated = DateTime.Now;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






