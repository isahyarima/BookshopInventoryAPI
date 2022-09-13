namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentUpload")]
    public partial class DocumentUpload
    {
        public int DocumentUploadId { get; set; }

        public int? DocumentTypeId { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string FileType { get; set; }

        [StringLength(50)]
        public string FileExtention { get; set; }

        [StringLength(500)]
        public string FileLink { get; set; }

        public byte[] FileData { get; set; }

        public int? TargetId { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? TenantId { get; set; }
    }
}
