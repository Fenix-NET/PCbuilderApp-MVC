using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DemoDB
{
    [Table("UserDetails", Schema = "dbo")]
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Bigint")]
        public Int64 UserId { get; set; }

        [Column(TypeName = "Nvarchar(200)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "Nvarchar(200)")]
        public string? LastName { get; set; }

        [Column(TypeName = "Int")]
        public int? Gender { get; set; }

        [Column(TypeName = "Nvarchar(20)")]
        public string? Phone { get; set; }

        [Column(TypeName = "Nvarchar(100)")]
        public string? Email { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string? Password { get; set; }

        [Column(TypeName = "Bit")]
        public bool? IsActive { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? RegistrationDate { get; set; }



        [Column(TypeName = "Bigint")]
        public Int64? AddressId { get; set; }
        public Address? Address { get; set; }

        public ICollection<UserRole>? UserRoles { get; set; }
    }







}
