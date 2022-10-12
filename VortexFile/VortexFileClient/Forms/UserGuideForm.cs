using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class UserGuideForm : Form, IStackableForm
    {
        public UserGuideForm()
        {
            InitializeComponent();
        }

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;
    }
}
