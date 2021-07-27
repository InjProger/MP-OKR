using System;
using System.Windows.Forms;

using static System.Windows.Forms.Control;

namespace Other.Extensions
{
    public static class ControlCollectionExtension
    {
        public static Control Action<T>(this ControlCollection controlCollection, Func<T, bool> condition, Action<T> action)
            where T : Control
        {
            Control selectControl = null;

            foreach (Control control in controlCollection)
            {
                if (condition(control as T))
                {
                    action(control as T);
                    selectControl = control;
                }

                control.Controls.Action( condition, action );
            }

            return selectControl;
        }
    }
}
