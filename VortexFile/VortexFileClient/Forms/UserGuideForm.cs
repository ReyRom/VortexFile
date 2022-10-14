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
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
            using (FileStream fs = new FileStream("D:\\test.txt", FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.EncryptStream(ms, bytes);
                    File.WriteAllBytes("D:\\testE.txt", ms.ToArray());
                }
            }

            using (FileStream fs = new FileStream("D:\\testE.txt", FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    fs.DecryptStream(stream, bytes);
                    stream.Position = 0;
                    File.WriteAllBytes("D:\\testD.txt", stream.ToArray());
                }
            }
        }
    }
}
