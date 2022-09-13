using Data.TransferObject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models;

namespace Interface
{
    public interface IDocumentUploadRepository
    {
        Task<DocumentUpload> CreateDocumentUploadAsync(DocumentUploadVM model);

        Task<DocumentUploadVM> GetDocumentUpload(int documentUploadId, int tenantId);

        Task<IEnumerable<DocumentUploadVM>> GetDocumentUpload(int tenantId);

		 Task<IEnumerable<DocumentUploadVM>> GetDocumentUploadById(int documentUploadId,int tenantId);

        Task<bool> UpdateDocumentUpload(int documentUploadId, DocumentUploadVM model);

        Task<bool> DeleteDocumentUpload(int documentUploadId);
    }
}



     
