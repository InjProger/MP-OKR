using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using MissionPlanner.GCSViews.Setups.Models.Generals.Parts;

namespace MissionPlanner.GCSViews.Setups.Models.Generals
{
    public class General
    {
        public bool UseAlternateAirfieldStartPlace { get; set; }
        public bool CheckAlternateAirfields { get; set; }
        public double HomeReturnSpeed { get; set; }
        public double HomeReturnAltitude { get; set; }
        public AutoMode AutoMode { get; set; }
        public LowBatteryActions LowBatteryActions { get; set; }

        [ JsonConverter( typeof( StringEnumConverter ) )]
        public EIkrlFailtureActions EIkrlFailtureActions { get; set; }

        [JsonConverter( typeof( StringEnumConverter ) )]
        public ECrossHairType ECrossHairType { get; set; }
    }
}
