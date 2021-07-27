
using MissionPlanner.GCSViews.Connections.Models.Connect;

namespace MissionPlanner.GCSViews.Connections.Models
{
    public class Connector
    {
        public Port Port { get; set; }

        public Connector()
        {

        }

        public Connector( Port port )
        {
            Port = port;
        }

        public void Connect()
        {

        }

        public void Disconnect()
        {

        }
    }
}
