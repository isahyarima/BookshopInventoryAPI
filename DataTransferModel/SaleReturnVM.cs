


namespace Data.TransferObject.ViewModel
{

public class SaleReturnVM
{
	public int saleReturnId { get; set; }
	public int? customerId { get; set; }
	public int? taxId { get; set; }
	public string returnNumber { get; set; }
	public System.DateTime? returnDate { get; set; }
	public int? paymentId { get; set; }
	public System.DateTime? dateRegistered { get; set; }
	public int? tenantId { get; set; }
	public int? createdBy { get; set; }
        public string status { get; set; }
    }

}

     
