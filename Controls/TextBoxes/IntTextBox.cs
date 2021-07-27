using System;
using System.ComponentModel;
using System.Windows.Forms;

using static MissionPlanner.Utilities.MathAddition;

namespace MissionPlanner.Controls.TextBoxes
{
    public partial class IntTextBox : TextBox
    {
        private int _value;
        private int _min;
        private int _max;

        public int Value
        {
            get => _value;
            set
            {
                if (!IsInRange(value, _min, _max))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _value = value;
                Text = value.ToString();
            }
        }

        public int Min
        {
            get => _min;
            set
            {
                if (value > _max)
                {
                    var name = nameof(value);
                    var message = $"{name} is more then MAX";
                    throw new ArgumentException(name, message);
                }

                _min = value;
            }
        }

        public int Max
        {
            get => _max;
            set
            {
                if (value < _min)
                {
                    var name = nameof(value);
                    var message = $"{name} is less then MIN";
                    throw new ArgumentException(name, message);
                }

                _max = value;
            }
        }

        public IntTextBox()
        {
            InitializeComponent();
            Text = Value.ToString();
            _min = 0;
            _max = 100;
        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Value = 0;
            }
        }

        private void IntTextBox_Validating(object sender, CancelEventArgs e)
        {
            var isParse = int.TryParse(Text, out int value);
            e.Cancel = !(isParse && IsInRange(value, _min, _max));
        }
    }
}
