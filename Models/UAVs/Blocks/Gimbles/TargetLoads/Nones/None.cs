
namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.EmptyLoads
{
    public class None : TargetLoad
    {
        public None() : base()
        {
        }

        public override void Load()
        {
            throw new TargetLoadException( "None target load cannnon be loaded" );
        }

        public override void Unload()
        {
            throw new TargetLoadException( "None target load cannnon be unloaded" );
        }
    }
}
