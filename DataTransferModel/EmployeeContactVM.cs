


namespace Data.TransferObject.ViewModel
{

public class EmployeeContactVM
{
	public int employeeContactId { get; set; }
	public string email { get; set; }
	public string homeAddress { get; set; }
	public string phoneNumber { get; set; }
	public int employeeId { get; set; }
	public int? tenantId { get; set; }

		public int createdBy { get; set; }
	}

}

     
