


namespace Data.TransferObject.ViewModel
{

public class StoreVM
{
	public int storeId { get; set; }
	public string storeName { get; set; }
	public string storeNumber { get; set; }
	public string storeAddress { get; set; }
	public string contactNumber { get; set; }
	public int? tenantId { get; set; }
	public bool? isActive { get; set; }

		public int createdBy { get; set; }

	}

}

     
