namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginActivity")]
    public partial class LoginActivity
    {
        public int LoginActivityId { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool IsLocked { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastLoginDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }

        public int? EmployeeTypeId { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        public int? RoleId { get; set; }

        public int? UserId { get; set; }

        public int? LoginTypeId { get; set; }

        public int? TenantId { get; set; }

        public bool? IsPasswordReset { get; set; }

        [StringLength(200)]
        public string ConfirmationId { get; set; }

        public DateTime? ResetExpiryDate { get; set; }

        public bool? IsOTPAvailable { get; set; }

        public DateTime? OPTExpirationDate { get; set; }
    }
}
