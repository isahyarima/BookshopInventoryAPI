namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeContact")]
    public partial class EmployeeContact
    {
        public int EmployeeContactId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string HomeAddress { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int EmployeeId { get; set; }

        public int? TenantId { get; set; }
    }
}
