namespace VortexFileClient;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        MessageBox.Show(Data.DAL.GetUserByLogin("D1pex")?.Email);
    }
}
