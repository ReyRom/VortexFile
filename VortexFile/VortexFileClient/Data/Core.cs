using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Data
{
    public static class Core
    {
        static VortexFileMySqlContext context;
        public static VortexFileMySqlContext Context { get { return context ??= new VortexFileMySqlContext(); } }
    }
}
