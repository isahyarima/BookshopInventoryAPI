namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrder")]
    public partial class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(50)]
        public string OrderNumber { get; set; }

        public DateTime? OrderValidDate { get; set; }

        public int? TaxId { get; set; }

        public int? StatusId { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public int? CreatedBy { get; set; }
    }
}
