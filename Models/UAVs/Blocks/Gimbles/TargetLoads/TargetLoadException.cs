using System;

namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads
{
    public class TargetLoadException : Exception
    {
        public TargetLoadException( string message) : base(message)
        {

        }
    }
}
