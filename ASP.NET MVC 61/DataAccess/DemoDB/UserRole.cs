using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DemoDB
{
    [Table("UserRole", Schema = "dbo")]
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Bigint")]
        public Int64 UserRoleId { get; set; }

        [Column(TypeName = "Nvarchar(100)")]
        public string? Role { get; set; }


        [Column(TypeName = "Bigint")]
        public Int64? UserId { get; set; }
        public UserDetails? UserDetails { get; set; }


    }
}
