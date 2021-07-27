using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.Messages
{
    public partial class MessageForm : Form
    {
        private int messageCount;

        public MessageForm ( )
        {
            InitializeComponent( );
            timer.Start( );
        }

        private void timer_Tick ( object sender, EventArgs e )
        {
            var newmsgcount = MainV2.ComPort.MAV.cs.messages.Count;
            if ( messageCount != newmsgcount )
            {
                try
                {
                    StringBuilder message = new StringBuilder( );
                    MainV2.ComPort.MAV.cs.messages.ForEach( x =>
                    {
                        message.Insert( 0, x.Item1 + " : " + x.Item2 + "\r\n" );
                    } );
                    tbMessages.Text = message.ToString( );

                    messageCount = newmsgcount;
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        private void MessageForm_FormClosed ( object sender, FormClosedEventArgs e )
        {
            timer.Stop( );
        }
    }
}
