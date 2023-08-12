using DataAccess.DemoDB;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly DemoDBContext DemoDBContext;
        public UserService(DemoDBContext DemoDBContext)
        {
            this.DemoDBContext = DemoDBContext;
        }


        #region User
        public UserDetailsModel AddEditUserDetails(UserDetailsModel userDetailsModel)
        {
            try
            {
                var tempUserDetails = DemoDBContext.UserDetails.Find(userDetailsModel.UserId);

                UserDetails userDetails = tempUserDetails == null ? new UserDetails() : tempUserDetails;
                userDetails.FirstName = userDetailsModel.FirstName;
                userDetails.LastName = userDetailsModel.LastName;
                userDetails.Gender = userDetailsModel.Gender;
                userDetails.Phone = userDetailsModel.Phone;
                userDetails.Email = userDetailsModel.Email;
                userDetails.AddressId = userDetailsModel.AddressId;
                userDetails.IsActive = userDetailsModel.IsActive;

                if (tempUserDetails == null)
                {
                    userDetails.RegistrationDate = DateTime.Now;
                    DemoDBContext.UserDetails.Add(userDetails);
                    DemoDBContext.SaveChanges();
                }
                else
                {
                    DemoDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ElmahCore.ElmahExtensions.RiseError(ex);
            }
            return userDetailsModel;
        }
        public List<UserDetailsModel> GetUserDetailList(string search, int startIndex, int displayLength, int sortColumnIndex, string sortDirection, ref int recordsTotal)
        {
            List<UserDetailsModel> userDetailsModelList = new List<UserDetailsModel>();
            try
            {

                userDetailsModelList = DemoDBContext.SP_GET_USER_DETAILS_LIST(startIndex, displayLength, search, sortDirection, sortColumnIndex)
                    .Select(x => new UserDetailsModel()
                    {
                        UserId = x.UserId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Phone = x.Phone,
                        Email = x.Email,
                        AddressId = x.AddressId,
                        Gender = x.Gender,
                        IsActive = x.IsActive,
                        RegistrationDate = x.RegistrationDate,
                        TotalRecords = x.TotalRecordsCount ?? 0
                    }).ToList();

                if (userDetailsModelList.Count > 0)
                    recordsTotal = userDetailsModelList[0].TotalRecords ?? 0;

            }
            catch (Exception ex)
            {
                ElmahCore.ElmahExtensions.RiseError(ex);
            }
            return userDetailsModelList;
        }
        public UserDetailsModel GetUserDetailsById(Int64 userId)
        {
            UserDetailsModel userDetailsModel = new UserDetailsModel();
            try
            {
                var data = DemoDBContext.UserDetails.Include(x => x.UserRoles).Include(x => x.Address).Where(x => x.UserId == userId).FirstOrDefault();
                if (data != null)
                {
                    userDetailsModel.UserId = data.UserId;
                    userDetailsModel.FirstName = data.FirstName;
                    userDetailsModel.LastName = data.LastName;
                    userDetailsModel.Phone = data.Phone;
                    userDetailsModel.Email = data.Email;
                    userDetailsModel.AddressId = data.AddressId;
                    userDetailsModel.Gender = data.Gender;
                    userDetailsModel.IsActive = data.IsActive;
                    userDetailsModel.RegistrationDate = data.RegistrationDate;
                }
            }
            catch (Exception ex)
            {
                ElmahCore.ElmahExtensions.RiseError(ex);
            }
            return userDetailsModel;
        }
        public UserDetailsModel? GetUserDetailsEmailPassword(string email, string password)
        {
            UserDetailsModel? userDetailsModel = null;
            try
            {
                var data = DemoDBContext.UserDetails.Include(x => x.UserRoles).Include(x => x.Address).Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                if (data != null)
                {
                    userDetailsModel = new UserDetailsModel();
                    userDetailsModel.UserId = data.UserId;
                    userDetailsModel.FirstName = data.FirstName;
                    userDetailsModel.LastName = data.LastName;
                    userDetailsModel.Phone = data.Phone;
                    userDetailsModel.Email = data.Email;
                    userDetailsModel.AddressId = data.AddressId;
                    userDetailsModel.Gender = data.Gender;
                    userDetailsModel.IsActive = data.IsActive;
                    userDetailsModel.RegistrationDate = data.RegistrationDate;
                    userDetailsModel.UserRoleModelList = data.UserRoles.Select(y => new UserRoleModel()
                    {
                        UserRoleId = y.UserRoleId,
                        UserId = y.UserId,
                        Role = y.Role
                    }).ToList();
                    userDetailsModel.AddressModel = new AddressModel()
                    {
                        AddressId = data.Address.AddressId,
                        HouseOfficeNo = data.Address.HouseOfficeNo,
                        Street1 = data.Address.Street1,
                        Street2 = data.Address.Street2,
                        Country = data.Address.Country,
                        State = data.Address.State,
                        City = data.Address.City,
                        ZipCode = data.Address.ZipCode
                    };
                }
            }
            catch (Exception ex)
            {
                ElmahCore.ElmahExtensions.RiseError(ex);
            }

            return userDetailsModel;
        }
        public bool DeleteUserDetailsById(long userId)
        {
            try
            {
                var data = DemoDBContext.UserDetails.Find(userId);
                if (data != null)
                {
                    DemoDBContext.UserDetails.Remove(data);
                    DemoDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ElmahCore.ElmahExtensions.RiseError(ex);
                return false;
            }

            return true;
        }
        #endregion



    }
}
