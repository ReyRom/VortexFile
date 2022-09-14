namespace VortexFileClient.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MinimizeButton_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
