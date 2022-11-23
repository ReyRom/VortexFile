using System.ComponentModel.DataAnnotations.Schema;

namespace VortexFileClient.Data.Models
{
    public partial class User
    {
        public string hash { get; set; }
        public short uid { get; set; }
        public short gid { get; set; }
        public string homedir { get; set; }
        public string shell { get; set; }
        public int count { get; set; }
        public DateTime accessed { get; set; }
        public DateTime modified { get; set; }
    }
}
