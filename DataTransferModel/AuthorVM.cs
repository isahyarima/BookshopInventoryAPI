


namespace Data.TransferObject.ViewModel
{

public class AuthorVM
{
	public int authorId { get; set; }
	public string firstName { get; set; }
	public string lastName { get; set; }
	public System.DateTime? dateOfBirth { get; set; }
	public string bioURL { get; set; }
	public string initial { get; set; }
	public string contact { get; set; }
	public string phoneNumber { get; set; }
	public string emailAddress { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public int? countryId { get; set; }
	public int? stateId { get; set; }
	public int? localGovtId { get; set; }
	public string country { get; set; }
	public System.DateTime? dateCreated { get; set; }
	public int? tenantId { get; set; }
        public int createdBy { get; set; }
        public string name { get; set; }
    }

}

     
