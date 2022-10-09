using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public interface IStackableForm
    {
        event EventHandler<LoadFormEventArgs> LoadForm;
        event EventHandler GoBack;
        public string Text { get; set; }
        public void Dispose();
    }
}
