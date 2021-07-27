
using MissionPlanner.Controls.Buttons;
using MissionPlanner.Controls.TabMenus.Views.Tabs;

namespace MissionPlanner.Controls.TabMenus.Models
{
    public class Tab
    {
        public ClickedButton Button { get; set; }
        public TabItem TabItem { get; set; }

        public bool Visible
        {
            get => TabItem.Visible;
            set => TabItem.Visible = value;
        }

        public Tab ( ClickedButton button, TabItem tabItem )
        {
            Button = button;
            TabItem = tabItem;
        }

        public void Hide ( )
        {
            Button.Clicked = Visible = false;
        }

        public void Show()
        {
            Button.Clicked = Visible = true;
        }
    }
}
