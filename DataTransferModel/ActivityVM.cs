


namespace Data.TransferObject.ViewModel
{

public class ActivityVM
{
	public int activityId { get; set; }
	public int activityTypeId { get; set; }
	public string activityName { get; set; }
	public int? tenantId { get; set; }
	public string activityLabel { get; set; }
	public int? departmentId { get; set; }
	public bool? isActive { get; set; }
        public int createdBy { get; set; }
    }

}

     
