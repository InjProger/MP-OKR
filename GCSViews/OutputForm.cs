using Microsoft.Scripting.Utils;

using System.Windows.Forms;

namespace MissionPlanner.GCSViews
{
    public partial class OutputForm : Form
    {
        public static OutputForm Instance { get; set; }

        public RichTextBox RtbOutput => rtbOutput;

        public OutputForm( )
        {
            Instance = this;
            InitializeComponent( );
        }

        private static OutputForm CreateAndShowMessageWindow ()
        {
            Instance = Instance ?? new OutputForm( );
            Instance.Show( );

            return Instance;
        }

        public static void ShowMessage( string message = "" )
        {
            CreateAndShowMessageWindow( ).RtbOutput.AppendText( $"{message}\n" );
        }

        public static void ShowMessage( string[] message )
        {
            CreateAndShowMessageWindow( ).RtbOutput.Lines.AddRange( message );
        }

        public static void ClearMessages( )
        {
            CreateAndShowMessageWindow( ).RtbOutput.Clear( );
        }
    }
}
