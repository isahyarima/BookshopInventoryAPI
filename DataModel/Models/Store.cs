namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Store")]
    public partial class Store
    {
        public int StoreId { get; set; }

        [StringLength(50)]
        public string StoreName { get; set; }

        [StringLength(50)]
        public string StoreNumber { get; set; }

        [StringLength(500)]
        public string StoreAddress { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }

        public int? TenantId { get; set; }

        public bool? IsActive { get; set; }
    }
}
