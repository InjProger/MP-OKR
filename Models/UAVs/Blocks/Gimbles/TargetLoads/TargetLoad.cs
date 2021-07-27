
namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads
{
    public abstract class TargetLoad : Mass
    {
        public bool IsLoaded { get; set; }

        public TargetLoad() : base()
        {

        }

        public TargetLoad( double weight = 0 ) : base( weight )
        {
        }

        public abstract void Load();
        public abstract void Unload();

        public override double TotalWeight ( )
        {
            return base.TotalWeight( );
        }
    }
}
