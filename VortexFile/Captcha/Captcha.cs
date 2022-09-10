using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Captcha
{
    public partial class Captcha: UserControl
    {
        private string text = String.Empty;
        public Captcha()
        {
            InitializeComponent();
            Renew();
        }
        public void Renew()
        {
            CaptchaPictureBox.Image = CreateImage(CaptchaPictureBox.Width, CaptchaPictureBox.Height);
        }
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];


            Font stringFont = new Font("Arial", 30);
            double textWidth;

            using (Bitmap tempImage = new Bitmap(400, 400))
            {
                SizeF stringSize = Graphics.FromImage(tempImage).MeasureString(text, stringFont);
                textWidth = stringSize.Width;
            }
            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - (int)textWidth - 15);
            int Ypos = rnd.Next(15, Height - 45);

            ///Линии из углов
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(Pens.LightGray,
                       new Point(0, 0),
                       new Point(Width - rnd.Next(Width), Height - 1));
            }
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(Pens.LightGray,
                       new Point(0, 0),
                       new Point(Width - 1, Height - rnd.Next(Height)));
            }

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 30),
                         Brushes.DimGray,
                         new PointF(Xpos, Ypos));

            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }
    }
}
