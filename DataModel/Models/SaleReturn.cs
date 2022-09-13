namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleReturn")]
    public partial class SaleReturn
    {
        public int SaleReturnId { get; set; }

        public int? CustomerId { get; set; }

        public int? TaxId { get; set; }

        [StringLength(50)]
        public string ReturnNumber { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? PaymentId { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public int? CreatedBy { get; set; }

        public int? StatusId { get; set; }
    }
}
