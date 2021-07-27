
using MissionPlanner.Configs;

using MissionPlanner.GCSViews.Setups.Models.Generals;
using MissionPlanner.GCSViews.Setups.Models.Generals.Parts;
using MissionPlanner.GCSViews.Setups.Models.Interfaces;
using MissionPlanner.GCSViews.Setups.Models.UpScreens;
using MissionPlanner.GCSViews.Setups.Models;

using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Diagnostics;
using MissionPlanner.GCSViews.Setups.Models.UpScreens.Parts;
using MissionPlanner.Globals;
using MissionPlanner.Utilities.Streams;
using System.Collections.Generic;
using System.Linq;
using MissionPlanner.Utilities;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MissionPlanner.GCSViews.Setups.Views
{
    public partial class SettingView : Form
    {
        #region FIELDS

        private int countCheckedComboboxes = 0;

        private int _selectLanguageIndex;

        private string[] Languages = { "ru", "en" };

        #endregion

        #region CONSTRUCTORS

        public SettingView ( )
        {
            InitializeComponent( );

            tabControl.TabPages.RemoveAt( 2 );

            LanguagesCmbFilling( );
            CommandsCmbFilling( );
        }

        #endregion

        #region METHODS

        private void LanguagesCmbFilling ( )
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;

            foreach ( var lang in Languages ) 
            {
                cmbLanguage.Items.Add( lang );
            } 

            cmbLanguage.SelectedItem = currentCulture;
            _selectLanguageIndex = cmbLanguage.SelectedIndex;
        }

        private int ConvertHomeReturnSpeedToMerest ( int hrs )
        {
            return hrs / 100;
        }

        private int ConvertHomeReturnSpeedToSantimeters ( int hrs )
        {
            return hrs * 100;
        }

        public enum Actions {

            None = 0,
            Land = 1,
            ReturnToLaunch = 2
        }

        private void CommandsCmbFilling ( )
        {
            cmbLowBatteryActions.DataSource = Enum.GetValues( typeof( Actions ) );
            cmbCrtBatteryActions.DataSource = Enum.GetValues( typeof( Actions ) );
            /*var resourceManager = new ResourceManager( GetType( ).FullName, Assembly.GetExecutingAssembly( ) );
            var None = resourceManager.GetString( "NoneText", CultureInfo.CurrentUICulture );
            var Land = resourceManager.GetString( "LandText", CultureInfo.CurrentUICulture );
            var Rtl = resourceManager.GetString( "RtlText", CultureInfo.CurrentUICulture );*/
        }


        private void CheckedGroupIndicatorsGetState ( CheckBox group, int state, int countItems )
        {
            cbIndicators.CheckedChanged -= cbIndicators_CheckedChanged;

            if ( state == 0 )
            {
                group.ThreeState = false;
                group.Checked = false;
            }
            else
            {
                if ( state == countItems )
                {
                    group.ThreeState = false;
                    group.CheckState = CheckState.Checked;
                }
                else
                {
                    group.ThreeState = true;
                    group.CheckState = CheckState.Indeterminate;
                }
            }

            cbIndicators.CheckedChanged += cbIndicators_CheckedChanged;

        }

        private void CheckedGroupTargetGetState ( CheckBox group, int state, int countItems )
        {
            cbTargetParam.CheckedChanged -= cbTargetParam_CheckedChanged;

            if ( state == 0 )
            {
                group.ThreeState = false;
                group.Checked = false;
            }
            else
            {
                if ( state == countItems )
                {
                    group.ThreeState = false;
                    group.CheckState = CheckState.Checked;
                }
                else
                {
                    group.ThreeState = true;
                    group.CheckState = CheckState.Indeterminate;
                }
            }

            cbTargetParam.CheckedChanged += cbTargetParam_CheckedChanged;
        }

        private void CheckedGroupBatteryGetState ( CheckBox group, int state, int countItems )
        {
            cbBattery.CheckedChanged -= cbBattery_CheckedChanged;

            if ( state == 0 )
            {
                group.ThreeState = false;
                group.Checked = false;
            }
            else
            {
                if ( state == countItems )
                {
                    group.ThreeState = false;
                    group.CheckState = CheckState.Checked;
                }
                else
                {
                    group.ThreeState = true;
                    group.CheckState = CheckState.Indeterminate;
                }
            }

            cbBattery.CheckedChanged += cbBattery_CheckedChanged;
        }

        private Setting CreateSetting ( )
        {
            return new Setting
            {   
                AimPoint = Configurator.Setting?.AimPoint ?? new Alignments.Point(),
                General = CreateGeneral( ),
                Interface = CreateInterface( ),
                UpScreen = CreateUpScreen( )
            };
            
            General CreateGeneral ( )
            {
                return new General
                {
                    UseAlternateAirfieldStartPlace = cbUseAlternateAirfieldStartPlace.Checked,
                    CheckAlternateAirfields = cbCheckAlternateAirfields.Checked,
                    HomeReturnSpeed = int.Parse( tbHomeReturnSpeed.Text ),
                    AutoMode = CreateAutoMode( ),
                    LowBatteryActions = CreateLowBatteryActions( ),
                    EIkrlFailtureActions = CreateEIkrlFailtureActions( ),
                    ECrossHairType = CrateCrossHairType( )
                };

                AutoMode CreateAutoMode ( )
                {
                    return new AutoMode
                    {
                        Height = int.Parse( tbHeight.Text ),
                        Speed = int.Parse( tbSpeed.Text ),
                        PatrolRadius = int.Parse( tbPatrolRadius.Text ),
                        HangTime = int.Parse( tbHangTime.Text ),
                        InstructionIterationCount = int.Parse( tbIterationInstructionCount.Text ),
                        GimbleAngle = Configurator.Setting.General.AutoMode.GimbleAngle
                    };
                }

                ECrossHairType CrateCrossHairType ( )
                {
                    if ( rbRegular.Checked )
                    {
                        return ECrossHairType.Regular;
                    }

                    return ECrossHairType.Ballistic;
                }

                LowBatteryActions CreateLowBatteryActions ( )
                {
                    return new LowBatteryActions( )
                    {
                        lowBatteryAction = getIndexAction(cmbLowBatteryActions),
                        crtBatteryAction = getIndexAction(cmbCrtBatteryActions)
                    };
                }

                int getIndexAction (ComboBox comboBox ) 
                {
                    int index = 0;
                    var command = comboBox.SelectedValue;
                    switch ( command ) {
                        case Actions.None : index = 0;
                            break;
                        case Actions.Land : index = 1;
                            break;
                        case Actions.ReturnToLaunch : index = 2;
                            break;
                            }
                        return index ;
                }

                EIkrlFailtureActions CreateEIkrlFailtureActions ( )
                {
                    if ( rbIkrlTakeoffPoint.Checked )
                    {
                        return EIkrlFailtureActions.TakeoffPoint;
                    }

                    return EIkrlFailtureActions.AutoLanding;
                }
            }

            Interface CreateInterface ( )
            {
                return new Interface
                {
                    ECoordinateSystem = CreateECoordinateSystem( ),
                    ESpeed = CreateESpeed( )
                };

                ECoordinateSystem CreateECoordinateSystem ( )
                {
                    if ( rbWGS_84.Checked ) return ECoordinateSystem.WGS_84;
                    if ( rbSC_42.Checked ) return ECoordinateSystem.SC_42;
                    return ECoordinateSystem.WGS_84_Deg;
                }

                ESpeed CreateESpeed ( )
                {
                    if ( rbM_S.Checked ) return ESpeed.M_s;
                    else return ESpeed.Km_h;
                }
            }

            UpScreen CreateUpScreen ( )
            {
                return new UpScreen
                {
                    Indicators = CreateIndicators( ),
                    Parameters = CreateParameters( )
                };

                Indicarots CreateIndicators ( )
                {
                    return new Indicarots
                    {
                        GroundLevel = cbGroundLevel.Checked,
                        RollScale = cbRollScale.Checked,
                        PitchScale = cbPitchScale.Checked,
                        Compass = cbCompass.Checked,
                        CrossMark = cbCrossMark.Checked
                    };
                }

                Parameters CreateParameters ( )
                {
                    return new Parameters
                    {
                        Satellites = cbSatellites.Checked,
                        SignalLevel = cbSignalLevel.Checked,
                        Latitude = cbLatitude.Checked,
                        Longitude = cbLongitude.Checked,
                        Azimuth = cbAzimuth.Checked,
                        AltitudeWrtGround = cbAltitudeWrtGround.Checked,
                        AltitudeWrtHome = cbAltitudeWrtHome.Checked,
                        HomeDistance = cbHomeDistance.Checked,
                        HorizontalSpeed = cbHorizontalSpeed.Checked,
                        VerticalSpeed = cbVerticalSpeed.Checked,
                        RollAngle = cbRollAngle.Checked,
                        PitchAngle = cbPitchAngle.Checked,
                        Range1 = cbRange1.Checked,
                        Range2 = cbRange2.Checked,
                        CameraHAngle = cbCameraHAngle.Checked,
                        CameraVAngle = cbCameraVAngle.Checked,
                        BatteryLevel = cbBatteryLevel.Checked,
                        BatteryVoltage = cbBatteryVoltage.Checked,
                        BatteryCapacity = cbBatteryCapacity.Checked,
                        BatteryTimeLeft = cbBatteryTimeLeft.Checked,
                        WindSpeed = cbWindSpeed.Checked,
                        WindAngle = cbWindAngle.Checked,
                        FlightPath = cbFlightPath.Checked,
                        FlightTime = cbFlightTime.Checked,
                        FlightMode = cbFlightMode.Checked,
                        FlightStatus = cbWeaponStatus.Checked,
                        TargetWidth = cbTargetWidth.Checked,
                        TargetHeight = cbTargetHeight.Checked,
                        TargetLatitude = cbTarLat.Checked,
                        TargetLongitude = cbTarLon.Checked
                    };
                }
            }
        }

        #endregion

        #region EVENTS_HANDLERS

        private void SettingView_Load ( object sender, EventArgs e )
        {
            var settings = Configurator.Setting;

            GeneralFill( settings.General );
            InterfaceFill( settings.Interface );
            UpScreenFill( settings.UpScreen );

            if ( GlbContext.AppMode == EAppMode.user )
            {
                tabControl.TabPages.Remove( tpUpScreen );
            }

            if ( MainV2.instance.IsConnected )
            {
                btnGpsOn.Enabled = true;

                if ( GlbContext.AppMode == EAppMode.admin )
                {
                    lblIdUav.Enabled = tbIdUav.Enabled = true;
                }

                if ( MainV2.ComPort.MAV.cs.gpsstatus > 1 )
                {
                    btnGpsOff.Show( );
                    btnGpsOn.Hide( );
                }

                lblHomeReturnSpeed.Show( );
                tbHomeReturnSpeed.Show( );
                gbCrossHairType.Show( );
                cbUseAlternateAirfieldStartPlace.Show( );
                gbLowBatteryActions.Show( );
                gbIkrlFailureActions.Show( );
                gbGpsFailtureActions.Show( );

                LoadUavParams( );
            }

            void GeneralFill ( General general )
            {
                cbUseAlternateAirfieldStartPlace.Checked = general.UseAlternateAirfieldStartPlace;
                cbCheckAlternateAirfields.Checked = general.CheckAlternateAirfields;

                AutoMode( general.AutoMode );
                CrossHire( general.ECrossHairType );

                void AutoMode( AutoMode autoMode )
                {
                    tbHeight.Text                    = autoMode.Height.ToString( );
                    tbSpeed.Text                     = autoMode.Speed.ToString( );
                    tbPatrolRadius.Text              = autoMode.PatrolRadius.ToString( );
                    tbHangTime.Text                  = autoMode.HangTime.ToString( );
                    tbIterationInstructionCount.Text = autoMode.InstructionIterationCount.ToString( );
                }

                void CrossHire ( ECrossHairType eCrossHairType )
                {
                    switch ( eCrossHairType )
                    {
                        case ECrossHairType.Regular:
                            rbRegular.Checked = true;
                            break;
                        case ECrossHairType.Ballistic:
                            rbBallistic.Checked = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            void InterfaceFill ( Interface @interface )
            {
                ECoordinateSystemFill( @interface.ECoordinateSystem );
                ESpeedFill( @interface.ESpeed );

                void ECoordinateSystemFill ( ECoordinateSystem eCoodrinateSystem )
                {
                    switch ( eCoodrinateSystem )
                    {
                        case ECoordinateSystem.WGS_84:
                            rbWGS_84.Checked = true;
                            break;
                        case ECoordinateSystem.SC_42:
                            rbSC_42.Checked = true;
                            break;
                        case ECoordinateSystem.WGS_84_Deg:
                            rbWgs84Deg.Checked = true;
                            break;
                    }
                }

                void ESpeedFill ( ESpeed eSpeed )
                {
                    switch ( eSpeed )
                    {
                        case ESpeed.M_s :
                            rbM_S.Checked = true;
                            break;
                        case ESpeed.Km_h :
                            rbKm_h.Checked = true;
                            break;
                    }
                }
            }

            void UpScreenFill ( UpScreen upScreen )
            {
                cbGroundLevel.Checked = upScreen.Indicators.GroundLevel;
                cbRollScale.Checked   = upScreen.Indicators.RollScale;
                cbPitchScale.Checked  = upScreen.Indicators.PitchScale;
                cbCompass.Checked     = upScreen.Indicators.Compass;
                cbCrossMark.Checked   = upScreen.Indicators.CrossMark;
            }

            void LoadUavParams ( )
            {
                var findedValues = MainV2.ComPort.MAV.param.Where( p => p.Name == "RC16_MAX" || p.Name == "RC16_TRIM" || p.Name == "FS_GCS_ENABLE" || p.Name == "BATT_FS_CRT_ACT" || p.Name == "BATT_FS_LOW_ACT" || p.Name == "RALLY_INCL_HOME" || p.Name == "RTL_SPEED" || p.Name == "FS_EKF_THRESH" || p.Name == "CIRCLE_RADIUS" );
                var rallyIncl = (int) findedValues.Where( p => p.Name == "RALLY_INCL_HOME" ).First( ).Value;
                var homeReturnSpeed = (int) findedValues.Where( p => p.Name == "RTL_SPEED" ).First( ).Value;
                var begPart = findedValues.Where( p => p.Name == "RC16_MAX" ).First( ).Value;
                var endPart = findedValues.Where( p => p.Name == "RC16_TRIM" ).First( ).Value;
                var gpsFailtureAction = (int) findedValues.Where( p => p.Name == "FS_GCS_ENABLE" ).First( ).Value;
                var crtBat = (int) findedValues.Where( p => p.Name == "BATT_FS_CRT_ACT" ).First( ).Value;
                var lowBat = (int) findedValues.Where( p => p.Name == "BATT_FS_LOW_ACT" ).First( ).Value;
                //var percentVoltLanding = CalcPercentOfVolt( mavPercentVoltLanding );
                //var percentVoltReturn = CalcPercentOfVolt( mavPercentVoltReturn );
                var gpsFailtureActionValue = findedValues.Where( p => p.Name == "FS_EKF_THRESH" ).First( ).Value;
                var circleRadius = findedValues.Where( p => p.Name == "CIRCLE_RADIUS" ).First( ).Value;

                cbUseAlternateAirfieldStartPlace.Checked = rallyIncl == 1;
                tbHomeReturnSpeed.Text = ConvertHomeReturnSpeedToMerest( homeReturnSpeed ).ToString();
                tbIdUav.Text = settings.General.AutoMode.UavId;
                cmbLowBatteryActions.SelectedIndex = lowBat;
                cmbCrtBatteryActions.SelectedIndex = crtBat;
                tbPatrolRadius.Text =  ( circleRadius / 100.0 ).ToString();

                switch ( gpsFailtureAction )
                {
                    case 5:
                        rbIkrlAutoLanding.Checked = true;
                        break;
                    case 1:
                        rbIkrlTakeoffPoint.Checked = true;
                        break;
                }

                switch ( gpsFailtureActionValue )
                {
                    case 0:
                        rbLanding.Checked = true;
                        break;
                    case 0.8:
                        rbAutoManeuvering.Checked = true;
                        break;
                }

                int CalcPercentOfVolt ( double voltage )
                {  
                    var battery = GlbContext.Uav.Device.Battery;

                    if ( voltage == 0 )
                    {
                        return 0;
                    }
                    else
                    {
                        return ( int ) ( ( voltage - battery.VoltageMin ) / ( battery.VoltageMax - battery.VoltageMin ) * 100 );
                    }
                }
            }
        }

        private void BtnOk_Click ( object sender, EventArgs e )
        {
            var isEqualCulture = CultureInfo.CurrentCulture.Name == cmbLanguage.Text;

            Configurator.Setting = CreateSetting( );
            Parallel.Invoke( FileSave, UpdateHud, UpdateUav );

            Close( );
            
            void UpdateHud ( )
            {
                FlightPlanner.Instance.CoordSystemSelector( );
                GlbContext.VisibleHud( );
            }

            void FileSave ( )
            {
                Configurator.Save( );
            }

            void UpdateUav ( )
            {
                if ( MainV2.instance.IsConnected )
                {
                    var useStartPlace = Configurator.Setting.General.UseAlternateAirfieldStartPlace ? 1 : 0;
                    var homeReturnSpeed = ConvertHomeReturnSpeedToSantimeters( Configurator.Setting.General.HomeReturnSpeed );
                    var begPart = float.Parse( tbIdUav.Text.Substring( 0, 4 ) );
                    var endPart = float.Parse( tbIdUav.Text.Substring( 4 ) );
                    var gpsFailtureActionn = rbLanding.Checked ? 0 : 0.8;
                    var circleRadius = int.Parse( tbPatrolRadius.Text ) * 100;

                    MainV2.ComPort.setParam( "RALLY_INCL_HOME", useStartPlace );
                    MainV2.ComPort.setParam( "FS_EKF_THRESH", gpsFailtureActionn );
                    MainV2.ComPort.setParam( "RC16_MAX", begPart );
                    MainV2.ComPort.setParam( "RC16_TRIM", endPart );
                    MainV2.instance.UpdateAutoMode( Configurator.Setting.General.AutoMode );
                    MainV2.ComPort.setParam( "RTL_SPEED", homeReturnSpeed );
                    MainV2.ComPort.setParam( "BATT_FS_CRT_ACT", Configurator.Setting.General.LowBatteryActions.crtBatteryAction );
                    MainV2.ComPort.setParam( "BATT_FS_LOW_ACT", Configurator.Setting.General.LowBatteryActions.lowBatteryAction );
                    MainV2.ComPort.setParam( "FS_GCS_ENABLE", ( int ) Configurator.Setting.General.EIkrlFailtureActions );
                    MainV2.ComPort.setParam( "CIRCLE_RADIUS", circleRadius );
                }

                if ( _selectLanguageIndex != cmbLanguage.SelectedIndex )
                {
                    ShowMsgBox( );

                    Enabled = false;

                    MainV2.instance.Changelanguage( new CultureInfo( cmbLanguage.SelectedItem.ToString( ) ) );
                    GlbContext.StreamWorker?.Dispose( );
                    MainV2.instance.Close( );
                    Application.Exit( );
                    Process.Start( "MissionPlanner.exe" );

                    Enabled = true;
                }
            }

            void ShowMsgBox ( )
            {
                var resourceManager = new ResourceManager( GetType( ).FullName, Assembly.GetExecutingAssembly( ) );
                var text = resourceManager.GetString( "mbLanguageText", CultureInfo.CurrentUICulture );
                var caption = resourceManager.GetString( "mbLanguageCaption" );

                MessageBox.Show( text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
        }

        private void BtnCancel_Click ( object sender, EventArgs e )
        {
            Close( );
        }

        private void SettingsView_FormClosing ( object sender, FormClosingEventArgs e )
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void cbIndicators_CheckedChanged ( object sender, EventArgs e )
        {
            cbGroundLevel.Enabled = cbRollScale.Enabled = cbCompass.Enabled = cbPitchScale.Enabled = cbCrossMark.Enabled = false;
            cbGroundLevel.Checked = cbRollScale.Checked = cbCompass.Checked = cbPitchScale.Checked = cbCrossMark.Checked = cbIndicators.Checked;
            cbGroundLevel.Enabled = cbRollScale.Enabled = cbCompass.Enabled = cbPitchScale.Enabled = cbCrossMark.Enabled = true;

            if ( !cbIndicators.Checked )
            {
                countCheckedComboboxes = 0;
            }
        }

        private void CheckBoxIndicators_Checked ( object sender, CheckBox group, int countItems )
        {
            var checkbox = sender as CheckBox;

            countCheckedComboboxes += checkbox.Checked ? 1 : -1;

            CheckedGroupIndicatorsGetState( group, countCheckedComboboxes, countItems );
        }

        private void cbPitchScale_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxIndicators_Checked( sender, cbIndicators, 5 );
        }

        private void cbRollScale_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxIndicators_Checked( sender, cbIndicators, 5 );
        }

        private void cbCompass_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxIndicators_Checked( sender, cbIndicators, 5 );
        }

        private void cbGroundLevel_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxIndicators_Checked( sender, cbIndicators, 5 );
        }

        private void cbCrossMark_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxIndicators_Checked( sender, cbIndicators, 5 );
        }

        private void cbTargetParam_CheckedChanged ( object sender, EventArgs e )
        {
            cbTarLat.Enabled = cbTarLon.Enabled = cbTargetHeight.Enabled = cbTargetWidth.Enabled = false;
            cbTarLat.Checked = cbTarLon.Checked = cbTargetHeight.Checked = cbTargetWidth.Checked = cbTargetParam.Checked;
            cbTarLat.Enabled = cbTarLon.Enabled = cbTargetHeight.Enabled = cbTargetWidth.Enabled = true;

            if ( !cbTargetParam.Checked )
            {
                countCheckedComboboxes = 0;
            }

        }

        private void CheckBoxTarget_Checked ( object sender, CheckBox group, int countItems )
        {
            var checkbox = sender as CheckBox;

            countCheckedComboboxes += checkbox.Checked ? 1 : -1;

            CheckedGroupTargetGetState( group, countCheckedComboboxes, countItems );
        }

        private void cbTargetHeight_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxTarget_Checked( sender, cbTargetParam, 4 );
        }

        private void cbTarLon_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxTarget_Checked( sender, cbTargetParam, 4 );
        }

        private void cbTargetWidth_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxTarget_Checked( sender, cbTargetParam, 4 );
        }

        private void cbTarLat_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxTarget_Checked( sender, cbTargetParam, 4 );
        }

        private void cbBattery_CheckedChanged ( object sender, EventArgs e )
        {
            cbBatteryCapacity.Enabled = cbBatteryLevel.Enabled = cbBatteryTimeLeft.Enabled = cbBatteryVoltage.Enabled = false;
            cbBatteryCapacity.Checked = cbBatteryLevel.Checked = cbBatteryTimeLeft.Checked = cbBatteryVoltage.Checked = cbBattery.Checked;
            cbBatteryCapacity.Enabled = cbBatteryLevel.Enabled = cbBatteryTimeLeft.Enabled = cbBatteryVoltage.Enabled = true;

            if ( !cbBattery.Checked )
            {
                countCheckedComboboxes = 0;
            }
        }

        private void CheckBoxBattery_Checked ( object sender, CheckBox group, int countItems )
        {
            var checkbox = sender as CheckBox;

            countCheckedComboboxes += checkbox.Checked ? 1 : -1;

            CheckedGroupBatteryGetState( group, countCheckedComboboxes, countItems );
        }

        private void cbBatteryTimeLeft_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxBattery_Checked( sender, cbBattery, 4 );
        }

        private void cbBatteryLevel_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxBattery_Checked( sender, cbBattery, 4 );
        }

        private void cbBatteryVoltage_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxBattery_Checked( sender, cbBattery, 4 );
        }

        private void cbBatteryCapacity_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxBattery_Checked( sender, cbBattery, 4 );
        }

        private void cbUavParam_CheckedChanged ( object sender, EventArgs e )
        {
            cbLatitude.Enabled = cbLongitude.Enabled = cbHomeDistance.Enabled = cbRollAngle.Enabled = cbFlightPath.Enabled = cbInclination.Enabled = cbAzimuth.Enabled = cbFlightMode.Enabled = cbPitchAngle.Enabled = cbFlightTime.Enabled = false;
            cbLatitude.Checked = cbLongitude.Checked = cbHomeDistance.Checked = cbRollAngle.Checked = cbFlightPath.Checked = cbInclination.Checked = cbAzimuth.Checked = cbFlightMode.Checked = cbPitchAngle.Checked = cbFlightTime.Checked = cbUavParam.Checked;
            cbLatitude.Enabled = cbLongitude.Enabled = cbHomeDistance.Enabled = cbRollAngle.Enabled = cbFlightPath.Enabled = cbInclination.Enabled = cbAzimuth.Enabled = cbFlightMode.Enabled = cbPitchAngle.Enabled = cbFlightTime.Enabled = true;

            if ( !cbUavParam.Checked )
            {
                countCheckedComboboxes = 0;
            }

        }

        private void CheckBoxUavParam_Checked ( object sender, CheckBox group, int countItems )
        {
            var checkbox = sender as CheckBox;

            countCheckedComboboxes += checkbox.Checked ? 1 : -1;

            CheckedGroupUavParamGetState( group, countCheckedComboboxes, countItems );
        }

        private void CheckedGroupUavParamGetState ( CheckBox group, int state, int countItems )
        {
            cbUavParam.CheckedChanged -= cbUavParam_CheckedChanged;

            if ( state == 0 )
            {
                group.ThreeState = false;
                group.Checked = false;
            }
            else
            {
                if ( state == countItems )
                {
                    group.ThreeState = false;
                    group.CheckState = CheckState.Checked;
                }
                else
                {
                    group.ThreeState = true;
                    group.CheckState = CheckState.Indeterminate;
                }
            }

            cbUavParam.CheckedChanged += cbUavParam_CheckedChanged;
        }

        private void cbPitchAngle_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbLongitude_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbHomeDistance_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbRollAngle_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbFlightPath_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbInclination_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbAzimuth_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbFlightMode_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbLatitude_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbFlightTime_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxUavParam_Checked( sender, cbUavParam, 10 );
        }

        private void cbOtherParam_CheckedChanged ( object sender, EventArgs e )
        {
            cbSatellites.Enabled = cbAltitudeWrtHome.Enabled = cbVerticalSpeed.Enabled = cbCameraHAngle.Enabled = cbRange1.Enabled = cbWindSpeed.Enabled = cbWeaponStatus.Enabled = cbSignalLevel.Enabled = cbAltitudeWrtGround.Enabled = cbHorizontalSpeed.Enabled = cbCameraVAngle.Enabled = cbRange2.Enabled = cbWindAngle.Enabled = false;
            cbSatellites.Checked = cbAltitudeWrtHome.Checked = cbVerticalSpeed.Checked = cbCameraHAngle.Checked = cbRange1.Checked = cbWindSpeed.Checked = cbWeaponStatus.Checked = cbSignalLevel.Checked = cbAltitudeWrtGround.Checked = cbHorizontalSpeed.Checked = cbCameraVAngle.Checked = cbRange2.Checked = cbWindAngle.Checked = cbOtherParam.Checked;
            cbSatellites.Enabled = cbAltitudeWrtHome.Enabled = cbVerticalSpeed.Enabled = cbCameraHAngle.Enabled = cbRange1.Enabled = cbWindSpeed.Enabled = cbWeaponStatus.Enabled = cbSignalLevel.Enabled = cbAltitudeWrtGround.Enabled = cbHorizontalSpeed.Enabled = cbCameraVAngle.Enabled = cbRange2.Enabled = cbWindAngle.Enabled = true;

            if ( !cbOtherParam.Checked )
            {
                countCheckedComboboxes = 0;
            }

        }

        private void CheckBoxOtherParam_Checked ( object sender, CheckBox group, int countItems )
        {
            var checkbox = sender as CheckBox;

            countCheckedComboboxes += checkbox.Checked ? 1 : -1;

            CheckedGroupOtherParamGetState( group, countCheckedComboboxes, countItems );
        }

        private void CheckedGroupOtherParamGetState ( CheckBox group, int state, int countItems )
        {
            cbOtherParam.CheckedChanged -= cbOtherParam_CheckedChanged;

            if ( state == 0 )
            {
                group.ThreeState = false;
                group.Checked = false;
            }
            else
            {
                if ( state == countItems )
                {
                    group.ThreeState = false;
                    group.CheckState = CheckState.Checked;
                }
                else
                {
                    group.ThreeState = true;
                    group.CheckState = CheckState.Indeterminate;
                }
            }

            cbOtherParam.CheckedChanged += cbOtherParam_CheckedChanged;
        }

        private void cbCameraHAngle_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbAltitudeWrtGround_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbHorizontalSpeed_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbCameraVAngle_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbRange2_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbWindAngle_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbSatellites_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbAltitudeWrtHome_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbVerticalSpeed_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbSignalLevel_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbRange1_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbWindSpeed_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void cbWeaponStatus_CheckedChanged ( object sender, EventArgs e )
        {
            CheckBoxOtherParam_Checked( sender, cbOtherParam, 13 );
        }

        private void btnBattery_Click ( object sender, EventArgs e )
        {
            IndicatorBox.Visible = false;
            TargetBox.Visible = false;
            BatteryBox.Visible = true;
            UavParamBox.Visible = false;
            OtherParamBox.Visible = false;
        }

        private void btnUavParams_Click ( object sender, EventArgs e )
        {
            UavParamBox.Visible = true;
            IndicatorBox.Visible = false;
            TargetBox.Visible = false;
            BatteryBox.Visible = false;
            OtherParamBox.Visible = false;
        }

        private void btnIndicators_Click ( object sender, EventArgs e )
        {
            IndicatorBox.Visible = true;
            TargetBox.Visible = false;
            BatteryBox.Visible = false;
            UavParamBox.Visible = false;
            OtherParamBox.Visible = false;
        }

        private void btnTarget_Click ( object sender, EventArgs e )
        {
            IndicatorBox.Visible = false;
            TargetBox.Visible = true;
            BatteryBox.Visible = false;
            UavParamBox.Visible = false;
            OtherParamBox.Visible = false;
        }

        private void btnOther_Click ( object sender, EventArgs e )
        {
            OtherParamBox.Visible = true;
            IndicatorBox.Visible = false;
            TargetBox.Visible = false;
            BatteryBox.Visible = false;
            UavParamBox.Visible = false;
        }

        private void BtnGpsOn_Click ( object sender, EventArgs e )
        {
            MainV2.Joystick.Gps = 1000;

            btnGpsOff.Show( );
            btnGpsOn.Hide( );
        }

        private void BtnGpsOff_Click ( object sender, EventArgs e )
        {
            MainV2.Joystick.Gps = 2000;

            btnGpsOn.Show( );
            btnGpsOff.Hide( );
        }

        #endregion

    }
}
