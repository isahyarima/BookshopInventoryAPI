


namespace Data.TransferObject.ViewModel
{

public class TaxVM
{
	public int taxId { get; set; }
	public string taxName { get; set; }
	public double? taxValue { get; set; }
        public int createdBy
        {
            get; set;
        }
        public int tenantId { get; set; }
    }

}

     
