namespace MissionPlanner.Controls.Buttons.ThreeStateButton
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

    public partial class ThreeButtonState : UserControl
    {
        public ThreeButtonState ( )
        {
            InitializeComponent( );
        }

        private void BtnBegState_Click ( object sender, EventArgs e )
        {
            btnBegState.Hide( );
            btnMidState.Show( );
        }

        private void BtnMidState_Click ( object sender, EventArgs e )
        {
            btnMidState.Hide( );
            btnEndState.Show( );
        }

        private void BtnEndState_Click ( object sender, EventArgs e )
        {
            btnEndState.Hide( );
            btnBegState.Show( );
        }
    }
}
