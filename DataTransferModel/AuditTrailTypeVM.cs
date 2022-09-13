


namespace Data.TransferObject.ViewModel
{

public class AuditTrailTypeVM
{
	public int auditTrailTypeId { get; set; }
	public string module { get; set; }
	public string auditTrailTypeName { get; set; }
	public int? tenantId { get; set; }
        public int createdBy { get; set; }
    }

}

     
