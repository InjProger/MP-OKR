
namespace MissionPlanner.GCSViews.Connections.Models.Connect
{
    public class Port
    {
        public string Name { get; set; }
        public int Baudrate { get; set; }
        public double Updaterate { get; set; }

        public Port()
        {

        }

        public Port( string name, int baudrate, int updaterate )
        {
            Name = name;
            Baudrate = baudrate;
            Updaterate = updaterate;
        }
    }
}
