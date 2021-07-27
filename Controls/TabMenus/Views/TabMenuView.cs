using MissionPlanner.Controls.Buttons;
using MissionPlanner.Controls.TabMenus.Models;

using System;
using System.Windows.Forms;

namespace MissionPlanner.Controls.TabMenus.Views
{
    public partial class TabMenuView : UserControl
    {
        public Tab  SelectTab;
        private bool _expand;

        public Tab[] Tabs { get; set; }

        public bool IsEditFlyToPoint
        { 
            get => mapEditTab.FlyToPointVisible;
            set => mapEditTab.FlyToPointVisible = value;
        }

        public bool Expand
        {
            get => _expand;
            set
            {
                _expand = value;

                if ( value )
                {
                    RollDown( );
                }
                else
                {
                    RollUp( );
                }
            }
        }

        public delegate void RollingTabHandler( object sender, EventArgs e );

        public event RollingTabHandler RollingTab;

        public TabMenuView ( )
        {
            InitializeComponent( );

            _expand    = true;
            Tabs       = CreateTabsList( );
            SelectTab = Tabs[ 0 ];

            Tab[] CreateTabsList ( )
            {
                return new Tab[]
                {
                    new Tab ( btnTask, taskTab ),
                    new Tab ( btnView, viewTab ),
                    new Tab ( btnAirfields, airfieldsTab ),
                    new Tab ( btnSettings, settingsTab ),
                    new Tab ( btnBlackBox, blackBoxTab )
                };
            }
        }

        private void SelectTabButtonClick ( object sender )
        {
            var newSelectTab = GetNewSelectedTab( );

            if ( SelectTab.TabItem.Name == newSelectTab.TabItem.Name )
            {
                if ( newSelectTab.Visible )
                {
                    RollUp( );
                }
                else
                {
                    RollDown( );
                }
            }
            else
            {
                RollUp( );
                SelectTab = newSelectTab;
                RollDown( );
            }

            Tab GetNewSelectedTab ( )
            {
                var clickedButton = sender as ClickedButton;
                var selectedTabIndex = int.Parse( clickedButton.Tag.ToString( ) );
                return Tabs[ selectedTabIndex ];
            }
        }

        private void PbTabUp_Click ( object sender, EventArgs e )
        {
            SelectTab.Hide( );
            Expand = false;
        }

        private void PbTabDown_Click ( object sender, EventArgs e )
        {
            SelectTab.Show( );
            Expand = true;
        }

        private void BtnTask_Click ( object sender, EventArgs e )
        {
            SelectTabButtonClick( sender );
        }

        private void BtnView_Click ( object sender, EventArgs e )
        {
            SelectTabButtonClick( sender );
        }

        private void BtnAirfields_Click ( object sender, EventArgs e )
        {
            SelectTabButtonClick( sender );
        }

        private void BtnArchive_Click ( object sender, EventArgs e )
        {
            SelectTabButtonClick( sender );
        }

        private void BtnSettings_Click ( object sender, EventArgs e )
        {
            SelectTabButtonClick( sender );
        }

        public void RollUp ( )
        {
            SelectTab.Hide( );
            pbTabDown.Show( );
            pbTabUp.Hide( );
            Height = 53;

            RollingTab?.Invoke( this, new EventArgs() );
        }

        public void RollDown ( )
        {
            SelectTab.Show( );
            pbTabDown.Hide( );
            pbTabUp.Show( );
            Height = 142;

            RollingTab?.Invoke( this, new EventArgs( ) );
        }

        private void BtnBlackBox_Click ( object sender, EventArgs e )
        {
            SelectTabButtonClick( sender );
        }
    }
}
