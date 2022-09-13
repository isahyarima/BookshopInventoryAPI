namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public int? TotalPage { get; set; }

        [StringLength(50)]
        public string YearOfPublish { get; set; }

        [StringLength(50)]
        public string Edition { get; set; }

        public int? PublisherId { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? TenantId { get; set; }
    }
}
