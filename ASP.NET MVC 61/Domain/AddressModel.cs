using System;
using System.Collections.Generic;

namespace Domain
{
    public class AddressModel
    {
        public AddressModel()
        {
            UserDetailsModelList = new List<UserDetailsModel>();
        }

        public Int64 AddressId { get; set; }
        public string? HouseOfficeNo { get; set; }
        public string? Street1 { get; set; }
        public string? Street2 { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public Int64? ZipCode { get; set; }


        public List<UserDetailsModel> UserDetailsModelList { get; set; }
    }
}
