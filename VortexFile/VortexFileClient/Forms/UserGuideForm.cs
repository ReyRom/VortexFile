using System.Text;
using VortexFileClient.Data;
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

        private void UserGuideForm_Load(object sender, EventArgs e)
        {
        }
    }
}
