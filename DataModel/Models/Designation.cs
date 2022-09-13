namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Designation")]
    public partial class Designation
    {
        public int DesignationId { get; set; }

        [StringLength(100)]
        public string DesignationName { get; set; }

        public int? TenantId { get; set; }
    }
}
