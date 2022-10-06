using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexFileClient.Forms;

namespace VortexFileClient.Extensions
{
    public class LoadFormEventArgs: EventArgs
    {
        public IStackableForm newForm;

        public LoadFormEventArgs(IStackableForm newForm)
        {
            this.newForm = newForm;
        }
    }
}
