namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseReceiptRegisterDetail")]
    public partial class PurchaseReceiptRegisterDetail
    {
        public int PurchaseReceiptRegisterDetailId { get; set; }

        public int? PurchaseReceiptRegisterId { get; set; }

        public int? BookId { get; set; }

        [StringLength(50)]
        public string ParkSize { get; set; }

        [StringLength(50)]
        public string LotNumber { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? PurchaseRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? SaleRate { get; set; }

        public int? SupplyStatusId { get; set; }

        public int? StoreId { get; set; }

        public int? MinQuantityToAlert { get; set; }

        public int? StatusId { get; set; }

        public int? TenantId { get; set; }

        public DateTime? DateRegistered { get; set; }

        public bool? IsAvailable { get; set; }

        public int? CreatedBy { get; set; }
    }
}
