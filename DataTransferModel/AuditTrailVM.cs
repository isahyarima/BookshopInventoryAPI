


namespace Data.TransferObject.ViewModel
{

public class AuditTrailVM
{
	public int auditTrailId { get; set; }
	public int? auditTrailTypeId { get; set; }
	public string actionMethod { get; set; }
	public string description { get; set; }
	public string url { get; set; }
	public int? actionById { get; set; }
	public string iP { get; set; }
	public int? targetId { get; set; }
	public int? tenantId { get; set; }
	public System.DateTime? dateCreated { get; set; }

		public int createdBy { get; set; }
	}

}

     
