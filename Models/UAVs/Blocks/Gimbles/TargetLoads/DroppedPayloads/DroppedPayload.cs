
namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.DroppedPayloads
{
    public class DroppedPayload : TargetLoad
    {
        public override void Load ( )
        {   
            if ( Weight > 0 )
            {
                throw new TargetLoadException( "Full dropped payload cannot be loaded" );
            }

            IsLoaded = true;
        }

        public override void Unload ( )
        {
            if ( Weight == 0 )
            {
                throw new TargetLoadException( "Empty dropped payload cannot be unloaded" );
            }

            Weight = 0;
            IsLoaded = false;
        }
    }
}
