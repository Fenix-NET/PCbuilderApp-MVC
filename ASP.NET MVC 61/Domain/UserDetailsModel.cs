using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserDetailsModel
    {
        public UserDetailsModel()
        {
            UserRoleModelList = new List<UserRoleModel>();
            AddressModel = new AddressModel();
        }

        public Int64 UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Int64? AddressId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public int? TotalRecords { get; set; }

        public List<UserRoleModel> UserRoleModelList { get; set; }
        public AddressModel AddressModel { get; set; }

    }
}
