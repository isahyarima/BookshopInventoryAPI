namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public int RoleId { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        public int? EmployeeTypeId { get; set; }

        public int? RoleLevelAccressId { get; set; }

        public int? TenantId { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
