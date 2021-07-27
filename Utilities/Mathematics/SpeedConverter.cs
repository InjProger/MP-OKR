namespace MissionPlanner.Utilities.Mathematics
{
    static public class SpeedConverter
    {
        private const double SPEED_COEFFICIENT = 3.6;

        static public double ToKilometersPerHours(double metersPerSeconds)
        {
            return metersPerSeconds * SPEED_COEFFICIENT;
        }

        static public double ToMetersPerSeconds ( double kilometersPerHours )
        {
            return kilometersPerHours / SPEED_COEFFICIENT;
        }
    }
}
