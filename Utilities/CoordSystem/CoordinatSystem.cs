namespace MissionPlanner.Utilities.CoordSystem
{
    public abstract class CoordinatSystem
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Alt { get; set; }

        public CoordinatSystem ( )
        {

        }

        public CoordinatSystem ( double lon, double lat, double alt )
        {
            Lon = lon;
            Lat = lat;
            Alt = alt;
        }
    }

    public class WGS84 : CoordinatSystem
    {

    };

    public class CK42 : CoordinatSystem
    {

    }
}
