
using MissionPlanner.Utilities;

using System.Collections.Generic;
using System.IO;

namespace MissionPlanner.GCSViews.Connections.Models.UAVs
{
    public static class UavDescriptionWorker
    {
        public static List<string> GetUavModels ( )
        {   
            var path = FolderPathManager.Devices + Path.DirectorySeparatorChar;
            var files = Directory.GetFiles( path );
            var uavModels = new List<string>( files.Length );

            foreach ( string file in files )
            {
                var fileName = Path.GetFileNameWithoutExtension( file );
                uavModels.Add( fileName );
            }

            return uavModels;
        }
    }
}
