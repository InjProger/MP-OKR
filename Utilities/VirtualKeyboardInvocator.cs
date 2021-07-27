using Other.Extensions;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Other.Extensions;
using System.Windows;

namespace MissionPlanner.Utilities
{
    public static class VirtualKeyboardInvocator
    {
        private static int _windowsCount = 0;

        private static bool Condition ( Control control )
        {
            switch ( control )
            {
                case TextBox tb : return true;
                case ComboBox cb : return ( control as ComboBox ).DropDownStyle == ComboBoxStyle.DropDown;
                default : return false;
            };
        }

        private static void ActionListener ( object sender, EventArgs e ) 
        {
            Process.Start( "onboard" );
        }

        public static void AddTextBoxClickListener ( )
        {
            var count = Application.OpenForms.Count;

            if ( count > _windowsCount )
            {
                var form = Application.OpenForms[ count - 1 ];
                
                form.Controls.Action<Control>( c => Condition( c ), a => a.Click += ActionListener );
            }

            _windowsCount = count;
        }
    }
}
