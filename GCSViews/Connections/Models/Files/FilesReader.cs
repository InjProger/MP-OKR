namespace MissionPlanner.GCSViews.Connections.Models.Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MissionPlanner.GCSViews.Connections.Models.UAVs;

    public static class FilesReader
    {
        private static List<FileItem> GetFilesItems ( )
        {
            var itemsList = new List<FileItem>( );
            var dirSeparator = Path.DirectorySeparatorChar;
            var files = Directory.GetFiles( Application.StartupPath + dirSeparator + "Devices" );

            foreach ( var file in files )
            {
                var intNumber = int.Parse( Path.GetFileNameWithoutExtension( file ) );
                var uavDeviceFileWorker = new UavDescriptionFileWorker( intNumber );
                var uav = uavDeviceFileWorker.Open( );
                var uavName = uav.LocalNames.GetLocalName( );
                var fileItem = new FileItem( intNumber, uavName );

                itemsList.Add( fileItem );
            }

            return itemsList;
        }

        public static string[] GetDevicesNames()
        {
            var itemsList = GetFilesItems( );

            var items = from item in itemsList
                        orderby item.Id
                        select item.Name;

            return items.ToArray( );
        }
    }
}
