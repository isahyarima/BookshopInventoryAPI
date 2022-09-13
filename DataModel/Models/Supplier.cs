namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        public int SupplierId { get; set; }

        [StringLength(200)]
        public string SupplierName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(200)]
        public string EmailAddress { get; set; }
    }
}
