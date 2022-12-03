using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
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
            optionsBuilder.UseMySQL(Properties.Settings.Default.ConnectionString);
        }
    }
}
