namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseReturn")]
    public partial class PurchaseReturn
    {
        public int PurchaseReturnId { get; set; }

        public int? SupplierId { get; set; }

        public int? TaxId { get; set; }

        [StringLength(50)]
        public string ReturnNumber { get; set; }

        public int? PurchaseOrderId { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? PaymentId { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public int? CreatedBy { get; set; }

        public int? StatusId { get; set; }
    }
}
