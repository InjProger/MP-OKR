using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigHWRangeFinder : MyUserControl, IActivate, IDeactivate
    {
        bool startup = true;

        public ConfigHWRangeFinder()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            if (!MainV2.ComPort.BaseStream.IsOpen)
            {
                Enabled = false;
                return;
            }
            Enabled = true;
            startup = true;

            CMB_sonartype.setup(
                ParameterMetaDataRepository.GetParameterOptionsInt("RNGFND_TYPE",
                    MainV2.ComPort.MAV.cs.firmware.ToString()), "RNGFND_TYPE", MainV2.ComPort.MAV.param);

            timer1.Start();

            startup = false;
        }

        public void Deactivate()
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LBL_dist.Text = MainV2.ComPort.MAV.cs.sonarrange.ToString();
            LBL_volt.Text = MainV2.ComPort.MAV.cs.sonarvoltage.ToString();
        }

        private void CMB_sonartype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startup)
                return;

            if (CMB_sonartype.Text == "TeraRangerOne-I2C")
            {
                // set min and max to 20cm - 10m
                MainV2.ComPort.setParam((byte)MainV2.ComPort.sysidcurrent, (byte)MainV2.ComPort.compidcurrent, "RNGFND_MAX_CM", 100);
                MainV2.ComPort.setParam((byte)MainV2.ComPort.sysidcurrent, (byte)MainV2.ComPort.compidcurrent, "RNGFND_MIN_CM ", 20);
            }
        }
    }
}