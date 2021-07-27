namespace MissionPlanner.Utilities.Measurements
{
    public class Measure
    {
        public string Local { get; set; }
        public string Voltage { get; set; }
        public string Capacity { get; set; }
        public string[] CardinalPoints { get; set; }
        public string[] FlightMode { get; set; }
        public string[] FlightStatus { get; set; }

        public override string ToString ( )
        {
            var text = Local + "\n";
            text += Voltage + "\n";
            text += Capacity + "\n";

            var cardinalPointsJoin = string.Join( " ", CardinalPoints );
            var flightMode = string.Join( " ", FlightMode );
            var flightStatus = string.Join( " ", FlightStatus );

            text += "( " + cardinalPointsJoin + ")" + "\n";
            text += "( " + cardinalPointsJoin + ")" + "\n";
            text += "( " + cardinalPointsJoin + ")" + "\n";

            return text;
        }
    }
}
