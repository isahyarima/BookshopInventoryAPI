


namespace Data.TransferObject.ViewModel
{

public class BookVM
{
	public int bookId { get; set; }
	public string bookTitle { get; set; }
	public int? totalPage { get; set; }
	public string yearOfPublish { get; set; }
	public string edition { get; set; }
	public int? publisherId { get; set; }
	public string uRL { get; set; }
	public int? categoryId { get; set; }
	public string language { get; set; }
	public string description { get; set; }
	public string barcode { get; set; }
	public System.DateTime? dateCreated { get; set; }
	public int? tenantId { get; set; }

		public int createdBy { get; set; }
        public string publisherName { get; set; }
        public string categoryName { get; set; }
    }

}

     
