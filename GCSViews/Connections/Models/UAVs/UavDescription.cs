
using MissionPlanner.Models.UAVs;
using MissionPlanner.Models.UAVs.Blocks;
using MissionPlanner.Models.UAVs.Blocks.Gimbles;
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads;
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Ammunations;
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Containers;

namespace MissionPlanner.GCSViews.Connections.Models.UAVs
{
    public class UavDescription : UAV
    {
        public Container  Container  { get; set; }
        public Ammunation Ammunation { get; set; }

        public UavDescription ( )
        {

        }

        public UavDescription( EUavType eUavType, int modelId, double weight, Gimble gimble, Battery battery )
        {
            EUavType     = eUavType;
            ModelId      = modelId;
            Weight       = weight;
            Gimble       = gimble;
            Battery      = battery;
        }

        public UavDescription ( UAV uav )
        {
            Weight = uav.Weight;
            MaxLiftingWeight = uav.MaxLiftingWeight;
            EUavType = uav.EUavType;
            ModelId = uav.ModelId;
            IsOKR = uav.IsOKR;
            Battery = uav.Battery;
            Gimble = uav.Gimble;

            var targetLoad = GetTargetLoad( uav );

            Container = targetLoad as Container;
            Ammunation = targetLoad as Ammunation;
        }

        private TargetLoad GetTargetLoad ( UAV uav )
        {
            var gimblesTargetLoad = uav?.Gimble?.TargetLoad;

            if ( gimblesTargetLoad != null )
            {
                return gimblesTargetLoad;
            }

            if ( uav.TargetLoad != null )
            {
                return uav.TargetLoad;
            }

            return null;
        }

        public double FreeWeightWithContainer ( )
        {
            var containerWeight = Container?.TotalWeight( ) ?? 0;

            return MaxLiftingWeight - Weight - Battery.Weight - containerWeight;
        }
    }
}
