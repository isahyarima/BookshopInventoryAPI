


namespace Data.TransferObject.ViewModel
{

public class SupplierVM
{
	public int supplierId { get; set; }
	public string supplierName { get; set; }
	public string address { get; set; }
	public string phoneNumber { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public bool? isActive { get; set; }
	public string emailAddress { get; set; }

		public int createdBy { get; set; }
	}

}

     
