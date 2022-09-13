namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivitiesAssigned")]
    public partial class ActivitiesAssigned
    {
        public int ActivitiesAssignedId { get; set; }

        public int ActivityId { get; set; }

        public int RoleId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateTimeCreated { get; set; }

        public int? TenantId { get; set; }
    }
}
