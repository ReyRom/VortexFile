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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.gid).HasDefaultValue();
            modelBuilder.Entity<User>().Property(u => u.uid).HasDefaultValue();
            modelBuilder.Entity<User>().Property(u => u.shell).HasDefaultValue();
            modelBuilder.Entity<User>().Property(u => u.count).HasDefaultValue();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Properties.Settings.Default.ConnectionString
                //"server=91.122.211.144;port=53306;user=proftpd;password=password;database=ftp;"
            );
        }
    }
}
