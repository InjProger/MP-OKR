using System;
using System.Windows.Forms;

namespace MissionPlanner.Joystick
{
    public partial class Joy_Do_Set_Relay : Form
    {
        public Joy_Do_Set_Relay(string name)
        {
            InitializeComponent();

            Utilities.ThemeManager.ApplyThemeTo(this);

            this.Tag = name;

            var config = MainV2.Joystick.getButton(int.Parse(name));

            numericUpDown1.Text = config.p1.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var config = MainV2.Joystick.getButton(int.Parse(this.Tag.ToString()));

            config.p1 = (float)numericUpDown1.Value;

            MainV2.Joystick.setButton(int.Parse(this.Tag.ToString()), config);
        }
    }
}