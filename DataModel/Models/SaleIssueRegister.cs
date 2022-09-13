namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleIssueRegister")]
    public partial class SaleIssueRegister
    {
        public int SaleIssueRegisterId { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(50)]
        public string PartyName { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? IssueTime { get; set; }

        [StringLength(50)]
        public string DocumentNumber { get; set; }

        public int? IssueStatusId { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public int? Createby { get; set; }

        public int? StatusId { get; set; }
    }
}
