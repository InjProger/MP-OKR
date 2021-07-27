using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.Buttons
{
    public partial class ClickedButton : Button
    {
        private bool _clicked;

        public bool Clicked 
        {
            get => _clicked;
            set
            {
                _clicked = value;
                FlatStyle = _clicked ? FlatStyle.Flat : FlatStyle.Standard;
            }
        }

        public ClickedButton()
        {
            InitializeComponent();

            Clicked = false;
        }

        private void PressedButton_Click(object sender, EventArgs e)
        {
            Clicked = !Clicked;
        }
    }
}
