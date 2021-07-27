
using MissionPlanner.Configs;
using MissionPlanner.GCSViews.Connections.Models.UAVs;
using MissionPlanner.Globals.OS;
using MissionPlanner.Models;
using MissionPlanner.Models.UAVs;
using MissionPlanner.Utilities.Streams;

using System.Threading.Tasks;

using static MissionPlanner.Globals.OS.OsWorker;

using JJoystick = MissionPlanner.Models.Joysticks.Joystick;

namespace MissionPlanner.Globals
{
    public static class GlbContext
    {
        public static readonly EOperationSystemType OperationSystemType;
               
        public static bool IsConnected { get; set; }
        public static EAppMode AppMode { get; set; }

        public static Gadget<UAV> Uav { get; set; }
        public static Gadget<JJoystick> Joystick { get; set; }

        public static StreamWorker StreamWorker { get; set; }

        static GlbContext( )
        {
            OperationSystemType = DetermineOperationSystem( );
            
            Uav      = new Gadget<UAV>( );
            Joystick = new Gadget<JJoystick>( );
        }

        public static async void VisibleHud ( )
        {
            if ( StreamWorker is null )
            {
                return;
            }

            await Task.Run( Visible );

            void Visible ( )
            {
                var upScreen = Configurator.Setting.UpScreen;
                MainV2.instance.GetLocalMeasure( );

                CrossHairView( );
                IndicatorsView( );
                ParametersView( );

                void CrossHairView( )
                {
                    switch ( Configurator.Setting.General.ECrossHairType )
                    {
                        case GCSViews.Setups.Models.Generals.ECrossHairType.Regular:
                            StreamWorker.HideCorrectionMarks( );
                            break;
                        case GCSViews.Setups.Models.Generals.ECrossHairType.Ballistic:
                            StreamWorker.ShowCorrectionMarks();
                            break;
                        default:
                            break;
                    }
                }

                void IndicatorsView ( )
                {
                    var indicators = upScreen.Indicators;

                    StreamWorker.Visible( EParam.GROUND_LEVEL, indicators.GroundLevel );
                    StreamWorker.Visible( EParam.ROLL_SCALE, indicators.RollScale );
                    StreamWorker.Visible( EParam.PITCH_SCALE, indicators.PitchScale );
                    StreamWorker.Visible( EParam.COMPASS, indicators.Compass );
                    StreamWorker.Visible( EParam.CROSS_MARK, indicators.CrossMark );
                }

                void ParametersView ( )
                {
                    var parameters = upScreen.Parameters;

                    StreamWorker.Visible( EParam.DRONE_NAME, parameters.UavId );
                    StreamWorker.Visible( EParam.SATELLITES, parameters.Satellites );
                    StreamWorker.Visible( EParam.SIGNAL_LEVEL, parameters.SignalLevel );
                    StreamWorker.Visible( EParam.INCLINATION, parameters.Inclination );
                    StreamWorker.Visible( EParam.LATITUDE, parameters.Latitude );
                    StreamWorker.Visible( EParam.LONGITUDE, parameters.Longitude );
                    StreamWorker.Visible( EParam.AZIMUTH, parameters.Azimuth );
                    StreamWorker.Visible( EParam.ALTITUDE_WRT_GROUND, parameters.AltitudeWrtGround );
                    StreamWorker.Visible( EParam.ALTITUDE_WRT_HOME, parameters.AltitudeWrtHome );
                    StreamWorker.Visible( EParam.HOME_DISTANCE, parameters.HomeDistance );
                    StreamWorker.Visible( EParam.HORIZONTAL_SPEED, parameters.HorizontalSpeed );
                    StreamWorker.Visible( EParam.VERTICAL_SPEED, parameters.VerticalSpeed );
                    StreamWorker.Visible( EParam.ROLL_ANGLE, parameters.RollAngle );
                    StreamWorker.Visible( EParam.PITCH_ANGLE, parameters.PitchAngle );
                    StreamWorker.Visible( EParam.RANGE_1, parameters.Range1 );
                    StreamWorker.Visible( EParam.RANGE_2, parameters.Range2 );
                    StreamWorker.Visible( EParam.CAMERA_H_ANGLE, parameters.CameraHAngle );
                    StreamWorker.Visible( EParam.CAMERA_V_ANGLE, parameters.CameraVAngle );
                    StreamWorker.Visible( EParam.BATTERY_LEVEL, parameters.BatteryLevel );
                    StreamWorker.Visible( EParam.BATTERY_VOLTAGE, parameters.BatteryVoltage );
                    StreamWorker.Visible( EParam.BATTERY_CAPACITY, parameters.BatteryCapacity );
                    StreamWorker.Visible( EParam.BATTERY_TIME_LEFT, parameters.BatteryTimeLeft );
                    StreamWorker.Visible( EParam.WIND_SPEED, parameters.WindSpeed );
                    StreamWorker.Visible( EParam.WIND_ANGLE, parameters.WindAngle );
                    StreamWorker.Visible( EParam.FLIGHT_PATH, parameters.FlightPath );
                    StreamWorker.Visible( EParam.FLIGHT_TIME, parameters.FlightTime );
                    StreamWorker.Visible( EParam.FLIGHT_MODE, parameters.FlightMode );
                    StreamWorker.Visible( EParam.ARMING_STATUS, parameters.FlightStatus );
                    StreamWorker.Visible( EParam.TARGET_WIDTH, parameters.TargetWidth );
                    StreamWorker.Visible( EParam.TARGET_HEIGHT, parameters.TargetHeight );
                    StreamWorker.Visible( EParam.TARGET_LATITUDE, parameters.TargetLatitude );
                    StreamWorker.Visible( EParam.TARGET_LONGITUDE, parameters.TargetLongitude );
                }
            }
        }
    }
}
