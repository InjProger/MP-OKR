
using AltitudeAngelWings.Models;

using MissionPlanner.Utilities.Localizable;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MissionPlanner.Utilities.Localizeble
{
    public class LocalNames 
    {
        public List<LocalName> Names { get; set; }

        public LocalNames ( )
        {

        }

        public LocalNames ( List<LocalName> names )
        {
            Names = names;
        }

        public string GetLocalName ( )
        {
            return Names.Where( n => n.Local == CultureInfo.CurrentCulture.Name ).First( ).Name;
        }
    }
}
