namespace MissionPlanner.GCSViews.NavigationLights
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class NavigationLights : Form
    {
        public Lighting Lighting { get; private set; }
        
        public NavigationLights ( Lighting lighting )
        {
            InitializeComponent( );
            
            Location = Screen.AllScreens[ 0 ].Bounds.Location;
            StartPosition = FormStartPosition.CenterScreen;

            Lighting = lighting;

            if ( lighting.IsOn )
            {
                btnOff.Enabled = true;

                var isLightingConstant = lighting.LightingType == ELightingType.Constant;
                btnLight.Enabled = !isLightingConstant;
                btnFlicker.Enabled = isLightingConstant;
            }
            else
            {
                btnOff.Enabled = false;
                btnLight.Enabled = true;
                btnFlicker.Enabled = true;
            }
        }

        private void btnLight_Click ( object sender, EventArgs e )
        {
            try
            {
                MainV2.ComPort.doCommand( ( byte ) MainV2.ComPort.sysidcurrent, ( byte ) MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_RELAY, 0, 0, 0, 0, 0, 0, 0 );
                Lighting.IsOn = true;
                Lighting.LightingType = ELightingType.Constant;
                Lighting.Stop( );
            }
            catch ( Exception ex )
            {
                CustomMessageBox.Show( Strings.CommandFailed + ex.ToString( ), Strings.ERROR );
            }
            
            Close( );
        }

        private void btnFlicker_Click ( object sender, EventArgs e )
        {
            Lighting.IsOn = true;
            Lighting.LightingType = ELightingType.Flickering;

            Lighting.Start( );

            Close( );
        }

        private void btnOff_Click ( object sender, EventArgs e )
        {
            try
            {   
                MainV2.ComPort.doCommand( ( byte ) MainV2.ComPort.sysidcurrent, ( byte ) MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_RELAY, 0, 1, 0, 0, 0, 0, 0 );
                Lighting.IsOn = false;
                Lighting.LightingType = ELightingType.None;
                Lighting.Stop( );
            }
            catch ( Exception ex )
            {   
                CustomMessageBox.Show( Strings.CommandFailed + ex.ToString( ), Strings.ERROR );
            }

            Close( );
        }

        private void btnCancel_Click ( object sender, EventArgs e )
        {
            Close( );
        }
    }
}
