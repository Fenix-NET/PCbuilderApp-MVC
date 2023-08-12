using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DemoDB
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Bigint")]
        public Int64 AddressId { get; set; }

        [Column(TypeName = "Nvarchar(200)")]
        public string? HouseOfficeNo { get; set; }

        [Column(TypeName = "Nvarchar(500)")]
        public string? Street1 { get; set; }

        [Column(TypeName = "Nvarchar(500)")]
        public string? Street2 { get; set; }

        [Column(TypeName = "Nvarchar(200)")]
        public string? Country { get; set; }

        [Column(TypeName = "Nvarchar(200)")]
        public string? State { get; set; }

        [Column(TypeName = "Nvarchar(200)")]
        public string? City { get; set; }

        [Column(TypeName = "Bigint")]
        public Int64? ZipCode { get; set; }



        public UserDetails? UserDetails { get; set; }

    }
}
