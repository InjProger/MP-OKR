namespace MissionPlanner.Joystick.JoyRespond
{
    using MissionPlanner.GCSViews.ConfigurationView;
    using MissionPlanner.Utilities;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class JoyRespondForm : Form
    {
        public JoyRespondForm ( )
        {
            InitializeComponent( );

            Location = Screen.AllScreens[ 0 ].Bounds.Location;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnControl_Click ( object sender, EventArgs e )
        {
            Close( );
            new JoystickSetup( ).ShowUserControl( );
        }

        private void btnUav_Click ( object sender, EventArgs e )
        {
            Close( );
            new ConfigRadioInput( ).ShowUserControl( );
        }
    }
}
