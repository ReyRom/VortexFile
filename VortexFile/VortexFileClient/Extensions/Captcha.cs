using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VortexFileClient.Extensions
{
    public partial class Captcha : UserControl
    {
        private string text = String.Empty;
        public Captcha()
        {
            InitializeComponent();
        }
        public void Renew()
        {
            CaptchaPictureBox.Image = CreateImage(this.Width, this.Height);
        }

        public bool CheckText(string text)
        {
            return text == this.text;
        }

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

            Bitmap result = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage((Image)result);

            g.Clear(Color.SkyBlue);

            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            Font stringFont = new Font("Consolas", 30);
            double textWidth;
            double textHeight;

            using (Bitmap tempImage = new Bitmap(400, 400))
            {
                SizeF stringSize = Graphics.FromImage(tempImage).MeasureString(text, stringFont);
                textWidth = stringSize.Width;
                textHeight = stringSize.Height;
            }

            int Xpos = rnd.Next(0, Width - (int)textWidth);
            int Ypos = rnd.Next(0, Height - (int)textHeight);

            //Линии
            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(Pens.CornflowerBlue,
                       new Point(0, 0),
                       new Point(Width - rnd.Next(Width), Height - 1));
            }
            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(Pens.CornflowerBlue,
                       new Point(0, 0),
                       new Point(Width - 1, Height - rnd.Next(Height)));
            }

            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(Pens.CornflowerBlue,
                       new Point(Width - 1, 0),
                       new Point(Width - rnd.Next(Width), Height - 1));
            }
            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(Pens.CornflowerBlue,
                       new Point(Width - 1, 0),
                       new Point(0, Height - rnd.Next(Height)));
            }

            //Текст
            Brush brush = new SolidBrush(Color.FromArgb(60, 179, 227));
            g.DrawString(text,
                         stringFont,
                         brush,
                         new PointF(Xpos, Ypos));

            //Точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.MidnightBlue);

            return result;
        }
    }
}
