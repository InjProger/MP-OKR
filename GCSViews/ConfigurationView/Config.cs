using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent( );
            Location = Screen.AllScreens[ 0 ].Bounds.Location;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
