
using MissionPlanner.GCSViews.Connections.Models;

namespace MissionPlanner.Models
{
    public class Gadget<T>
    {
        public T Device { get; set; }
        public Connector Connector { get; set; }

        public Gadget()
        {

        }

        public Gadget( T device, Connector connector )
        {
            Device = device;
            Connector = connector;
        }
    }
}
