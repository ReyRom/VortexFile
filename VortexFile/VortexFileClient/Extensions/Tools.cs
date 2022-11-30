namespace VortexFileClient.Extensions
{
    public static class Tools
    {
        public static long GigaByte { get => 1073741824; }
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
        public static int GetIndex(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return 5;//папка назад
            }
            if (fileName.Contains('/'))
            {
                return 0;
            }
            switch (Path.GetExtension(fileName).ToLower())
            {
                case ".zip":
                case ".rar":
                case ".7z":
                    return 6;//архив
                case ".jpg":
                case ".png":
                case ".bmp":
                case ".jpeg":
                case ".gif":
                    return 2;
                case ".mp3":
                case ".wav":
                    return 3;
                case ".mp4":
                case ".avi":
                case ".mkv":
                    return 4;
                default:
                    return 1;
            }
        }
    }
}
