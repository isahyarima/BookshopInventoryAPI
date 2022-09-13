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
    public class TitleRepository : ITitleRepository
    {
        private readonly DataContext context;
        public TitleRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Title> CreateTitleAsync(TitleVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Title
            {
                TitleId = model.titleId,
                TitleName = model.titleName,
            };

            var persistance = context.Title.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Title();
        }

        public async Task<bool> DeleteTitle(int titleId)
        {
            var exist = await context.Title.FindAsync(titleId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Title.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<TitleVM> GetTitle(int titleId, int tenantId)
        {
            return await (from x in context.Title
                          where x.TitleId == titleId
                                && x.TenantId == tenantId
                          select new TitleVM
                          {
                              titleId = x.TitleId,
                              titleName = x.TitleName,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TitleVM>> GetTitle(int tenantId)
        {
            return await (from x in context.Title
                          where x.TenantId == tenantId
                         // && x.TitleId == titleId
                          select new TitleVM
                          {
                              titleId = x.TitleId,
                              titleName = x.TitleName,

                          }).OrderBy(o => o.titleId).ToListAsync();
        }

        public async Task<IEnumerable<TitleVM>> GetTitleById(int titleId, int tenantId)
        {
            return await (from x in context.Title
                          where x.TenantId == tenantId
                          select new TitleVM
                          {
                              titleId = x.TitleId,
                              titleName = x.TitleName,

                          }).OrderBy(o => o.titleId).ToListAsync();
        }

        public async Task<bool> UpdateTitle(int titleId, TitleVM model)
        {
            var record = await context.Title.FindAsync(titleId);

            if (record == null) throw new Exception("No Record Found!");

            record.TitleId = model.titleId;
            record.TitleName = model.titleName;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






