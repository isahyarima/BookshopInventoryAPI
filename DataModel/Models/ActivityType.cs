namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivityType")]
    public partial class ActivityType
    {
        public int ActivityTypeId { get; set; }

        [StringLength(200)]
        public string ActivityTypeName { get; set; }

        public int? TenantId { get; set; }
    }
}
