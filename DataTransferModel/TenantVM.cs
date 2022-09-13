


namespace Data.TransferObject.ViewModel
{

public class TenantVM
{
	public int tenantId { get; set; }
	public string name { get; set; }
	public string shortName { get; set; }
	public string address { get; set; }
	public int? stateId { get; set; }
	public int? localGovtId { get; set; }
	public string yearOfEstablishment { get; set; }
	public string contactNumber { get; set; }
	public string email { get; set; }
	public string webAddress { get; set; }
	public string companyMotto { get; set; }
	public string contactPerson { get; set; }
	public string contactPersonPhone { get; set; }
	public string contactPersonEmail { get; set; }
	public byte[] logoData { get; set; }
	public byte[] barLogoData { get; set; }
	public string logoName { get; set; }
	public string logoFileType { get; set; }
	public string logoFileExtention { get; set; }
	public string barLogoFileName { get; set; }
	public string barLogoFileType { get; set; }
	public string barLogoFileExtention { get; set; }
	public System.DateTime? dateCreated { get; set; }

		public int createdBy { get; set; }
	}

}

     
