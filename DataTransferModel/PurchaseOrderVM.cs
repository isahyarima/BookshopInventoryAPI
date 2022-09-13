


namespace Data.TransferObject.ViewModel
{

public class PurchaseOrderVM
{
	public int purchaseOrderId { get; set; }
	public System.DateTime? orderDate { get; set; }
	public int? supplierId { get; set; }
	public string orderNumber { get; set; }
	public System.DateTime? orderValidDate { get; set; }
	public int? taxId { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createdBy { get; set; }
        public string tax { get; set; }
        public string supplierName { get; set; }
        public string status { get; set; }
    }

}

     
