


namespace Data.TransferObject.ViewModel
{

public class PurchaseOrderDetailVM
{
	public int purchaseOrderDetailId { get; set; }
	public int? purchaseOrderId { get; set; }
	public int? bookId { get; set; }
	public string parkSize { get; set; }
	public string lotNumber { get; set; }
	public int? quantity { get; set; }
	public decimal? costPrice { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createdBy { get; set; }
        public string bookTitle { get; set; }
        public string status { get; set; }
    }

}

     
