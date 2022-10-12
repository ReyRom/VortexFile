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
            byte[] bytes = Enumerable.Range(0, 32).Select(x => (byte)x).ToArray();
            using (FileStream fs = new FileStream("D:\\test.txt", FileMode.OpenOrCreate))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (StreamWriter sr = new StreamWriter(ms))
                    {
                        sr.WriteLine("Привет");
                        ms.EncryptStream(fs, bytes);
                    }
                }
            }

            MessageBox.Show(File.ReadAllText("D:\\test.txt"));
            using (FileStream fs = new FileStream("D:\\test.txt", FileMode.Open))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    fs.DecryptStream(stream, bytes);
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        MessageBox.Show(sr.ReadToEnd());
                    }
                }
            }
        }
    }
}
