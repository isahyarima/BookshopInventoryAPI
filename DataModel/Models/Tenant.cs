namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tenant")]
    public partial class Tenant
    {
        public int TenantId { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ShortName { get; set; }

        public string Address { get; set; }

        public int? StateId { get; set; }

        public int? LocalGovtId { get; set; }

        [StringLength(50)]
        public string YearOfEstablishment { get; set; }

        [StringLength(100)]
        public string ContactNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string WebAddress { get; set; }

        [StringLength(500)]
        public string CompanyMotto { get; set; }

        [StringLength(200)]
        public string ContactPerson { get; set; }

        [StringLength(100)]
        public string ContactPersonPhone { get; set; }

        [StringLength(50)]
        public string ContactPersonEmail { get; set; }

        public byte[] LogoData { get; set; }

        public byte[] BarLogoData { get; set; }

        [StringLength(200)]
        public string LogoName { get; set; }

        [StringLength(50)]
        public string LogoFileType { get; set; }

        [StringLength(50)]
        public string LogoFileExtention { get; set; }

        [StringLength(200)]
        public string BarLogoFileName { get; set; }

        [StringLength(50)]
        public string BarLogoFileType { get; set; }

        [StringLength(50)]
        public string BarLogoFileExtention { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
