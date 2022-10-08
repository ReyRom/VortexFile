using VortexFileClient.Data;

namespace VortexFileClient.Extensions
{
    public partial class ConnectionIndicator : UserControl
    {
        public Image ConnectImage { get; set; }
        public Image DisconnectImage { get; set; }

        private bool IsConnected 
        { 
            set
            {
                if (value)
                {
                    toolTip.SetToolTip(pictureBox, "Подключено");
                    pictureBox.Image = ConnectImage;
                }
                else
                {
                    toolTip.SetToolTip(pictureBox, "Подключение отсутствует");
                    pictureBox.Image = DisconnectImage;
                }
            }
        }

        public int TimerInterval { get => timer.Interval; set => timer.Interval = value; }

        public ConnectionIndicator()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            StartChecking();
        }

        private async void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = Core.Context.Database.CanConnectAsync().Result;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            IsConnected = (bool)e.Result;
        }

        private void ConnectionIndicator_Load(object sender, EventArgs e)
        {
            IsConnected = false;
            StartChecking();
            timer.Start();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            StartChecking();
        }

        private void StartChecking()
        {
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }
    }
}
