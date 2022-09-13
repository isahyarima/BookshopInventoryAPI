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
    public class DocumentUploadRepository : IDocumentUploadRepository
    {
        private readonly DataContext context;
        public DocumentUploadRepository(DataContext _context)
        {
            context = _context;
        }

        public async Task<DocumentUpload> CreateDocumentUploadAsync(DocumentUploadVM model)
        {
            if (model == null) throw new Exception("No Entry Made!");

            var record = new DocumentUpload
            {
                DocumentUploadId = model.documentUploadId,
                DocumentTypeId = model.documentTypeId,
                FileName = model.fileName,
                FileType = model.fileType,
                FileExtention = model.fileExtention,
                FileLink = model.fileLink,
                FileData = model.fileData,
                TargetId = model.targetId,
                Description = model.description,
                TenantId = model.tenantId,
            };

            var persistance = context.DocumentUpload.Add(record);

            if (await context.SaveChangesAsync() > 0) return persistance;

            return new DocumentUpload();
        }

        public async Task<bool> DeleteDocumentUpload(int documentUploadId)
        {
            var exist = await context.DocumentUpload.FindAsync(documentUploadId);

            if (exist == null) throw new Exception("No Record Found!");

            context.DocumentUpload.Remove(exist);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<DocumentUploadVM> GetDocumentUpload(int documentUploadId, int tenantId)
        {
            return await (from x in context.DocumentUpload
                          where x.DocumentUploadId == documentUploadId
                                && x.TenantId == tenantId
                          select new DocumentUploadVM
                          {
                              documentUploadId = x.DocumentUploadId,
                              documentTypeId = x.DocumentTypeId,
                              fileName = x.FileName,
                              fileType = x.FileType,
                              fileExtention = x.FileExtention,
                              fileLink = x.FileLink,
                              fileData = x.FileData,
                              targetId = x.TargetId,
                              description = x.Description,
                              tenantId = x.TenantId,

                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DocumentUploadVM>> GetDocumentUpload(int tenantId)
        {
            return await (from x in context.DocumentUpload
                          where x.TenantId == tenantId
                        //  && x.DocumentUploadId == documentUploadId
                          select new DocumentUploadVM
                          {
                              documentUploadId = x.DocumentUploadId,
                              documentTypeId = x.DocumentTypeId,
                              fileName = x.FileName,
                              fileType = x.FileType,
                              fileExtention = x.FileExtention,
                              fileLink = x.FileLink,
                              fileData = x.FileData,
                              targetId = x.TargetId,
                              description = x.Description,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.documentUploadId).ToListAsync();
        }

        public async Task<IEnumerable<DocumentUploadVM>> GetDocumentUploadById(int documentUploadId, int tenantId)
        {
            return await (from x in context.DocumentUpload
                          where x.TenantId == tenantId
                          select new DocumentUploadVM
                          {
                              documentUploadId = x.DocumentUploadId,
                              documentTypeId = x.DocumentTypeId,
                              fileName = x.FileName,
                              fileType = x.FileType,
                              fileExtention = x.FileExtention,
                              fileLink = x.FileLink,
                              fileData = x.FileData,
                              targetId = x.TargetId,
                              description = x.Description,
                              tenantId = x.TenantId,

                          }).OrderBy(o => o.documentUploadId).ToListAsync();
        }

        public async Task<bool> UpdateDocumentUpload(int documentUploadId, DocumentUploadVM model)
        {
            var record = await context.DocumentUpload.FindAsync(documentUploadId);

            if (record == null) throw new Exception("No Record Found!");

            record.DocumentUploadId = model.documentUploadId;
            record.DocumentTypeId = model.documentTypeId;
            record.FileName = model.fileName;
            record.FileType = model.fileType;
            record.FileExtention = model.fileExtention;
            record.FileLink = model.fileLink;
            record.FileData = model.fileData;
            record.TargetId = model.targetId;
            record.Description = model.description;
            record.TenantId = model.tenantId;

            return await context.SaveChangesAsync() > 0;
        }
    }
}






