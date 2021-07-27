
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Ammunations.Weapons.Shells;

namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Ammunations.Weapons
{
    public class Weapon : TargetLoad
    {   
        public string Model { get; set; }

        public Shell Shell { get; set; }
        public bool IsEquivalent { get; set; }

        public Weapon ( ) : base( )
        {

        }

        public Weapon ( string model, Shell shell, double weight, bool isLoaded = false ) : base( weight )
        {
            Model = model;
            IsLoaded = isLoaded;
            Shell = shell;
        }

        public Weapon ( Weapon weapon ) : base( weapon.Weight )
        {
            Model = weapon.Model;
            IsLoaded = weapon.IsLoaded;
            Shell = new Shell( weapon.Shell );
        }

        public override void Unload ( )
        {
            if ( !IsLoaded )
            {
                throw new TargetLoadException( "Empty weapon cannot be unloaded" );
            }

            IsLoaded = false;
        }

        public override void Load ( )
        {
            if ( IsLoaded )
            {
                throw new TargetLoadException( "Full weapon cannot be loaded" );
            }

            IsLoaded = true;
        }

        public override double TotalWeight ( )
        {
            return Weight + Shell.Weight;
        }
    }
}
