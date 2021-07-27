using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.TabMenus.Views.Tabs
{
    public enum EResult
    {
        Ok,
        Cancel
    }

    public partial class MapEditTab : TabItem
    {
        public EResult Result { get; set; }

        public bool FlyToPointVisible
        {
            get => lblFlyToPoint.Visible;
            set => lblFlyToPoint.Visible = value;
        }

        public MapEditTab ( )
        {
            InitializeComponent( );
        }

        private void BtnOk_Click ( object sender, EventArgs e )
        {
            Result = EResult.Ok;
        }

        private void BtnCancel_Click ( object sender, EventArgs e )
        {
            Result = EResult.Cancel;
        }
    }
}
