


namespace Data.TransferObject.ViewModel
{

public class EmployeeVM
{
	public int employeeId { get; set; }
	public string firstName { get; set; }
	public string middleName { get; set; }
	public string lastName { get; set; }
	public string gender { get; set; }
	public System.DateTime dateOfBirth { get; set; }
	public System.DateTime? creationDate { get; set; }
	public int? createrUserId { get; set; }
	public bool isDeleted { get; set; }
	public System.DateTime? deletionDate { get; set; }
	public int? deleterUserId { get; set; }
	public bool isApproved { get; set; }
	public System.DateTime? approveDate { get; set; }
	public int? approverUserId { get; set; }
	public int statusId { get; set; }
	public int stateId { get; set; }
	public int localGovtId { get; set; }
	public int? tenantId { get; set; }
	public int nationaliltyId { get; set; }
	public string email { get; set; }
	public string homeAddress { get; set; }
	public string phoneNumber { get; set; }
	public int? designationId { get; set; }
	public string employeeNumber { get; set; }
	public int? titleId { get; set; }

		public int createdBy { get; set; }
	}

}

     
