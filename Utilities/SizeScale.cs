using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionPlanner.Utilities
{
    public class SizeScale
    {
        public string Distance { get; set; }
        public int PixelCount { get; set; }

        public SizeScale( int scale )
        {
            switch ( scale )
            {
                case 21:
                    Distance = "10 M";
                    PixelCount = 408;
                    break;
                case 20:
                    Distance = "10 M";
                    PixelCount = 204;
                    break;
                case 19:
                    Distance = "50 M";
                    PixelCount = 510;
                    break;
                case 18:
                    Distance = "50 M";
                    PixelCount = 254;
                    break;
                case 17:
                    Distance = "100 M";
                    PixelCount = 254;
                    break;
                case 16:
                    Distance = "100 M";
                    PixelCount = 126;
                    break;
                case 15:
                    Distance = "200 M";
                    PixelCount = 126;
                    break;
                case 14:
                    Distance = "500 M";
                    PixelCount = 160;
                    break;
                case 13:
                    Distance = "1 KM";
                    PixelCount = 160;
                    break;
                case 12:
                    Distance = "2 KM";
                    PixelCount = 160;
                    break;
                case 11:
                    Distance = "4 KM";
                    PixelCount = 160;
                    break;
                case 10:
                    Distance = "8 KM";
                    PixelCount = 160;
                    break;
                case 9:
                    Distance = "16 KM";
                    PixelCount = 120;
                    break;
                case 8:
                    Distance = "32 KM";
                    PixelCount = 120;
                    break;
                case 7:
                    Distance = "64 KM";
                    PixelCount = 120;
                    break;
                case 6:
                    Distance = "128 KM";
                    PixelCount = 120;
                    break;
                case 5:
                    Distance = "256 KM";
                    PixelCount = 120;
                    break;
            }
        }
        
    }
}
