namespace MissionPlanner.GCSViews.NavigationLights
{
    public class Lighting
    {
        private readonly FlickerThread _flickerThread;

        public bool IsOn { get; set; }

        public ELightingType LightingType { get; set; }

        public Lighting ( )
        {
            _flickerThread = new FlickerThread( );
        }

        public Lighting ( bool isOn, ELightingType lightingType, FlickerThread flickerThread )
        {
            IsOn = isOn;
            LightingType = lightingType;
            _flickerThread = flickerThread;
        }

        public void Start ( )
        {
            _flickerThread.Start( );
        }

        public void Stop ( )
        {
            _flickerThread.Stop( );
            IsOn = false;
        }
    }
}
