using Microsoft.EntityFrameworkCore;
using VortexFileClient.Data.Models;

namespace VortexFileClient.Data
{
    public class VortexFileMySqlContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public VortexFileMySqlContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(
                "server=25.36.141.142;user=proftpd;password=password;database=ftp;"
            );
        }
    }
}
