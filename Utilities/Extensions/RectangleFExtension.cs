using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Other.Extensions
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
