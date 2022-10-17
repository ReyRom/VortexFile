using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexFileClient.Data.Models;

namespace VortexFileClient.Extensions
{
    public class UserDeleteEventArgs : EventArgs
    {
        public UserDeleteEventArgs(User user)
        {
            User = user;
        }

        public User User { get; set; }

    }
}
