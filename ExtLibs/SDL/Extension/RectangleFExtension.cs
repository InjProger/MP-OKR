
using System.Drawing;

namespace SDL.Extensions
{
    public static class RectangleFExtension
    {
        public static PointF CenterPoint ( this Rectangle rectangle )
        {
            return new PointF
            { 
                X = rectangle.Width / 2,
                Y = rectangle.Height / 2
            };
        }
    }
}
