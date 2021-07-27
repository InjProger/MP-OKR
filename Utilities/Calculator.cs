using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Modeling.Forms;

namespace MissionPlanner.Utilities
{
    public static class Calculator
    {
        public static double CalcTempCoef ( double nowTemperature )
        {
            if (nowTemperature > 0)
            {
                if ( 1 <= nowTemperature && nowTemperature <= 4 )
                    return 0.93;
                else
                    return 0.95;
            }
            else
            {
                if ( 0 <= nowTemperature && nowTemperature <= -2 )
                    return 0.9;
                if ( -3 <= nowTemperature && nowTemperature <= -10 )
                    return 0.85;
                if ( -11 <= nowTemperature && nowTemperature <= -15 )
                    return 0.75;
                else
                    return 0.85;
            }
        }
        
        public static double CalcRemainingFlightTime()
        {
            return 0;
        }
    }
}
