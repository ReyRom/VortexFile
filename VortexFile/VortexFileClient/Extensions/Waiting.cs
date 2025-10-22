namespace VortexFileClient.Extensions
{
    public partial class Waiting : UserControl
    {
        int imageSize = 100;
        public int ImageSize 
        {
            get => imageSize;
            set 
            {
                imageSize = value; 
                WaitingPictureBox.Size = new Size(this.Width*imageSize/100, this.Height*imageSize/100);
            } 
        }
        public Waiting()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            WaitingPictureBox.Location = new Point(this.Width / 2 - WaitingPictureBox.Width / 2, this.Height / 2 - WaitingPictureBox.Height / 2);
            WaitingPictureBox.Size = new Size(this.Width * imageSize / 100, this.Height * imageSize / 100);
        }
    }
}
