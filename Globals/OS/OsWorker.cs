
using System;

namespace MissionPlanner.Globals.OS
{
    public static class OsWorker
    {
        public static EOperationSystemType DetermineOperationSystem()
        {
            const char WINDOWS = 'W';
            var usedPlatformOS = Environment.OSVersion.Platform.ToString( )[ 0 ];
            return usedPlatformOS == WINDOWS ? EOperationSystemType.Windows : EOperationSystemType.Linux;
        }
    }
}
