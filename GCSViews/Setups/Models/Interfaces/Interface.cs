using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MissionPlanner.GCSViews.Setups.Models.Interfaces
{
    public class Interface
    {
        [JsonConverter( typeof( StringEnumConverter ) )]
        public ECoordinateSystem ECoordinateSystem { get; set; }

        [JsonConverter( typeof( StringEnumConverter ) )]
        public ESpeed ESpeed { get; set; }
    }
}
