


namespace Data.TransferObject.ViewModel
{

public class PurchaseReceiptRegisterDetailVM
{
	public int purchaseReceiptRegisterDetailId { get; set; }
	public int? purchaseReceiptRegisterId { get; set; }
	public int? bookId { get; set; }
	public string parkSize { get; set; }
	public string lotNumber { get; set; }
	public int? quantity { get; set; }
	public decimal? purchaseRate { get; set; }
	public decimal? saleRate { get; set; }
	public int? supplyStatusId { get; set; }
	public int? storeId { get; set; }
	public int? minQuantityToAlert { get; set; }
	public int? tenantId { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public bool? isAvailable { get; set; }
	public int? createdBy { get; set; }
        public string status { get; set; }
        public string bookTitle { get; set; }
    }

}

     
