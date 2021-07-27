using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BrightIdeasSoftware;

using SharpDX;

namespace MissionPlanner.GCSViews
{
    public partial class FlightParamsForm : Form
    {
        //public FlightParamsResult FlightParamsResult { get; private set; }

        public FlightParamsForm()
        {
            InitializeComponent();
        }

        private void FlightParamsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FlightParamsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void cmbTargetLoadType_TextChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbTargetLoadType.SelectedIndex;

            switch (selectedItem)
            {
                
                default:
                    break;
            }
        }
    }
}
