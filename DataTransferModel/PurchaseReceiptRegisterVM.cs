


namespace Data.TransferObject.ViewModel
{

public class PurchaseReceiptRegisterVM
{
	public int purchaseReceiptRegisterId { get; set; }
	public int? supplierId { get; set; }
	public int? purchaseOrderId { get; set; }
	public string goodReceiptNoteNumber { get; set; }
	public System.DateTime? receiptDate { get; set; }
	public System.DateTime? receiptTime { get; set; }
	public string transportCompany { get; set; }
	public string vehicleNumber { get; set; }
	public string driverName { get; set; }
	public int? receiptStatusId { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createdBy { get; set; }
        public string status { get; set; }
        public string bookTitle { get; set; }
    }

}

     
