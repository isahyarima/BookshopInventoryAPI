


namespace Data.TransferObject.ViewModel
{

public class LoginActivityVM
{
	public int loginActivityId { get; set; }
	public byte[] passwordHash { get; set; }
	public byte[] passwordSalt { get; set; }
	public bool isLocked { get; set; }
	public bool isActive { get; set; }
	public System.DateTime? lastLoginDate { get; set; }
	public System.DateTime creationDate { get; set; }
	public bool isDeleted { get; set; }
	public int? employeeTypeId { get; set; }
	public string userName { get; set; }
	public int? roleId { get; set; }
	public int? userId { get; set; }
	public int? loginTypeId { get; set; }
	public int? tenantId { get; set; }
	public bool? isPasswordReset { get; set; }
	public string confirmationId { get; set; }
	public System.DateTime? resetExpiryDate { get; set; }
	public bool? isOTPAvailable { get; set; }
	public System.DateTime? oPTExpirationDate { get; set; }
        public int createdBy { get; set; }


    }

}

     
