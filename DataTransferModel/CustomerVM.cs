


namespace Data.TransferObject.ViewModel
{

public class CustomerVM
{
	public int customerId { get; set; }
	public string customerName { get; set; }
	public string phoneNumber { get; set; }
	public string email { get; set; }
	public string address { get; set; }
	public int? tenantId { get; set; }
	public System.DateTime? dateCreated { get; set; }

		public int createdBy { get; set; }
	}

}

     
