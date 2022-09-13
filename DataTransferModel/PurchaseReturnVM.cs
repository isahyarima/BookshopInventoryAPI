


namespace Data.TransferObject.ViewModel
{

public class PurchaseReturnVM
{
	public int purchaseReturnId { get; set; }
	public int? supplierId { get; set; }
	public int? taxId { get; set; }
	public string returnNumber { get; set; }
	public int? purchaseOrderId { get; set; }
	public System.DateTime? returnDate { get; set; }
	public int? paymentId { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createdBy { get; set; }
        public string status { get; set; }
    }

}

     
