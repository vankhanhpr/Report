using ModelClass.auth;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ModelClassLibrary.connection
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }
       
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
