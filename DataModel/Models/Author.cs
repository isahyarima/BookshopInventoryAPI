namespace DataModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        public int AuthorId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(500)]
        public string BioURL { get; set; }

        [StringLength(50)]
        public string Initial { get; set; }

        [StringLength(500)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        public int? LocalGovtId { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? TenantId { get; set; }
    }
}
