
namespace MissionPlanner.Utilities
{
    public static class MathAddition
    {
        public static bool IsInRange(double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        public static double RangeConvert(double value, double ofBeg, double ofEnd, double toBeg, double toEnd)
        {
            return (value - ofBeg) / (ofEnd - ofBeg) * (toEnd - toBeg) + toBeg;
        }

        public static double CenterCoordinate ( double x1, double x2 )
        {
            return ( x1 + x2 ) / 2;
        }
    }
}
