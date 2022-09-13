namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SupplyStatus
    {
        public int SupplyStatusId { get; set; }

        [StringLength(50)]
        public string SupplyStatusName { get; set; }

        public int? TenantId { get; set; }
    }
}
