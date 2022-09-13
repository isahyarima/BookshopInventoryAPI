namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleInvoiceDetail")]
    public partial class SaleInvoiceDetail
    {
        public int SaleInvoiceDetailId { get; set; }

        public int? SaleInvoiceId { get; set; }

        public int? BookId { get; set; }

        [StringLength(50)]
        public string ParkSize { get; set; }

        [StringLength(50)]
        public string LotNumber { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasicRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? PurchaseRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? SaleRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? MRP { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public int? CreatedBy { get; set; }

        public int? StatusId { get; set; }
    }
}
