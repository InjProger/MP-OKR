using MissionPlanner.GCSViews.Setups.Models.Generals;
using MissionPlanner.GCSViews.Setups.Models.Interfaces;
using MissionPlanner.GCSViews.Setups.Models.UpScreens;
using MissionPlanner.GCSViews.Alignments;

namespace MissionPlanner.GCSViews.Setups.Models
{
    public class Setting
    {
        public General General { get; set; }
        public Interface Interface { get; set; }
        public UpScreen UpScreen { get; set; }
        public Point AimPoint { get; set; }
    }
}
