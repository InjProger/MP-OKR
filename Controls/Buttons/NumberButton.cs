using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls.Buttons
{
    public partial class NumberButton : Button
    {
        private const int MAX_NUMBER = 2;

        private int clickCount;

        public int Number 
        {
            get => clickCount;
            set
            {
                clickCount = value;
                Text = clickCount.ToString();
            }
        }

        public NumberButton()
        {
            InitializeComponent();
            Number = 0;
            Text = Number.ToString();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Number = Number == MAX_NUMBER ? 0 : Number + 1;
            Text = Number.ToString();
        }
    }
}
