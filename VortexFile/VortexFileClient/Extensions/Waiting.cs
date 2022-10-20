namespace VortexFileClient.Extensions
{
    public partial class Waiting : UserControl
    {
        public Size ImageSize 
        {
            get => WaitingPictureBox.Size;
            set => WaitingPictureBox.Size = value; 
        }
        public Waiting()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            WaitingPictureBox.Location = new Point(this.Width / 2 - WaitingPictureBox.Width / 2, this.Height / 2 - WaitingPictureBox.Height / 2);
        }
    }
}
