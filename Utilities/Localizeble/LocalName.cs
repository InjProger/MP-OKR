namespace MissionPlanner.Utilities.Localizable
{
    public class LocalName
    {
        public string Name { get; set; }
        public string Local { get; set; }

        public LocalName ( )
        {

        }

        public LocalName ( string name, string local )
        {
            Name = name;
            Local = local;
        }
    }
}
