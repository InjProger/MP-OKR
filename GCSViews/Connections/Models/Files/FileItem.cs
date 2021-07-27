namespace MissionPlanner.GCSViews.Connections.Models.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FileItem ( )
        {

        }

        public FileItem ( int id, string name )
        {
            Id = id;
            Name = name;
        }
    }
}
