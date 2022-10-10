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
    public partial class ColorProgressBar : ProgressBar
    {
        private int leftMargin = 2;

        private Color color = Color.Green;
        public Color Color { get => color; set => color = value; }

        public int LineWidth { get; set; }

        public ColorProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            if (Value == Maximum)
            {
                Value = 0;
            }
            leftMargin = Value * Width / Maximum - LineWidth + (Value*LineWidth/Maximum);
            rec.Width = LineWidth;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(new SolidBrush(Color), leftMargin, 2, rec.Width, rec.Height);
        }
    }
}
