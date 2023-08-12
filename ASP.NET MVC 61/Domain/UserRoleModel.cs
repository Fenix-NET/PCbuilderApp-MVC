using System;

namespace Domain
{
    public class UserRoleModel
    {
        public UserRoleModel()
        {
            UserDetailsModel = new UserDetailsModel();
        }

        public Int64 UserRoleId { get; set; }
        public string? Role { get; set; }
        public Int64? UserId { get; set; }

        public UserDetailsModel UserDetailsModel { get; set; }
    }
}
