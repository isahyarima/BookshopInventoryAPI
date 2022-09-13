namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseReceiptRegister")]
    public partial class PurchaseReceiptRegister
    {
        public int PurchaseReceiptRegisterId { get; set; }

        public int? SupplierId { get; set; }

        public int? PurchaseOrderId { get; set; }

        [StringLength(50)]
        public string GoodReceiptNoteNumber { get; set; }

        public DateTime? ReceiptDate { get; set; }

        public DateTime? ReceiptTime { get; set; }

        [StringLength(200)]
        public string TransportCompany { get; set; }

        [StringLength(50)]
        public string VehicleNumber { get; set; }

        [StringLength(200)]
        public string DriverName { get; set; }

        public int? ReceiptStatusId { get; set; }

        public int? StatusId { get; set; }

        public DateTime? DateRegistered { get; set; }

        public int? TenantId { get; set; }

        public int? CreatedBy { get; set; }
    }
}
