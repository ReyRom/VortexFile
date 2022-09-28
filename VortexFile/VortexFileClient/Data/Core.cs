using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Data
{
    public static class Core
    {
        static VortexFileContext context;
        public static VortexFileContext Context { get { return context ??= new VortexFileContext(); } }
    }
}
