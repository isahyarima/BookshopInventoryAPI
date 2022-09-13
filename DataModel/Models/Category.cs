namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int CategoryId { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? TenantId { get; set; }
    }
}
