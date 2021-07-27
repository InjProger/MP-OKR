using System.Drawing;

namespace SDL.Extensions
{
    public static class PointFExtension
    {
        public static PointF CenterPoint( PointF pointA, PointF pointB )
        {
            return new PointF
            {
                X = (float)CenterCoordinate( pointA.X, pointB.X ),
                Y = (float)CenterCoordinate( pointA.Y, pointB.Y )
            };
        }

        private static float CenterCoordinate( float x1, float x2 )
        {
            return (x1 + x2) / 2;
        }
    }
}
