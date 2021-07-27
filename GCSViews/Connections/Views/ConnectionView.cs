
using MissionPlanner.Configs;
using MissionPlanner.GCSViews.Connections.Models;
using MissionPlanner.GCSViews.Connections.Models.Connect;
using MissionPlanner.GCSViews.Connections.Models.Files;
using MissionPlanner.GCSViews.Connections.Models.UAVs;
using MissionPlanner.Globals;
using MissionPlanner.Globals.OS;
using MissionPlanner.Joystick;
using MissionPlanner.Models.UAVs;
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads;
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Ammunations;
using MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.EmptyLoads;

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;

using UavContainer = MissionPlanner.Models.UAVs.Blocks.Gimbles.TargetLoads.Containers.Container;

namespace MissionPlanner.GCSViews.Connections.Views
{
    public partial class ConnectionView : Form
    {
        private Connection _connection;
        private UavDescription _uavDescription;
        private bool _isButtonClick;

        #region CONSTRUCTORS ============================================================================================================================

        public ConnectionView ( )
        {
            InitializeComponent( );
            
            DialogResult = DialogResult.Abort;

            _connection = Configurator.Connection;
            
            GlbContext.Joystick.Connector = new Connector( _connection.Joystick );
            GlbContext.Uav.Connector = new Connector( _connection.Uav );

            var uavNames = FilesReader.GetDevicesNames( );
            cmbUavModel.Items.AddRange( uavNames );
        }

        #endregion ======================================================================================================================================

        #region METHODS =================================================================================================================================

        void ControlEnabled ( bool enabled )
        {
            gbLeftWeapon.Enabled = gbRightWeapon.Enabled = enabled;
            rbNoneLeft.Enabled = rbNoneRight.Enabled = enabled;
            btnConnect.Enabled = enabled;
        }

        private void ConnectOk ( )
        {
            _isButtonClick = true;
            DialogResult = DialogResult.OK;

            UavCreate( );
            Close( );
        }

        private void ConnectNo ( )
        {
            UavCreate( );
            _isButtonClick = true;
            DialogResult = DialogResult.No;
        }

        private void UavCreate ( )
        {
            GlbContext.Uav.Device = new UAV( _uavDescription );
            UavConfiguration( GlbContext.Uav.Device );

            void UavConfiguration ( UAV uav )
            {
                if ( _uavDescription.Gimble is null )
                {
                    uav.TargetLoad = GetSelectedTargetLoad( );
                }
                else
                {
                    uav.Gimble = _uavDescription.Gimble;
                    uav.Gimble.TargetLoad = GetSelectedTargetLoad( );
                }

                TargetLoad GetSelectedTargetLoad ( )
                {
                    if ( cbPayload.Checked )
                    {
                        var container = _uavDescription.Container;
                        var weight = cmbWeight.Text.ToString( );

                        container.Weight = double.Parse( weight );

                        return container;
                    }
                    else
                    {
                        if ( !rbNoneLeft.Checked || !rbNoneRight.Checked )
                        {
                            var ammunation = _uavDescription.Ammunation;

                            if ( rbNoneLeft.Checked )
                            {
                                ammunation.LeftWeapon = null;
                            }
                            else
                            {
                                if ( rbEquivalentLeft.Checked )
                                {
                                    ammunation.IsLoaded = true;
                                    ammunation.LeftWeapon.IsEquivalent = true;
                                }

                                if ( rbCombatLeft.Checked )
                                {
                                    ammunation.IsLoaded = true;
                                    ammunation.LeftWeapon.IsEquivalent = false;
                                }

                                if ( rbUnloadedLeft.Checked )
                                {
                                    ammunation.LeftWeapon.IsLoaded = false;
                                }
                            }

                            if ( rbNoneRight.Checked )
                            {
                                ammunation.RightWeapon = null;
                            }
                            else
                            {
                                if ( rbEquivalentRight.Checked )
                                {
                                    ammunation.RightWeapon.IsLoaded = true;
                                    ammunation.RightWeapon.IsEquivalent = true;
                                }

                                if ( rbCombatRight.Checked )
                                {
                                    ammunation.RightWeapon.IsLoaded = true;
                                    ammunation.RightWeapon.IsEquivalent = false;
                                }

                                if ( rbNoneRight.Checked )
                                {
                                    ammunation.RightWeapon.IsLoaded = false;
                                }
                            }

                            return ammunation;
                        }
                    }

                    return new None();
                }
            }
        }

        private void ShowUavDescription ( )
        {
            FillCmbWeight( _uavDescription.Container );
            ShowAmmunation( _uavDescription.Ammunation );

            void FillCmbWeight ( UavContainer container )
            {
                cmbWeight.Items.Clear( );

                var maxLifedWeight = _uavDescription.FreeWeightWithContainer( );

                for ( var liftedWeight = maxLifedWeight; liftedWeight >= 0; liftedWeight -= 0.5 )
                {
                    var value = liftedWeight.ToString( );
                    cmbWeight.Items.Add( value );
                }

                if ( container != null )
                {
                    cmbWeight.Text = maxLifedWeight.ToString( );
                }
            }

            void ShowAmmunation ( Ammunation ammunation )
            {
                if ( ammunation != null )
                {
                    rbNoneLeft.Checked = true;
                    rbNoneRight.Checked = true;

                    gbLeftWeapon.Enabled = ammunation.LeftWeapon != null;
                    gbRightWeapon.Enabled = ammunation.RightWeapon != null;
                }
                else
                {
                    rbNoneLeft.Checked = rbNoneRight.Checked = false;
                    gbLeftWeapon.Enabled = gbRightWeapon.Enabled = false;
                }
            }
        }

        #endregion ======================================================================================================================================

        #region EVENTS HANDLERS =========================================================================================================================

        private void CmbUavModel_SelectedIndexChanged ( object sender, EventArgs e )
        {
            ControlEnabled( false );

            if ( cmbUavModel.SelectedIndex > -1 )
            {
                btnConnect.Enabled = true;

                var modelId = cmbUavModel.SelectedIndex + 1;
                var uavDeviceFileWorker = new UavDescriptionFileWorker( modelId );
                
                uavDeviceFileWorker.Open( );
                
                _uavDescription = uavDeviceFileWorker.UavDevice;

                ControlEnabled( true );
                ShowUavDescription( );
            }
        }

        private void ConnectionView_KeyDown ( object sender, KeyEventArgs e )
        {
            if ( e.Control && e.KeyCode == Keys.Enter )
            {
                ConnectOk( );
            }

            if ( e.KeyCode == Keys.Escape )
            {
                Close( );
            }
        }

        private void BtnConnect_Click ( object sender, EventArgs e )
        {
            ConnectOk( );
        }

        private void BtnWithoutConnection_Click ( object sender, EventArgs e )
        {
            if ( cmbUavModel.SelectedIndex > -1 )
            {
                ConnectNo( );
            }

            Close( );
        }

        private void ConnectionView_FormClosing ( object sender, FormClosingEventArgs e )
        {   
            if ( cmbUavModel.SelectedIndex > -1 )
            {
                if ( !_isButtonClick )
                {
                    ConnectNo( );
                    DialogResult = DialogResult.No;
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void RadioButtonChecked ( )
        {
            cbPayload.Checked = false;
            cmbWeight.Enabled = false;
        }

        private void RbCombatLeft_CheckedChanged ( object sender, EventArgs e )
        {
            RadioButtonChecked( );
        }

        private void RbEquivalentLeft_CheckedChanged ( object sender, EventArgs e )
        {
            RadioButtonChecked( );
        }

        private void RbUnloadedLeft_CheckedChanged ( object sender, EventArgs e )
        {
            RadioButtonChecked( );
        }

        private void RbNoneLeft_CheckedChanged ( object sender, EventArgs e )
        {

        }

        private void RbCombatRight_CheckedChanged ( object sender, EventArgs e )
        {
            RadioButtonChecked( );
        }

        private void RbEquivalentRight_CheckedChanged ( object sender, EventArgs e )
        {
            RadioButtonChecked( );
        }

        private void CbPayload_CheckedChanged ( object sender, EventArgs e )
        {
            cmbWeight.Enabled = true;

            if ( cbPayload.Checked )
            {
                rbNoneLeft.Checked = true;
                rbNoneRight.Checked = true;
                cbPayload.Checked = true;
            }
        }

        #endregion ======================================================================================================================================
    }
}