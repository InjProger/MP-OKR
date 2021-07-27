
namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Ammunations.Weapons.Shells
{
    public class Shell : Mass
    {
        public Shell() : base()
        {

        }

        public Shell( double weight = 0 ) : base ( weight )
        {
        }

        public Shell( Shell shell ) : base( shell.Weight )
        {
        }
    }
}
