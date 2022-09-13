namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleInvoice")]
    public partial class SaleInvoice
    {
        public int SaleInvoiceId { get; set; }

        public int? SupplierId { get; set; }

        public int? TaxId { get; set; }

        [StringLength(50)]
        public string BillNumber { get; set; }

        public DateTime? BillDate { get; set; }

        public int? PaymentId { get; set; }

        [StringLength(200)]
        public string Agent { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public int? CreatedBy { get; set; }

        public int? StatusId { get; set; }
    }
}
