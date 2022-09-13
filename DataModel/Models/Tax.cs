namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tax")]
    public partial class Tax
    {
        public int TaxId { get; set; }

        [StringLength(50)]
        public string TaxName { get; set; }

        public double? TaxValue { get; set; }

        public int? TenantId { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
