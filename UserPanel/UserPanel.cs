using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.UserPanel
{
    public partial class UserPanel : UserControl
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        void test()
        {
            MainV2.ComPort.doCommandAsync(MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid, 0, 0, 0, 0, 0, 0, 0, 0);
            MainV2.ComPort.doARMAsync(MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid, true);
            MainV2.ComPort.doCommandIntAsync(MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid, 0, 0, 0, 0, 0, 0, 0, 0);
            MainV2.ComPort.getParamList(MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid);
            MainV2.ComPort.getHeartBeatAsync();
            MainV2.ComPort.getVersionAsync(MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid);
            MainV2.ComPort.GetParamAsync(MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid);
        }
    }
}
