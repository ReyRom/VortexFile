using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Extensions
{
    public class FilesChangedEventArgs:EventArgs
    {
        public FilesChangedEventArgs(bool local = true, bool remote = true)
        {
            ChangedLocal = local;
            ChangedRemote = remote;
        }

        public bool ChangedLocal { get; set; }
        public bool ChangedRemote { get; set; }

    }
}
