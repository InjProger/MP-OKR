
namespace MissionPlanner.Utilities.CoordSystem
{
    using System;
    
    using static System.Math;

    public class GsKr
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class CoordSystemConverter
    {
        #region CONSTANTS

        const double RO = 206264.8062;

        const double aP = 6378245;
        const double alP = 1 / 298.3;
        const double e2P = 2 * alP - alP * alP;

        const double aW = 6378137;
        const double alW = 1 / 298.257223563;
        const double e2W = 2 * alW - alW * alW;

        const double a = ( aP + aW ) / 2;
        const double e2 = ( e2P + e2W ) / 2;
        const double da = aW - aP;
        const double de2 = e2W - e2P;

        const double dx = 23.92;
        const double dy = -141.27;
        const double dz = -80.9;

        const double wx = 0;
        const double wy = 0;
        const double wz = 0;

        const double ms = 0;

        const double RAD_DEG = 180 / Math.PI;

        #endregion

        #region METHODS

        private static double dB ( CoordinatSystem cs )
        {
            var B = cs.Lat * PI / 180;
            var L = cs.Lon * PI / 180;
            var M = a * ( 1 - e2 ) / Pow( ( 1 - e2 * Pow( Sin( B ), 2 ) ), 1.5 );
            var N = a * Pow( ( 1 - e2 * Pow( Sin( B ), 2 ) ), -0.5 );

            return RO / ( M + cs.Alt ) * ( N / a * e2 * Sin( B ) * Cos( B ) * da
                + ( ( N * N ) / ( a * a ) + 1 ) * N * Sin( B ) * Cos( B ) * de2 / 2
                - ( dx * Cos( L ) + dy * Sin( L ) ) * Sin( B ) + dz * Cos( B ) )
                - wx * Sin( L ) * ( 1 + e2 * Cos( 2 * B ) )
                + wy * Cos( L ) * ( 1 + e2 * Cos( 2 * B ) )
                - RO * ms * e2 * Sin( B ) * Cos( B );
        }

        private static double dL ( CoordinatSystem cs )
        {
            var B = cs.Lat * PI / 180;
            var L = cs.Lon * PI / 180;
            var N = a * Pow( ( 1 - e2 * Pow( Sin( B ), 2 ) ), -0.5 );

            return RO / ( ( N + cs.Alt ) * Cos( B ) ) * ( -dx * Sin( L ) + dy * Cos( L ) )
                + Tan( B ) * ( 1 - e2 ) * ( wx * Cos( L ) + wy * Sin( L ) ) - wz;
        }

        public static GsKr WGS84ToCK42Convert ( WGS84 wgs84 )
        {
            return ConvertToCk42( );

            GsKr ConvertToCk42 ( )
            {
                var ck42 = new CK42
                {
                    Lat = wgs84.Lat - dB( wgs84 ) / 3600,
                    Lon = wgs84.Lon - dL( wgs84 ) / 3600,
                    Alt = wgs84.Alt
                };

                return CK42ToGsKr( ck42 );
            }

            GsKr CK42ToGsKr ( CK42 ck42 )
            {
                return new GsKr
                {
                    X = SK42BTOX( ck42 ) + 9,
                    Y = SK42LTOY( ck42 ) - 10,
                    Z = ck42.Alt
                };
            }

            double SK42BTOX ( CK42 ck42 )
            {
                var No = ( int ) ( ( 6 + ck42.Lon ) / 6 );
                var Lo = ( ck42.Lon - ( 3 + 6 * ( No - 1 ) ) ) / 57.29577951;
                var Bo = ck42.Lat * PI / 180;
                var Xa = Pow( Lo, 2 ) * ( 109500 - 574700 * Pow( Sin( Bo ), 2 ) + 863700 * Pow( Sin( Bo ), 4 ) - 398600 * Pow( Sin( Bo ), 6 ) );
                var Xb = Pow( Lo, 2 ) * ( 278194 - 830174 * Pow( Sin( Bo ), 2 ) + 572434 * Pow( Sin( Bo ), 4 ) - 16010 * Pow( Sin( Bo ), 6 ) + Xa );
                var Xc = Pow( Lo, 2 ) * ( 672483.4 - 811219.9 * Pow( Sin( Bo ), 2 ) + 5420 * Pow( Sin( Bo ), 4 ) - 10.6 * Pow( Sin( Bo ), 6 ) + Xb );
                var Xd = Pow( Lo, 2 ) * ( 1594561.25 + 5336.535 * Pow( Sin( Bo ), 2 ) + 26.79 * Pow( Sin( Bo ), 4 ) + 0.149 * Pow( Sin( Bo ), 6 ) + Xc );

                return 6367558.4968 * Bo - Sin( Bo * 2 ) * ( 16002.89 + 66.9607 * Pow( Sin( Bo ), 2 ) + 0.3515 * Pow( Sin( Bo ), 4 ) - Xd );
            }

            double SK42LTOY ( CK42 ck42 )
            {
                var No = ( int ) ( ( 6 + ck42.Lon ) / 6 );
                var Lo = ( ck42.Lon - ( 3 + 6 * ( No - 1 ) ) ) / 57.29577951;
                var Bo = ck42.Lat * PI / 180;
                var Ya = Pow( Lo, 2 ) * ( 79690 - 866190 * Pow( Sin( Bo ), 2 ) + 1730360 * Pow( Sin( Bo ), 4 ) - 945460 * Pow( Sin( Bo ), 6 ) );
                var Yb = Pow( Lo, 2 ) * ( 270806 - 1523417 * Pow( Sin( Bo ), 2 ) + 1327645 * Pow( Sin( Bo ), 4 ) - 21701 * Pow( Sin( Bo ), 6 ) + Ya );
                var Yc = Pow( Lo, 2 ) * ( 1070204.16 - 2136826.66 * Pow( Sin( Bo ), 2 ) + 17.98 * Pow( Sin( Bo ), 4 ) - 11.99 * Pow( Sin( Bo ), 6 ) + Yb );

                return ( 5 + 10 * No ) * 100000 + Lo * Cos( Bo ) * ( 6378245 + 21346.1415 * Pow( Sin( Bo ), 2 ) + 107.159 * Pow( Sin( Bo ), 4 ) + 0.5977 * Pow( Sin( Bo ), 6 ) + Yc );
            }
        }

        public static WGS84Deg WGS84ToDegConvert ( WGS84 wgs84 )
        {
            return new WGS84Deg
            {
                Lat = ConvertCoordinate( wgs84.Lat ),
                Lon = ConvertCoordinate( wgs84.Lon ),
                Alt = wgs84.Alt
            };

            Coordinate ConvertCoordinate ( double coord )
            {
                var ceilPart = ( int ) coord;
                var fracPart = coord - ceilPart;
                var min = fracPart * 60;
                var sec = ( ( fracPart * 60 ) % 1 ) * 60;

                return new Coordinate
                {
                    Deg = ceilPart,
                    Min = ( int ) min,
                    Sec = sec
                };
            }
        }

        public static WGS84 CK42ToWGS84Convert ( CK42 ck42 )
        {
            var x = ck42.Lat;
            var y = ck42.Lon;

            var n = ( int ) ( y / 1000000 ); // номер шестигранной зоны в проекции Гаусса-Крюгера
            var a = x / 6367558.4968; // вспомогательная величина
            var sina = Math.Sin( a );
            var sina2 = sina * sina;
            var sina4 = sina2 * sina2;
            var b = a + Math.Sin( 2 * a ) * ( 0.00252588685 - 0.00001491860 * sina2 + 0.00000011904 * sina4 ); // геодезическая широта точки, абцисса которой равна абциссе x определяемой точки, а ордината равна нулю, радs
            var sinb = Math.Sin( b );
            var sinb2 = sinb * sinb;
            var sinb4 = sinb2 * sinb2;
            var sinb6 = sinb4 * sinb2;
            var z = ( y - ( 10 * n + 5 ) * 100000 ) / ( 6378245 * Math.Cos( b ) ); // вспомогательная величина
            var z2 = z * z;

            var dB = -z2 * Math.Sin( 2 * b )
                     * ( 0.251684631 - 0.003369263 * sinb2 + 0.000011276 * sinb4
                - z2 * ( 0.10500614 - 0.04559916 * sinb2 + 0.00228901 * sinb4 - 0.00002987 * sinb6
                - z2 * ( 0.042858 - 0.025318 * sinb2 + 0.014346 * sinb4 - 0.001264 * sinb6
                - z2 * ( 0.01672 - 0.00630 * sinb2 + 0.01188 * sinb4 - 0.00328 * sinb6 ) ) ) );

            var l = z * ( 1 - 0.0033467108 * sinb2 - 0.0000056002 * sinb4 - 0.0000000187 * sinb6
                - z2 * ( 0.16778975 + 0.16273586 * sinb2 - 0.00052490 * sinb4 - 0.00000846 * sinb6
                - z2 * ( 0.0420025 + 0.1487407 * sinb2 + 0.0059420 * sinb4 - 0.0000150 * sinb6
                - z2 * ( 0.01225 + 0.09477 * sinb2 + 0.03282 * sinb4 + 0.00034 * sinb6
                - z2 * ( 0.0038 + 0.0524 * sinb2 + 0.0482 * sinb4 + 0.0032 * sinb6 ) ) ) ) );

            var B = b + dB;
            var L = 6 * ( n - 0.5 ) / RAD_DEG + l;

            return new WGS84
            {
                Lat = B * RAD_DEG - 0.00009277,
                Lon = L * RAD_DEG - 0.0019579082267,
                Alt = ck42.Alt
            };
        }

        public static WGS84 DegToWgs84Convert ( WGS84Deg wgs84Deg )
        {
            return new WGS84
            {
                Lat = ConvertCoordinate( wgs84Deg.Lat ),
                Lon = ConvertCoordinate( wgs84Deg.Lon ),
                Alt = wgs84Deg.Alt
            };

            double ConvertCoordinate ( Coordinate coord )
            {
                return coord.Deg + coord.Min / 60.0 + coord.Sec / 3600;
            }
        }


        #endregion
    }
}
