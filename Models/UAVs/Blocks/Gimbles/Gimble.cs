
using Microsoft.Diagnostics.Runtime.ICorDebug;

using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads;

namespace MissionPlanner.Models.UAVs.Blocks.Gimbles
{
    public class Gimble : Mass
    {
        public TargetLoad TargetLoad { get; set; }

        public Gimble() : base()
        {

        }

        public Gimble( double weight, TargetLoad targetLoad ) : base( weight )
        {
            TargetLoad = targetLoad;
        }

        public void Unload()
        {

        }

        public override double TotalWeight()
        {
            var targetLoadWeight = TargetLoad?.TotalWeight( ) ?? 0;
            return Weight + targetLoadWeight;
        }
    }
}
