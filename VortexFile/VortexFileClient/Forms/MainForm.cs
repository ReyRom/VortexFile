namespace VortexFileClient.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    Stack<Form> forms = new Stack<Form>();

    private void MinimizeButton_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = !Extensions.Feedback.QuestionMessage("Вы уверены, что хотите завершить сеанс?");
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadForm(new AuthorizationForm());
    }

    private void BodyPanel_Resize(object sender, EventArgs e)
    {
        this.Size = new Size(BodyPanel.Width, BodyPanel.Height + HeadPanel.Height);
    }

    public void LoadForm(Form form) 
    {
        forms.Push(form);
        Extensions.FormTools.FormToPanel(form, BodyPanel);
        HeaderLabel.Text = form.Text;
    }
}
