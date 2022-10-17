using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VortexFileClient.Extensions
{
    public partial class PasswordStrengthIndicator : UserControl
    {
        string password = String.Empty;
        public string Password 
        {
            get { return password; }
            set
            {
                password = value;
                this.Value = GetPasswordDifficult(password??String.Empty);
            }
        }

        int value = 0;
        private int Value 
        {
            get { return value; }
            set
            {
                this.value = value;
                RenewImage();
            }
        }
        public PasswordStrengthIndicator()
        {
            InitializeComponent();
        }

        public void RenewImage()
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            Brush brush;
            switch (Value)
            {
                case 3:
                    brush = new SolidBrush(Color.FromArgb(0, 204, 0));
                    toolTip.SetToolTip(pictureBox, "Надежный");
                    break;
                case 2:
                    brush = new SolidBrush(Color.FromArgb(255, 221, 56));
                    toolTip.SetToolTip(pictureBox, "Нормальный");
                    break;
                case 1:
                    brush = new SolidBrush(Color.FromArgb(255, 56, 56));
                    toolTip.SetToolTip(pictureBox, "Слишком простой");
                    break;
                default:
                    brush = new SolidBrush(Color.White);
                    toolTip.RemoveAll();
                    break;

            }
            g.FillRectangle(brush, new Rectangle(pictureBox.Location, new Size((pictureBox.Width / 3) * Value, pictureBox.Height)));
            pictureBox.Image = bitmap;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RenewImage();
        }



        private string[] passwords = { "qwerty", "12345", "йцукен", "password", "admin", "zxcvb", "987654321", "ytrewq", "bvcxz", "пароль" };

        private int GetPasswordDifficult(string password)
        {
            if (password.Length == 0)
            {
                return 0;
            }
            int difficult = 0;
            difficult += (int)(password.Length*0.9);
            if (Regex.IsMatch(password, @"[a-zа-яё]"))
            {
                difficult += 5;
            }
            else { difficult -= 3; }
            if (Regex.IsMatch(password, @"[A-ZА-ЯЁ]"))
            {
                difficult += 5;
            }
            else { difficult -= 3; }
            if (Regex.IsMatch(password, @"[0-9]"))
            {
                difficult += 5;
            }
            else { difficult -= 3; }
            if (Regex.IsMatch(password, @"(.)\1{3,}") )
            {
                difficult -= 10;
            }
            foreach (var item in passwords)
            {
                difficult -= password.ToLower().Contains(item) ? 10 : 0;
            }
            if (!Regex.IsMatch(password, @"^[a-zA-ZА-Яа-яЁё0-9]{8,20}$"))
            {
                difficult = 0;
            }
            if (difficult >= 20)
            {
                return 3;
            }
            if (difficult > 10)
            {
                return 2;
            }
            return 1;
        }
    }
}
