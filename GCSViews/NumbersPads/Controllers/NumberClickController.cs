using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.NumbersPads.Controllers
{
    public class NumberClickController<T>
    {
        private T _editControl;

        public NumberClickController ( T editControl )
        {
            _editControl = editControl;
        }

        private string GetNumberClick ( object sender )
        {
            var button = ( Button ) sender;
            return button.Name.Last( ).ToString( );
        }

        private void InsertInControl ( string number )
        {
            switch ( _editControl )
            {
                case TextBox textBox:
                    var selectPosition = textBox.SelectionStart;
                    textBox.Text.Insert( selectPosition, number );
                    break;
            }
        }

        public void NumberButtonClick ( object sender )
        {
            var number = GetNumberClick( sender );
            InsertInControl( number );
        }
    }
}
