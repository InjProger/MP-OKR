using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Ammunations.Weapons;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Ammunations
{
    public class Ammunation : TargetLoad
    {
        [JsonConverter( typeof( StringEnumConverter ) )]
        public EShotType EShotType { get; set; }
        [JsonConverter( typeof( StringEnumConverter ) )]
        public ESelectedWeapon ESelectedWeapon { get; set; }

        public Weapon LeftWeapon { get; set; }
        public Weapon RightWeapon { get; set; }

        public Ammunation() : base()
        {

        }

        public Ammunation( EShotType eShotType, ESelectedWeapon eSelectedWeapon, Weapon leftWeapon, Weapon rightWeapon ) : base( )
        {
            EShotType       = eShotType;
            ESelectedWeapon = eSelectedWeapon;
            LeftWeapon      = leftWeapon;
            RightWeapon     = rightWeapon;
        }

        public Ammunation( Ammunation ammunation ) : base( )
        {
            EShotType       = ammunation.EShotType;
            ESelectedWeapon = ammunation.ESelectedWeapon;

            LeftWeapon  = CloneWeapon( ammunation.LeftWeapon );
            RightWeapon = CloneWeapon( ammunation.RightWeapon );

            Weapon CloneWeapon( Weapon weapon )
            {
                return weapon != null ? new Weapon( weapon ) : null;
            }
        }

        public override void Load( )
        {
            if ( LeftWeapon != null )
            {
                LeftWeapon.Load( );
            }

            if ( RightWeapon != null )
            {
                RightWeapon.Load( );
            }
        }

        public override void Unload()
        {
            switch ( EShotType )
            {
                case EShotType.Single:
                    var loadingWeapon = ESelectedWeapon == ESelectedWeapon.Left ? LeftWeapon : RightWeapon;
                    loadingWeapon.Unload( );
                    break;
                case EShotType.Double:
                    LeftWeapon.Unload( );
                    RightWeapon.Unload( );
                    break;
            }
        }

        public override double TotalWeight()
        {
            var leftWeaponWeight = LeftWeapon?.TotalWeight( ) ?? 0;
            var rightWeaponWeight = RightWeapon?.TotalWeight( ) ?? 0;
            
            return leftWeaponWeight + rightWeaponWeight;
        }
    }
}
