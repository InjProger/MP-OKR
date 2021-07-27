using Flurl.Util;

using Other.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.Dialogs.TBInputDlg
{
    public partial class TBInputDialog : Form
    {
        public TBInputDialog ( )
        {
            InitializeComponent( );
            CenterLabel( );
        }

        private void CenterLabel ( )
        {
            var clientCenter = ClientRectangle.CenterPoint( );

            lblValue.Left = ( int ) clientCenter.X - lblValue.Width / 2;
            btnOk.Left = ( int ) clientCenter.X - btnOk.Width / 2;
        }

        private void TrackBar_Scroll ( object sender, EventArgs e )
        {
            lblValue.Text = trackBar.Value.ToString( );
            CenterLabel( );
        }

        private void TBInputDialog_Resize ( object sender, EventArgs e )
        {
            CenterLabel( );
        }
    }
}
