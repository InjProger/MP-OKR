
namespace MissionPlanner.Models.UAVs.Blocks
{
    public class Battery : Mass
    {
        public double VoltageMax { get; set; } // V
        public double VoltageMin { get; set; } // V
        public double MaxConvertVoltage { get; set; } // V
        public double Capacity { get; set; } // mA
        public int BankCount { get; set; } // V

        public Battery() : base()
        {

        }

        public Battery ( double voltageMax, double voltageMin, double capacity, double maxConvertVoltage, int bankCount )
        {
            VoltageMax = voltageMax;
            VoltageMin = voltageMin;
            MaxConvertVoltage = maxConvertVoltage;
            Capacity = capacity;
            BankCount = BankCount;
        }
    }
}
