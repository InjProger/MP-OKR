using MissionPlanner.Globals;
using MissionPlanner.Models.UAVs;

using System;

namespace MissionPlanner.Log
{
    static class LogDir
    {
        public static string GetDirDevice ( )
        {
            switch ( GlbContext.Uav.Device.EUavType )
            {
                case EUavType.Quadrocopter:
                    return "QUADROTOR";
                case EUavType.Aircraft:
                    return "FIXED_WING";
                case EUavType.Car:
                    return "SITL";
                default:
                    return String.Empty;
            }
        }
    }
}
