
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.HUDs.Views
{
    public partial class HudView : Form
    {
        private bool _showed;

        public static HudView This { get; set; }

        public bool Showed 
        { 
            get => _showed;
            set
            {
                _showed = value;

                if ( value )
                {
                    ShowOn( );
                    ShowOff( );
                }
            }
        }

        public HudView()
        {
            This = this;

            if ( Screen.AllScreens.Length > 1 )
            {
                Location = Screen.AllScreens[ 1 ].Bounds.Location;
            }

            InitializeComponent( );
            //hud.Hide( );
            lblNoSignal.Show( );
        }

        public void ShowOn( )
        {
            lblNoSignal.Hide( );
            //hud.Show( );
        }

        public void ShowOff( )
        {
           // hud.Hide( );
            lblNoSignal.Show( );
        }
    }
}
