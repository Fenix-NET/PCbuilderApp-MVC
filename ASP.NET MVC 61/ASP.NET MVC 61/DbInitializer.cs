using DataAccess.DemoDB;

namespace ASP.NET_MVC_61
{
    public static class DbInitializer
    {
        public static void Initialize(DemoDBContext context)
        {
            // Look for any UserDetails.
            if (context.UserDetails.Any())
            {
                return;   // DB has been seeded
            }

            var userDetails = new UserDetails[]
            {
                new UserDetails{FirstName="FN",
                    LastName="LN",
                    Gender=(int)Utility.Enums.Gender.Male,
                    IsActive=true,
                    Email="email@email.com",
                    Password="password",
                    Phone="10010010000",
                    RegistrationDate=DateTime.Now,
                    Address=new Address(){
                        Country="Cnt",
                        State="st",
                        City="ct",
                        ZipCode=123,
                        HouseOfficeNo="",
                        Street1="",
                        Street2=""
                    },
                    UserRoles=new List<UserRole>()
                    {
                        new UserRole(){UserRoleId=(int)Utility.Enums.UserRoles.Employee}
                    }
                }
            };

            context.UserDetails.AddRange(userDetails);
            context.SaveChanges();
        }

    }
}
