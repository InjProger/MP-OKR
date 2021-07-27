using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigHWIDs : MyUserControl, IActivate
    {
        public ConfigHWIDs()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            if (!MainV2.ComPort.BaseStream.IsOpen)
            {
                Enabled = false;
            }
            Enabled = true;

            var list = MainV2.ComPort.MAV.param.Where(a => a.Name.Contains("_ID"))
                .Select((a, b) => new DeviceInfo(b, a.Name, (uint) a.Value))
                .OrderBy((a) => a.ParamName).ToList();

            var bs = new BindingSource();
            bs.DataSource = list;
            myDataGridView1.DataSource = bs;
        }

    }
}