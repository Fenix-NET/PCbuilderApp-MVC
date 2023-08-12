using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DemoDB
{
    public class DemoDBContext : DbContext
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options)
            : base(options)
        {

        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Address> Address { get; set; }


        #region SP_Dbsets
        private DbSet<GET_USER_DETAILS_LIST> GET_USER_DETAILS_LIST { get; set; }
        #endregion

        #region View
        //public DbSet<VW_Sample_View> VW_Sample_View { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("dbo");


            #region TableMapping
            //Map entity to table
            modelBuilder.Entity<UserDetails>().ToTable("UserDetails");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<Address>().ToTable("Address");
            #endregion


            #region ForeignKeyMapping
            //One to many reletionship
            modelBuilder.Entity<UserRole>().HasOne(x => x.UserDetails).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);

            //One to one reletionship
            modelBuilder.Entity<UserDetails>().HasOne(x => x.Address).WithOne(x => x.UserDetails).HasForeignKey<UserDetails>(x => x.AddressId).OnDelete(DeleteBehavior.SetNull);
            #endregion


            #region ViewMapping
            //Map entity to view
            //modelBuilder.Entity<VW_Sample_View>().HasNoKey().ToView("VW_Sample_View", schema: "dbo");
            #endregion


            #region TableValuedFunction
            //Map entity to Table-valued function
            //modelBuilder.Entity<SampleDBFuncation>().HasNoKey().ToFunction("SampleDBFuncation");
            #endregion

            #region StoredProceduresEntity
            modelBuilder.Entity<GET_USER_DETAILS_LIST>().HasNoKey().ToTable("GET_USER_DETAILS_LIST", x => x.ExcludeFromMigrations());
            #endregion

        }


        #region StoredProcedureMapping
        public List<GET_USER_DETAILS_LIST> SP_GET_USER_DETAILS_LIST(int? pageNum, int? pageSize, string search, string sortDirection, int? sortColumnIndex)
        {
            string query = "EXECUTE [dbo].[SP_GET_USER_DETAILS_LIST] ";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@PageNum", pageNum));
            sqlParameters.Add(new SqlParameter("@PageSize", pageSize));
            sqlParameters.Add(new SqlParameter("@Search", search ?? ""));
            sqlParameters.Add(new SqlParameter("@SortDirection", sortDirection));
            sqlParameters.Add(new SqlParameter("@SortColumnIndex", sortColumnIndex));

            for (int i = 0; i < sqlParameters.Count(); i++)
            {
                query += sqlParameters[i].ParameterName;
                query += ",";
            }
            var result = this.GET_USER_DETAILS_LIST.FromSqlRaw(query.TrimEnd(','), sqlParameters.ToArray()).ToList();
            return result;
        }

        #endregion



    }
}
