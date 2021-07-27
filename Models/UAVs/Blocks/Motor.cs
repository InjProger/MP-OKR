
using OpenTK.Graphics.OpenGL;

namespace MissionPlanner.Models.UAVs.Blocks
{
    public class Motor : Mass
    {
        public double Count { get; set; }
        public double[,] TrustTest { get; set; }
        public double WindSpeedCoefficient { get; set; }

        public Motor ( ) : base( )
        {

        }

        public Motor ( int count, double[,] trustTest, double weight, double windSpeedCoefficient ) : base(weight)
        {
            Count = count;
            TrustTest = trustTest;
            WindSpeedCoefficient = windSpeedCoefficient;
        }

        public override double TotalWeight ( )
        {
            return Weight * Count;
        }
    }
}
