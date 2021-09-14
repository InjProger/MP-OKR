namespace MissionPlanner.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class ShotThread
    {
        private bool _isLoop;
        private Thread _thread;

        /*private bool isFire1 = false;
        private bool isFire2 = false;*/

        public ShotThread ( )
        {
            _thread = new Thread( Loop );
        }

        private void Loop ( )
        {
            while ( _isLoop )
            {
                if ( MainV2.Joystick != null )
                {
                    var buttons = MainV2.Joystick.State.Buttons;


                    if ( buttons[7] && buttons [11] )
                        {
                            Screenshot( );
                            Thread.Sleep( 2500 );    
                        }

                    if ( buttons[ 9 ] && buttons[ 11 ] ) {
                            Screenshot( );
                            Thread.Sleep( 2500 );
                    }
                }
                Thread.Sleep( 60 );
            }

            

            void Screenshot ( )
            {
                var pathSeparator = MainV2.MONO ? Path.AltDirectorySeparatorChar : Path.DirectorySeparatorChar;
                var fileName = DateTime.Now.ToString( "yyyyMMdd_HHmmss" ) + ".png";
                var bitmap = new Bitmap( SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height );
                var graphic = Graphics.FromImage( bitmap );
                var imageFormat = ImageFormat.Jpeg;

                graphic.CopyFromScreen( 0, 0, 0, 0, bitmap.Size );
                bitmap.Save( Settings.GetScreeshotsDirectory( ) + pathSeparator + fileName, imageFormat );
            }
        }

        public void Start ( )
        {
            _isLoop = true;
            _thread.Start( );
        }

        public void Stop ( )
        {
            _isLoop = false;
            _thread.Abort( );
        }
    }
}
