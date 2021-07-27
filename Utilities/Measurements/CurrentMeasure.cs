namespace MissionPlanner.Utilities.Measurements
{
    public class CurrentMeasure : Measure
    {
        public string Distance { get; set; }
        public string Speed { get; set; }

        public override string ToString ( )
        {
            var text = base.ToString( ) + "\n";
            text = Distance + "\n";

            return text + Speed;
        }
    }
}
