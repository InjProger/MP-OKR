
namespace MissionPlanner.Models.UAVs.Blocks
{
    public class Battery
    {
        public double VoltageMax  { get; set; } // V
        public double VoltageMin { get; set; } // V
        public double Capacity { get; set; } // mA

        public Battery( double voltageMax, double voltageMin, double capacity )
        {
            VoltageMax = voltageMax;
            VoltageMin = voltageMin;
            Capacity = capacity;
        }
    }
}
