


namespace Data.TransferObject.ViewModel
{

public class SaleIssueRegisterVM
{
        public int createdBy;

        public int saleIssueRegisterId { get; set; }
	public int? customerId { get; set; }
	public string partyName { get; set; }
	public System.DateTime? issueDate { get; set; }
	public System.DateTime? issueTime { get; set; }
	public string documentNumber { get; set; }
	public int? issueStatusId { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createby { get; set; }
        public string status { get; set; }
    }

}

     
