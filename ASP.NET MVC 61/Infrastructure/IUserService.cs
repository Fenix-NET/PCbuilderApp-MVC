using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUserService
    {
        UserDetailsModel AddEditUserDetails(UserDetailsModel userDetailsModel);
        List<UserDetailsModel> GetUserDetailList(string search, int startIndex, int displayLength, int sortColumnIndex, string sortDirection, ref int recordsTotal);
        UserDetailsModel GetUserDetailsById(Int64 userId);
        UserDetailsModel? GetUserDetailsEmailPassword(string email, string password);
        bool DeleteUserDetailsById(long userId);



    }

}
