
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Containers.Payloads;

namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Containers
{
    public class Container : TargetLoad
    {
        public double MaxLiftedContentWeight { get; set; } // Кг

        public bool IsDropped { get; set; }
        public Payload Payload { get; set; }

        public Container() : base()
        {

        }

        public Container( double weight, double maxLiftedContentWeight, bool isLoaded,  bool isDroped, Payload payload ) : base( weight )
        {   
            MaxLiftedContentWeight = maxLiftedContentWeight;
            IsLoaded = isLoaded;
            IsDropped = isDroped;
            Payload = payload;
        }

        public bool IsLiftContent()
        {
            var payloadWeight = Payload?.Weight ?? 0;
            return ( MaxLiftedContentWeight - payloadWeight ) >= 0;
        }

        public override void Load()
        {
            if ( IsLoaded || Payload.Weight > 0 )
            {
                throw new TargetLoadException( "Full container cannot be loaded" );
            }
            
            IsLoaded = true;
        }

        public override void Unload()
        {
            var payloadWeight = Payload?.Weight ?? 0;

            if ( !IsLoaded || payloadWeight == 0 )
            {
                throw new TargetLoadException( "Empty container cannot be unloaded" );
            }

            if ( !IsDropped )
            {
                throw new TargetLoadException( "Undropped container cannot be unloaded" );
            }

            IsLoaded = false;
            Payload.Weight = 0;
        }

        public override double TotalWeight()
        {
            var containerWeight = IsLoaded ? Weight : 0;
            var payloadWeight = Payload?.TotalWeight( ) ?? 0;

            return containerWeight + MaxLiftedContentWeight - payloadWeight;
        }
    }
}
