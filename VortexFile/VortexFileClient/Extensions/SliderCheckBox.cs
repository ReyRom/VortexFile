namespace VortexFileClient.Extensions
{
    public partial class SliderCheckBox : CheckBox
    {
        public SliderCheckBox()
        {
            InitializeComponent();
            ImageList imageList = new ImageList();
            imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList.TransparentColor = System.Drawing.Color.Transparent;
            imageList.ImageSize = new System.Drawing.Size(32, 14);
            imageList.Images.Add(Properties.Resources.Off);
            imageList.Images.Add(Properties.Resources.On);
            this.ImageList = imageList;
            this.ImageIndex = 0;
            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.AutoSize = true;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Location = new System.Drawing.Point(59, 163);
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UseVisualStyleBackColor = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            this.ImageIndex = this.Checked ? 1 : 0;
        }
    }
}
