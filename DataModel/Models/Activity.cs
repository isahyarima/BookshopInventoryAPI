namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int ActivityId { get; set; }

        public int ActivityTypeId { get; set; }

        [StringLength(200)]
        public string ActivityName { get; set; }

        public int? TenantId { get; set; }

        [StringLength(50)]
        public string ActivityLabel { get; set; }

        public int? DepartmentId { get; set; }

        public bool? IsActive { get; set; }
    }
}
