namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuditTrailType")]
    public partial class AuditTrailType
    {
        public int AuditTrailTypeId { get; set; }

        [StringLength(100)]
        public string Module { get; set; }

        [StringLength(100)]
        public string AuditTrailTypeName { get; set; }

        public int? TenantId { get; set; }
    }
}
