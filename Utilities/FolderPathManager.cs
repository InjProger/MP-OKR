
using System.IO;
using System.Windows.Forms;

namespace MissionPlanner.Utilities
{
    public static class FolderPathManager
    {
        public static readonly string Configs;
        public static readonly string Devices;
        public static readonly string Lang;

        static FolderPathManager()
        {
            var startupPath = Application.StartupPath;
            var dirSeparator = Path.DirectorySeparatorChar;
            var begPath = startupPath + dirSeparator;

            Configs = begPath + "cfg" + dirSeparator;
            Devices = begPath + "Devices" + dirSeparator;
            Lang    = begPath + "lang" + dirSeparator;
        }
    }
}
