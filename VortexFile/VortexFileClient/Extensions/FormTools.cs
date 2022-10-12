namespace VortexFileClient.Extensions
{
    public static class FormTools
    {
        public static void FormToPanel(Form form, Panel panel)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(form);
            panel.Dock = DockStyle.Fill;
            panel.Size = new Size(form.Size.Width, form.Size.Height);
            form.Show();
        }
    }
}
