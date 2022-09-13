


namespace Data.TransferObject.ViewModel
{

public class DocumentUploadVM
{
	public int documentUploadId { get; set; }
	public int? documentTypeId { get; set; }
	public string fileName { get; set; }
	public string fileType { get; set; }
	public string fileExtention { get; set; }
	public string fileLink { get; set; }
	public byte[] fileData { get; set; }
	public int? targetId { get; set; }
	public string description { get; set; }
	public int? tenantId { get; set; }

		public int createdBy { get; set; }
	}

}

     
