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
    public class TenantRepository : ITenantRepository
    {
        private readonly DataContext context;
        public TenantRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Tenant> CreateTenantAsync(TenantVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Tenant
            {
                TenantId = model.tenantId,
                Name = model.name,
                ShortName = model.shortName,
                Address = model.address,
                StateId = model.stateId,
                LocalGovtId = model.localGovtId,
                YearOfEstablishment = model.yearOfEstablishment,
                ContactNumber = model.contactNumber,
                Email = model.email,
                WebAddress = model.webAddress,
                CompanyMotto = model.companyMotto,
                ContactPerson = model.contactPerson,
                ContactPersonPhone = model.contactPersonPhone,
                ContactPersonEmail = model.contactPersonEmail,
                LogoData = model.logoData,
                BarLogoData = model.barLogoData,
                LogoName = model.logoName,
                LogoFileType = model.logoFileType,
                LogoFileExtention = model.logoFileExtention,
                BarLogoFileName = model.barLogoFileName,
                BarLogoFileType = model.barLogoFileType,
                BarLogoFileExtention = model.barLogoFileExtention,
                DateCreated = model.dateCreated,
            };

            var persistance = context.Tenant.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Tenant();
        }

        public async Task<bool> DeleteTenant(int tenantId)
        {
            var exist = await context.Tenant.FindAsync(tenantId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Tenant.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        
        public async Task<IEnumerable<TenantVM>> GetTenant()
        {
            return await (from x in context.Tenant
                          select new TenantVM
                          {
                              tenantId = x.TenantId,
                              name = x.Name,
                              shortName = x.ShortName,
                              address = x.Address,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              yearOfEstablishment = x.YearOfEstablishment,
                              contactNumber = x.ContactNumber,
                              email = x.Email,
                              webAddress = x.WebAddress,
                              companyMotto = x.CompanyMotto,
                              contactPerson = x.ContactPerson,
                              contactPersonPhone = x.ContactPersonPhone,
                              contactPersonEmail = x.ContactPersonEmail,
                              logoData = x.LogoData,
                              barLogoData = x.BarLogoData,
                              logoName = x.LogoName,
                              logoFileType = x.LogoFileType,
                              logoFileExtention = x.LogoFileExtention,
                              barLogoFileName = x.BarLogoFileName,
                              barLogoFileType = x.BarLogoFileType,
                              barLogoFileExtention = x.BarLogoFileExtention,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.tenantId).ToListAsync();
        }

        public async Task<IEnumerable<TenantVM>> GetTenantById(int tenantId)
        {
            return await (from x in context.Tenant
                          where x.TenantId == tenantId
                          select new TenantVM
                          {
                              tenantId = x.TenantId,
                              name = x.Name,
                              shortName = x.ShortName,
                              address = x.Address,
                              stateId = x.StateId,
                              localGovtId = x.LocalGovtId,
                              yearOfEstablishment = x.YearOfEstablishment,
                              contactNumber = x.ContactNumber,
                              email = x.Email,
                              webAddress = x.WebAddress,
                              companyMotto = x.CompanyMotto,
                              contactPerson = x.ContactPerson,
                              contactPersonPhone = x.ContactPersonPhone,
                              contactPersonEmail = x.ContactPersonEmail,
                              logoData = x.LogoData,
                              barLogoData = x.BarLogoData,
                              logoName = x.LogoName,
                              logoFileType = x.LogoFileType,
                              logoFileExtention = x.LogoFileExtention,
                              barLogoFileName = x.BarLogoFileName,
                              barLogoFileType = x.BarLogoFileType,
                              barLogoFileExtention = x.BarLogoFileExtention,
                              dateCreated = x.DateCreated,

                          }).OrderBy(o => o.tenantId).ToListAsync();
        }

        public async Task<bool> UpdateTenant(int tenantId, TenantVM model)
        {
            var record = await context.Tenant.FindAsync(tenantId);

            if (record == null) throw new Exception("No Record Found!");

            record.TenantId = model.tenantId;
            record.Name = model.name;
            record.ShortName = model.shortName;
            record.Address = model.address;
            record.StateId = model.stateId;
            record.LocalGovtId = model.localGovtId;
            record.YearOfEstablishment = model.yearOfEstablishment;
            record.ContactNumber = model.contactNumber;
            record.Email = model.email;
            record.WebAddress = model.webAddress;
            record.CompanyMotto = model.companyMotto;
            record.ContactPerson = model.contactPerson;
            record.ContactPersonPhone = model.contactPersonPhone;
            record.ContactPersonEmail = model.contactPersonEmail;
            record.LogoData = model.logoData;
            record.BarLogoData = model.barLogoData;
            record.LogoName = model.logoName;
            record.LogoFileType = model.logoFileType;
            record.LogoFileExtention = model.logoFileExtention;
            record.BarLogoFileName = model.barLogoFileName;
            record.BarLogoFileType = model.barLogoFileType;
            record.BarLogoFileExtention = model.barLogoFileExtention;
            record.DateCreated = model.dateCreated;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






