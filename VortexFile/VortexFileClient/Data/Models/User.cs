#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace VortexFileClient.Data.Models
{
    [Table("vortexfileuser")]
    public partial class User
    {
        [Key]
        [Column("id")]
        public int IdUser { get; set; }
        [Column("userid")]
        public string Login { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("passwd")]
        public string Password { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("phone")]
        public string Phone { get; set; }

        public IDbAsyncEnumerator GetAsyncEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}