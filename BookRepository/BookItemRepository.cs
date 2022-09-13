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
    public class BookItemRepository : IBookItemRepository
    {
        private readonly DataContext context;
        public BookItemRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<Book> CreateBookAsync(BookVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new Book
            {
                BookId = model.bookId,
                BookTitle = model.bookTitle,
                TotalPage = model.totalPage,
                YearOfPublish = model.yearOfPublish,
                Edition = model.edition,
                PublisherId = model.publisherId,
                URL = model.uRL,
                CategoryId = model.categoryId,
                Language = model.language,
                Description = model.description,
                Barcode = model.barcode,
                DateCreated = DateTime.Now,
                TenantId = model.tenantId,
            };

            var persistance = context.Book.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new Book();
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            var exist = await context.Book.FindAsync(bookId);

            if (exist == null) throw new Exception("No Record Found!");

            context.Book.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<BookVM> GetBook(int bookId, int tenantId)
        {
            return await (from x in context.Book
                          where x.BookId == bookId
                                && x.TenantId == tenantId
                          select new BookVM
                          {
                              bookId = x.BookId,
                              bookTitle = x.BookTitle,
                              totalPage = x.TotalPage,
                              yearOfPublish = x.YearOfPublish,
                              edition = x.Edition,
                              publisherId = x.PublisherId,
                              publisherName = context.Publisher.Where(o=>o.PublisherId == x.PublisherId).Select(o=>o.PublisherName).FirstOrDefault(),
                              uRL = x.URL,
                              categoryId = x.CategoryId,
                              categoryName = context.Category.Where(o=>o.CategoryId == x.CategoryId).Select(o=>o.CategoryName).FirstOrDefault(),
                              language = x.Language,
                              description = x.Description,
                              barcode = x.Barcode,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookVM>> GetBook(int tenantId)
        {
            return await (from x in context.Book
                          where x.TenantId == tenantId
                        // && x.BookId == bookId
                          select new BookVM
                          {
                              bookId = x.BookId,
                              bookTitle = x.BookTitle,
                              totalPage = x.TotalPage,
                              yearOfPublish = x.YearOfPublish,
                              edition = x.Edition,
                              publisherId = x.PublisherId,
                              publisherName = context.Publisher.Where(o => o.PublisherId == x.PublisherId).Select(o => o.PublisherName).FirstOrDefault(),
                              uRL = x.URL,
                              categoryId = x.CategoryId,
                              categoryName = context.Category.Where(o => o.CategoryId == x.CategoryId).Select(o => o.CategoryName).FirstOrDefault(),
                              language = x.Language,
                              description = x.Description,
                              barcode = x.Barcode,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.bookId).ToListAsync();
        }

        public async Task<IEnumerable<BookVM>> GetBookById(int bookId, int tenantId)
        {
            return await (from x in context.Book
                          where x.TenantId == tenantId
                          select new BookVM
                          {
                              bookId = x.BookId,
                              bookTitle = x.BookTitle,
                              totalPage = x.TotalPage,
                              yearOfPublish = x.YearOfPublish,
                              edition = x.Edition,
                              publisherId = x.PublisherId,
                              publisherName = context.Publisher.Where(o => o.PublisherId == x.PublisherId).Select(o => o.PublisherName).FirstOrDefault(),
                              uRL = x.URL,
                              categoryId = x.CategoryId,
                              categoryName = context.Category.Where(o => o.CategoryId == x.CategoryId).Select(o => o.CategoryName).FirstOrDefault(),
                              language = x.Language,
                              description = x.Description,
                              barcode = x.Barcode,
                              dateCreated = x.DateCreated,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.bookId).ToListAsync();
        }

        public async Task<bool> UpdateBook(int bookId, BookVM model)
        {
            var record = await context.Book.FindAsync(bookId);

            if (record == null) throw new Exception("No Record Found!");

            record.BookTitle = model.bookTitle;
            record.TotalPage = model.totalPage;
            record.YearOfPublish = model.yearOfPublish;
            record.Edition = model.edition;
            record.PublisherId = model.publisherId;
            record.URL = model.uRL;
            record.CategoryId = model.categoryId;
            record.Language = model.language;
            record.Description = model.description;
            record.Barcode = model.barcode;
            record.DateCreated = DateTime.Now;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






