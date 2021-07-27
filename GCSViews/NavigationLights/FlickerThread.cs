namespace MissionPlanner.GCSViews.NavigationLights
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class FlickerThread
    {
        private bool _isBlink;

        public FlickerThread ( )
        {
        }

        private void Bird ( )
        {
            while ( _isBlink )
            {
                MainV2.ComPort.doCommand( ( byte ) MainV2.ComPort.sysidcurrent, ( byte ) MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_RELAY, 0, 0, 0, 0, 0, 0, 0 );

                Task.Delay( 1000 );

                MainV2.ComPort.doCommand( ( byte ) MainV2.ComPort.sysidcurrent, ( byte ) MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_RELAY, 0, 1, 0, 0, 0, 0, 0 );

                Task.Delay( 2000 );
            }
        }

        public async void Start ( )
        {
            _isBlink = true;
            await Task.Run( Bird );
        }

        public void Stop ( )
        {
            _isBlink = false;
        }
    }
}