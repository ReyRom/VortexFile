using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Data.Models
{
    public partial class User
    {
        public short uid { get; set; }
        public short gid { get; set; }
        public string homedir { get; set; }
        public string shell { get; set; }
        public int count { get; set; }
        public DateTime accessed { get; set; }
        public DateTime modified { get; set; }
    }
}
