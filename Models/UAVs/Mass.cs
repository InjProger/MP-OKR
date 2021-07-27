
namespace MissionPlanner.Models.UAVs
{
    public abstract class Mass
    {
        public double Weight { get; set; } // Кг

        public Mass( double weight = 0 )
        {
            Weight = weight;
        }

        public virtual double TotalWeight()
        {
            return Weight;
        }
    }
}
