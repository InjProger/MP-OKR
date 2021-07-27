using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.Models
{
    internal class Atmosphere
    {
        private readonly int Temperature;
        private readonly int WindAzimuth;
        private readonly int WindSpeed;

        internal Atmosphere(int temperature, int windAzimuth, int windSpeed)
        {
            Temperature = temperature;
            WindAzimuth = windAzimuth;
            WindSpeed   = windSpeed;
        }
    }
}
