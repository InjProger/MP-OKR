using Microsoft.CodeAnalysis.CSharp.Syntax;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Other.Extensions
{
    public static class ControlExtension
    {
        public static PointF CenterPoint ( this Control control )
        {
            return new PointF
            {
                X = control.Width / 2,
                Y = control.Height / 2
            };
        }
    }
}
