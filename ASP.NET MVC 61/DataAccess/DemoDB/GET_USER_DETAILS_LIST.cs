using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DemoDB
{
    [NotMapped]
    public class GET_USER_DETAILS_LIST
    {
        public Int64 UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Int64? AddressId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public int? TotalRecordsCount { get; set; }

    }
}
