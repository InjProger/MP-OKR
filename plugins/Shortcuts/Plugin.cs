using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MissionPlanner.Utilities;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MissionPlanner;

namespace Shortcuts
{
    public class Plugin : MissionPlanner.Plugin.Plugin
    {
       
        public override string Name
        {
            get { return "Shortcuts"; }
        }

        public override string Version
        {
            get { return "0.1"; }
        }

        public override string Author
        {
            get { return "Michael Oborne"; }
        }

        //[DebuggerHidden]
        public override bool Init()
        {
            MainV2.instance.ProcessCmdKeyCallback += this.Instance_ProcessCmdKeyCallback;

            return true;
        }

        private bool Instance_ProcessCmdKeyCallback(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.A))
            {
                MainV2.ComPort.setMode("Auto");
                return true;
            }
            if (keyData == (Keys.Alt | Keys.G))
            {
                MainV2.ComPort.setMode("Loiter");
                return true;
            }
            if (keyData == (Keys.Alt | Keys.U))
            {
                MainV2.ComPort.setMode("AltHold");
                return true;
            }
            if (keyData == (Keys.Alt | Keys.S))
            {
                MainV2.ComPort.setMode("Stabalize");
                return true;
            }
            if (keyData == (Keys.Alt | Keys.H))
            {
                MainV2.ComPort.setMode("RTL");
                return true;
            }

            if (keyData == (Keys.Alt | Keys.T))
            {
                MainV2.ComPort.doCommand((byte)MainV2.ComPort.sysidcurrent, (byte)MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.TAKEOFF, 0, 0, 0, 0, 0, 0, 2);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.L))
            {
                MainV2.ComPort.doCommand((byte)MainV2.ComPort.sysidcurrent, (byte)MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.LAND, 0, 0, 0, 0, 0, 0, 0);
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D0))
            {
                MainV2.ComPort.SendRCOverride(MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid, 0, 0, 1000, 0, 0, 0,
                    0, 0);
                return true;
            }

            if (keyData == (Keys.Alt | Keys.F1))
            {
                //MainV2.comPort.doCommand((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_SERVO, 1, MainV2.comPort.MAV., 0, 0, 0, 0, 0, true);
                return true;
            }

            return false;
        }

        public override bool Loaded()
        {
            return true;
        }

        public override bool Loop()
        {
            return true;
        }

        public override bool Exit()
        {
            return true;
        }
    }
}
