namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreationDate { get; set; }

        public int? CreaterUserId { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeletionDate { get; set; }

        public int? DeleterUserId { get; set; }

        public bool IsApproved { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ApproveDate { get; set; }

        public int? ApproverUserId { get; set; }

        public int StatusId { get; set; }

        public int StateId { get; set; }

        public int LocalGovtId { get; set; }

        public int? TenantId { get; set; }

        public int NationaliltyId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string HomeAddress { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int? DesignationId { get; set; }

        [StringLength(50)]
        public string EmployeeNumber { get; set; }

        public int? TitleId { get; set; }
    }
}
