namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Title")]
    public partial class Title
    {
        public int TitleId { get; set; }

        [StringLength(50)]
        public string TitleName { get; set; }

        public int? TenantId { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
