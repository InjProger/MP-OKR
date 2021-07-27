using MissionPlanner.GCSViews.Setups.Models.Interfaces;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MissionPlanner.Utilities.Measurements
{   
    public class Measurement
    {
        public List<LocalMeasure> Measures { get; set; }

        public Measurement ( )
        {

        }

        public Measurement ( List<LocalMeasure> measures )
        {
            Measures = measures;
        }

        public LocalMeasure GetCurrentMeasure ( )
        {
            return Measures.Where( n => n.Local == CultureInfo.CurrentCulture.Name ).First( );
        }
    }
}
