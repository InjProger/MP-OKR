
using FileWork.Jsons;

using System.IO;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.Connections.Models.UAVs
{
    public class UavDescriptionFileWorker
    {
        public static UavDescriptionFileWorker This { get; set; }

        private readonly ConfigFileWorker<UavDescription> _UavConfigFileWorker;

        public UavDescription UavDevice
        {
            get => _UavConfigFileWorker.Object;
            set => _UavConfigFileWorker.Object = value;
        }

        public UavDescriptionFileWorker( int modelId )
        {
            var dirSeparator = Path.DirectorySeparatorChar;
            var file = Application.StartupPath + dirSeparator + "Devices" + dirSeparator + modelId + ".dvc";

            _UavConfigFileWorker = new ConfigFileWorker<UavDescription>( file );
        }

        public UavDescription Open ()
        {
            return _UavConfigFileWorker.Open();
        }
    }
}
