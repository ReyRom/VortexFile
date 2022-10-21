namespace VortexFileClient.Extensions
{
    public static class Tools
    {
        public static long GigaByte { get => 8589934592; }
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
        public static string GenerateCode(int length)
        {
            string code = String.Empty;
            Random rnd = new Random();
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                code += ALF[rnd.Next(ALF.Length)];
            return code;
        }
    }
}
