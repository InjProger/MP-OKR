
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MissionPlanner.Configs
{
    public class App
    {
        public bool IsFirstStart { get; set; }

        [JsonConverter( typeof( StringEnumConverter ) )]
        public EAppMode Mode { get; set; }
    }
}