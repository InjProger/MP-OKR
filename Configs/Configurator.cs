
using FileWork.Jsons;

using MissionPlanner.GCSViews.Connections.Models.Connect;
using MissionPlanner.GCSViews.Setups.Models;
using MissionPlanner.Utilities;
using MissionPlanner.Utilities.Measurements;

namespace MissionPlanner.Configs
{
    public static class Configurator
    {
        private static readonly ConfigFileWorker<App>         _appConfigFileWorker;
        private static readonly ConfigFileWorker<Setting>     _settingConfigFileWorker;
        private static readonly ConfigFileWorker<Connection>  _connectionConfigFileWorker;
        private static readonly ConfigFileWorker<Measurement> _measurementFileWorker;

        public static App App
        { 
            get => _appConfigFileWorker.Object;
            set => _appConfigFileWorker.Object = value;
        }

        public static Setting Setting 
        {
            get => _settingConfigFileWorker.Object;
            set => _settingConfigFileWorker.Object = value;
        }

        public static Connection Connection
        {
            get => _connectionConfigFileWorker.Object;
            set => _connectionConfigFileWorker.Object = value;
        }

        public static Measurement Measurement
        {
            get => _measurementFileWorker.Object;
            set => _measurementFileWorker.Object = value;
        }

        static Configurator ( )
        {
            var appConfigfile        = FolderPathManager.Configs + "App.cfg";
            var settingConfigfile    = FolderPathManager.Configs + "Settings.cfg";
            var connectionConfigfile = FolderPathManager.Configs + "Connection.cfg";
            var measurementfile      = FolderPathManager.Lang    + "Measurements";

            _appConfigFileWorker        = new ConfigFileWorker<App>        ( appConfigfile     );
            _settingConfigFileWorker    = new ConfigFileWorker<Setting>    ( settingConfigfile );
            _connectionConfigFileWorker = new ConfigFileWorker<Connection> ( connectionConfigfile );
            _measurementFileWorker      = new ConfigFileWorker<Measurement>( measurementfile );
        }

        public static void Open ( )
        {
            App         = _appConfigFileWorker.Open( );
            Setting     = _settingConfigFileWorker.Open( );
            Connection  = _connectionConfigFileWorker.Open( );
            Measurement = _measurementFileWorker.Open( );
        }

        public static void Save ( )
        {
            _appConfigFileWorker.Save( );
            _settingConfigFileWorker.Save( );
            _connectionConfigFileWorker.Save( );
        }
    }
}
