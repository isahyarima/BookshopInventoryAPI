namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuditTrail")]
    public partial class AuditTrail
    {
        public int AuditTrailId { get; set; }

        public int? AuditTrailTypeId { get; set; }

        [StringLength(50)]
        public string ActionMethod { get; set; }

        public string Description { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        public int? ActionById { get; set; }

        [Required]
        [StringLength(50)]
        public string IP { get; set; }

        public int? TargetId { get; set; }

        public int? TenantId { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
