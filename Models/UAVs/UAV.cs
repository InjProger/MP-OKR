
using MissionPlanner.GCSViews.Connections.Models.UAVs;
using MissionPlanner.Models.UAVs.Blocks;
using MissionPlanner.Models.UAVs.Blocks.Gimbles;
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads;
using MissionPlanner.Utilities;
using MissionPlanner.Utilities.Localizeble;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MissionPlanner.Models.UAVs
{
    public class UAV : Mass
    {
        public bool IsOKR { get; set; }

        public double MaxLiftingWeight { get; set; } // Кг

        [JsonConverter( typeof( StringEnumConverter ) )]
        public EUavType EUavType { get; set; }

        public LocalNames LocalNames { get; set; }

        public int ModelId { get; set; }

        public Motor Motor { get; set; }
        public Gimble Gimble { get; set; }
        public Battery Battery { get; set; }
        public TargetLoad TargetLoad { get; set; }

        public UAV( double weight = 0 ) : base( weight )
        {
            
        }

        public UAV( UavDescription uavDescription )
        {
            Weight = uavDescription.Weight;
            EUavType = uavDescription.EUavType;
            ModelId = uavDescription.ModelId;
            IsOKR = uavDescription.IsOKR;
            MaxLiftingWeight = uavDescription.MaxLiftingWeight;
            Battery = uavDescription.Battery;
            Motor = uavDescription.Motor;
            LocalNames = uavDescription.LocalNames;
        }

        public void Unload ( )
        {
            TargetLoad?.Unload( );
            Gimble?.TargetLoad?.Unload( );
        }

        public void Load ( )
        {
            TargetLoad?.Load( );
            Gimble?.TargetLoad?.Load( );
        }

        public virtual double FreeWeight ( )
        {
            return MaxLiftingWeight - TotalWeight( );
        }

        public override double TotalWeight()
        {
            var motorWetght = Motor?.TotalWeight( ) ?? 0;
            var gimbleWeight = Gimble?.TotalWeight( ) ?? 0;
            var targetLoadWeight = TargetLoad?.TotalWeight( ) ?? 0;

            return Weight + motorWetght + Battery.Weight + gimbleWeight + targetLoadWeight;
        }
    }
}
