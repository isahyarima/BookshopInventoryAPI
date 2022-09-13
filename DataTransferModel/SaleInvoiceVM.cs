


namespace Data.TransferObject.ViewModel
{

public class SaleInvoiceVM
{
	public int saleInvoiceId { get; set; }
	public int? supplierId { get; set; }
	public int? taxId { get; set; }
	public string billNumber { get; set; }
	public System.DateTime? billDate { get; set; }
	public int? paymentId { get; set; }
	public string agent { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createdBy { get; set; }
        public string status { get; set; }
    }

}

     
