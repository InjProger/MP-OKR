
namespace MissionPlanner.GCSViews.Connections.Models.Connect
{
    public class Connection
    {
        public Port Uav { get; set; }
        public Port Joystick { get; set; }

        public Connection()
        {

        }

        public Connection( Port uav, Port joystick )
        {
            Uav = uav;
            Joystick = joystick;
        }
    }
}
