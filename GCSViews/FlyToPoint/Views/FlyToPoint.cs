using MissionPlanner.Utilities;

using System;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.FlyToPoint.Views
{
    public partial class FlyToPoint : Form
    {
        private const int ON_MAP = 0;
        private const int COORDINATES = 1;
        private const int AZIMUTH = 2;

        public FlyToPoint ( )
        {
            InitializeComponent( );

            tcCoordinates.SelectedIndex = COORDINATES;
        }

        private double DegreesToRadians ( double degrees ) => degrees * Math.PI / 180.0;

        private PointLatLngAlt CreateFlyPointByAzimuth ( )
        {
            const double EARTH_RAD = 6371;

            var angleDeg = double.Parse( tbAngle.Text );
            var angleRad = DegreesToRadians( angleDeg );
            var r = double.Parse( tbDistance.Text );
            var s = r / EARTH_RAD;
            var lat = Math.Asin( Math.Cos( s ) * Math.Sin( angleRad ) + Math.Sin( s ) * Math.Cos( MainV2.ComPort.MAV.cs.Location.Lat ) * Math.Cos( angleRad ) );
            var lon = MainV2.ComPort.MAV.cs.Location.Lng + Math.Atan( Math.Sin( s ) * Math.Sin( angleRad ) / ( Math.Cos( s ) * Math.Cos( MainV2.ComPort.MAV.cs.Location.Lat ) - Math.Sin( s ) * Math.Sin( MainV2.ComPort.MAV.cs.Location.Lat ) * Math.Cos( angleRad ) ) );
            var alt = MainV2.ComPort.MAV.cs.Location.Alt;

            return new PointLatLngAlt( lat, lon, alt );
        }

        private PointLatLngAlt CreateFlyPoint ( )
        {
            var lat = double.Parse( tbLatitude.Text );
            var lon = double.Parse( tbLongitude.Text );
            var alt = MainV2.ComPort.MAV.cs.Location.Alt;

            return new PointLatLngAlt( lat, lon, alt );
        }

        private void BtnOnMap_Click ( object sender, EventArgs e )
        {
            Hide( );
        }

        private void BtnOk_Click ( object sender, EventArgs e )
        {
            PointLatLngAlt flyPoint = null;

            switch ( tcCoordinates.SelectedIndex )
            {
                case ON_MAP:
                    break;
                case COORDINATES:
                    flyPoint = CreateFlyPoint( );
                    break;
                case AZIMUTH:
                    flyPoint = CreateFlyPointByAzimuth( );
                    break;
            }

            Close( );
        }

        private void BtnCancel_Click ( object sender, EventArgs e )
        {
            Close( );
        }
    }
}
