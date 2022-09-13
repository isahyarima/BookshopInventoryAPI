namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Token")]
    public partial class Token
    {
        public int TokenId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(2000)]
        public string Value { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastModifiedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ExpiryTime { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public int? TenantId { get; set; }
    }
}
