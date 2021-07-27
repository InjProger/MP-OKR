
using Other.Extensions;

using System.Drawing;

namespace MissionPlanner.Utilities
{
    public class Line
    {
        public Point BegPoint { get; set; }
        public Point EndPoint { get; set; }
        public PointF Center => PointFExtension.CenterPoint( BegPoint, EndPoint );

        public Line()
        {

        }

        public Line( Point begPoint, Point endPoint )
        {
            BegPoint = begPoint;
            EndPoint = endPoint;
        }
    }
}
