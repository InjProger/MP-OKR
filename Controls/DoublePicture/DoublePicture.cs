namespace MissionPlanner.Controls.DoublePicture
{
    using System.Windows.Forms;

    public partial class DoublePicture : UserControl
    {
        private bool _click;

        public new bool Click
        {
            get => _click;
            set
            {
                _click = value;

                pictureDown.Visible = _click;
                pictureUp.Visible = !_click;
            }
        }

        public DoublePicture ( )
        {
            InitializeComponent( );
        }
    }
}
