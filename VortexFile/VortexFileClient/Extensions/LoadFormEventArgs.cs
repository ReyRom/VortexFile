using VortexFileClient.Forms;

namespace VortexFileClient.Extensions
{
    public class LoadFormEventArgs : EventArgs
    {
        public IStackableForm newForm;

        public LoadFormEventArgs(IStackableForm newForm)
        {
            this.newForm = newForm;
        }
    }
}
