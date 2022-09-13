namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(500)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public string Address { get; set; }

        public int? TenantId { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
