


namespace Data.TransferObject.ViewModel
{

public class SaleInvoiceDetailVM
{
	public int saleInvoiceDetailId { get; set; }
	public int? saleInvoiceId { get; set; }
	public int? bookId { get; set; }
	public string parkSize { get; set; }
	public string lotNumber { get; set; }
	public int? quantity { get; set; }
	public decimal? basicRate { get; set; }
	public decimal? purchaseRate { get; set; }
	public decimal? saleRate { get; set; }
	public decimal? mRP { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createdBy { get; set; }
        public string status { get; set; }
    }

}

     
