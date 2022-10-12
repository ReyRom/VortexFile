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
                "server=91.122.211.144;port=53306;;user=proftpd;password=password;database=ftp;"
            );
        }
    }
}
