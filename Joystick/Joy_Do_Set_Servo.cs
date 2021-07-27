using System;
using System.Windows.Forms;

namespace MissionPlanner.Joystick
{
    public partial class Joy_Do_Set_Servo : Form
    {
        public Joy_Do_Set_Servo(string name)
        {
            InitializeComponent();

            Utilities.ThemeManager.ApplyThemeTo(this);

            this.Tag = name;

            var config = MainV2.Joystick.getButton(int.Parse(name));

            numericUpDownservono.Text = config.p1.ToString();
            numericUpDownpwm.Text = config.p2.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var config = MainV2.Joystick.getButton(int.Parse(this.Tag.ToString()));

            config.p1 = (float)numericUpDownservono.Value;

            MainV2.Joystick.setButton(int.Parse(this.Tag.ToString()), config);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            var config = MainV2.Joystick.getButton(int.Parse(this.Tag.ToString()));

            config.p2 = (float)numericUpDownpwm.Value;

            MainV2.Joystick.setButton(int.Parse(this.Tag.ToString()), config);
        }
    }
}