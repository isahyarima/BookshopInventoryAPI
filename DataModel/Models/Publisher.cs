namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publisher")]
    public partial class Publisher
    {
        public int PublisherId { get; set; }

        [StringLength(500)]
        public string PublisherName { get; set; }

        public string Address { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? TenantId { get; set; }
    }
}
