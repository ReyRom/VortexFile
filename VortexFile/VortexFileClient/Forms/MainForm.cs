namespace VortexFileClient.Forms;

public partial class MainForm : Form
{
    private Point mPoint;
    int mWidth;
    int mHeight;
    bool isMinimized=false;

    public MainForm()
    {
        InitializeComponent();
    }

    Stack<Form> forms = new Stack<Form>();

    private void MinimizeButton_Click(object sender, EventArgs e)
    {
        mWidth = this.Width;
        mHeight = this.Height;
        isMinimized = true;
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
        this.Size = new Size(BodyPanel.Width, BodyPanel.Height + HeadPanel.Height + FooterPanel.Height);
    }

    public void LoadForm(Form form) 
    {
        forms.Push(form);
        Extensions.FormTools.FormToPanel(form, BodyPanel);
        HeaderLabel.Text = form.Text;
        BackButton.Visible = forms.Count > 1;
    }

    public void GoBack()
    {
        forms.Pop().Dispose();
        Form form = forms.Peek();
        Extensions.FormTools.FormToPanel(form, BodyPanel);
        HeaderLabel.Text = form.Text;
        BackButton.Visible = forms.Count > 1;
    }

    private void HeaderLabel_MouseDown(object sender, MouseEventArgs e)
    {
        mPoint = new Point(e.X, e.Y);
    }

    private void HeaderLabel_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
        }
    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
        LoadForm(new UserGuideForm());
    }

    private void MainForm_SizeChanged(object sender, EventArgs e)
    {
        if (isMinimized)
        {
            this.Height = mHeight;
            this.Width = mWidth;
            isMinimized = false;
        }
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        GoBack();
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
        LoadForm(new SettingsForm());
    }
}
