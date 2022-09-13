namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bank")]
    public partial class Bank
    {
        public int BankId { get; set; }

        [StringLength(200)]
        public string BankName { get; set; }

        [StringLength(200)]
        public string AccountHolder { get; set; }

        [StringLength(200)]
        public string BranchName { get; set; }

        [StringLength(500)]
        public string BankAddress { get; set; }

        [StringLength(20)]
        public string AccountNumber { get; set; }

        public int? TenantId { get; set; }
    }
}
