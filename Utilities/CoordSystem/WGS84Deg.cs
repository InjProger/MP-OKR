namespace MissionPlanner.Utilities.CoordSystem
{
    public class WGS84Deg
    {
        public Coordinate Lat { get; set; }
        public Coordinate Lon { get; set; }

        public double Alt { get; set; }
    }

    public class Coordinate
    {
        public int Deg { get; set; }
        public int Min { get; set; }
        public double Sec { get; set; }

        public Coordinate ( )
        {

        }

        public Coordinate ( int deg, int min, int sec )
        {
            Deg = deg;
            Min = min;
            Sec = sec;
        }

        public Coordinate ( string text )
        {
            var coordinats = text.Split( ' ' );
            Deg = int.Parse( coordinats[ 0 ] );
            Min = int.Parse( coordinats[ 1 ] );
            Sec = int.Parse( coordinats[ 2 ] );
        }

        public override string ToString ( )
        {
            return $"{Deg} {Min} {Sec}";
        }
    }
}
