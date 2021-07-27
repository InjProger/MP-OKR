using MissionPlanner.Configs;
using MissionPlanner.Globals;
using MissionPlanner.Utilities.Streams;

using System;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.Alignments
{
    public partial class Alignment : Form
    {
        private Point _aimPoint;
        private StreamWorker _streamWorker;

        public Alignment ( )
        {
            InitializeComponent( );

            _aimPoint = Configurator.Setting?.AimPoint ?? new Point();
            _streamWorker = GlbContext.StreamWorker;
        }

        private void MovePoint ( Point point )
        {
            if ( _streamWorker is null )
            {
                return;
            }

            _streamWorker.SetCrossOffset( point );
        }

        private void BtnUp_Click ( object sender, EventArgs e )
        {
            _aimPoint.Y += 0.1;
            MovePoint( _aimPoint );
        }

        private void BtnBottom_Click ( object sender, EventArgs e )
        {
            _aimPoint.Y -= 0.1;
            MovePoint( _aimPoint );
        }

        private void BtnLeft_Click ( object sender, EventArgs e )
        {
            _aimPoint.X -= 0.1;
            MovePoint( _aimPoint );
        }

        private void BtnRight_Click ( object sender, EventArgs e )
        {
            _aimPoint.X += 0.1;
            MovePoint( _aimPoint );
        }

        private void BtnCenter_Click ( object sender, EventArgs e )
        {
            _aimPoint.X = 0;
            _aimPoint.Y = 0;
            MovePoint( _aimPoint );
        }

        private void BtnOk_Click ( object sender, EventArgs e )
        {   
            Configurator.Setting.AimPoint = _aimPoint;
            Configurator.Save( );

            Close( );
        }
    }
}
