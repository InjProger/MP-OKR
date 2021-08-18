extern alias Drawing;

using GMap.NET.WindowsForms;
using log4net;
using MissionPlanner.ArduPilot;
using MissionPlanner.Comms;
using MissionPlanner.Controls;
using MissionPlanner.GCSViews.ConfigurationView;
using MissionPlanner.Log;
using MissionPlanner.Maps;
using MissionPlanner.Utilities;
using MissionPlanner.Utilities.AltitudeAngel;
using MissionPlanner.Warnings;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.ArduPilot.Mavlink;
using MissionPlanner.Utilities.HW;
using Transitions;
using AltitudeAngelWings;
using Xamarin.Forms.Xaml;
using System.Linq;
using MissionPlanner.GCSViews.Connections.Views;
using MissionPlanner.GCSViews.Setups.Views;
using MissionPlanner.GCSViews.HUDs.Views;
using MissionPlanner.GCSViews;
using MissionPlanner.Configs;
using GMap.NET;
using MissionPlanner.GCSViews.Dialogs.TBInputDlg;
using System.Resources;
using System.Reflection;
using MissionPlanner.Globals;
using MissionPlanner.Utilities.Streams;
using System.IO.Pipes;
using MissionPlanner.GCSViews.FlyToPoint.Views;
using MissionPlanner.Joystick;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner.GCSViews.Setups.Models.Generals.Parts;
using MissionPlanner.GCSViews.Setups.Models;
using MissionPlanner.GCSViews.Setups.Models.Generals;
using Xamarin.Forms.Platform.WinForms;
using Xamarin.Forms.PlatformConfiguration;
using Other.Extensions;
using MissionPlanner.GCSViews.Alignments;
using MissionPlanner.GCSViews.Messages;
using System.Linq.Expressions;
using static MAVLink;
using MissionPlanner.GCSViews.NavigationLights;
using MissionPlanner.Joystick.JoyRespond;
using MissionPlanner.GCSViews.Setups.Models.Interfaces;
using MissionPlanner.Utilities.Mathematics;
using MissionPlanner.Utilities.Measurements;

namespace MissionPlanner
{
    public partial class MainV2 : Form
    {
        public const int STARTED_MAP_ZOOM = 17;

        private Process _videoProces;

        public bool IsConnected { get; set; }
        private static readonly ILog log =
            LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

        public static MenuIcons displayicons; //do not initialize to allow update of custom icons

        internal PointLatLng MouseDownStart;

        public abstract class MenuIcons
        {
            public abstract Image Fd { get; }
            public abstract Image Fp { get; }
            public abstract Image Initsetup { get; }
            public abstract Image Config_tuning { get; }
            public abstract Image Sim { get; }
            public abstract Image Terminal { get; }
            public abstract Image Help { get; }
            public abstract Image Donate { get; }
            public abstract Image Connect { get; }
            public abstract Image Disconnect { get; }
            public abstract Image Bg { get; }
            public abstract Image Wizard { get; }
        }

        public class Burntkermitmenuicons : MenuIcons
        {
            public override Image Fd
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_flightdata_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_flightdata_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_flightdata_icon;
                }
            }

            public override Image Fp
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_flightplan_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_flightplan_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_flightplan_icon;
                }
            }

            public override Image Initsetup
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_initialsetup_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_initialsetup_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_initialsetup_icon;
                }
            }

            public override Image Config_tuning
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_tuningconfig_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_tuningconfig_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_tuningconfig_icon;
                }
            }

            public override Image Sim
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_simulation_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_simulation_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_simulation_icon;
                }
            }

            public override Image Terminal
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_terminal_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_terminal_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_terminal_icon;
                }
            }

            public override Image Help
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_help_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_help_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_help_icon;
                }
            }

            public override Image Donate
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_donate_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_donate_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.donate;
                }
            }

            public override Image Connect
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_connect_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_connect_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_connect_icon;
                }
            }

            public override Image Disconnect
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_disconnect_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_disconnect_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.light_disconnect_icon;
                }
            }

            public override Image Bg
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_icon_background.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_icon_background.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.bgdark;
                }
            }
            public override Image Wizard
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "light_wizard_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "light_wizard_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.wizardicon;
                }
            }
        }

        public class Highcontrastmenuicons : MenuIcons
        {
            public override Image Fd
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_flightdata_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_flightdata_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_flightdata_icon;
                }
            }

            public override Image Fp
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_flightplan_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_flightplan_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_flightplan_icon;
                }
            }

            public override Image Initsetup
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_initialsetup_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_initialsetup_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_initialsetup_icon;
                }
            }

            public override Image Config_tuning
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_tuningconfig_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_tuningconfig_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_tuningconfig_icon;
                }
            }

            public override Image Sim
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_simulation_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_simulation_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_simulation_icon;
                }
            }

            public override Image Terminal
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_terminal_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_terminal_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_terminal_icon;
                }
            }

            public override Image Help
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_help_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_help_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_help_icon;
                }
            }

            public override Image Donate
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_donate_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_donate_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.donate;
                }
            }

            public override Image Connect
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_connect_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_connect_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_connect_icon;
                }
            }

            public override Image Disconnect
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_disconnect_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_disconnect_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.dark_disconnect_icon;
                }
            }

            public override Image Bg
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_icon_background.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_icon_background.png" );
                    else
                        return null;
                }
            }
            public override Image Wizard
            {
                get
                {
                    if ( File.Exists( Settings.GetRunningDirectory( ) + "dark_wizard_icon.png" ) )
                        return Image.FromFile( Settings.GetRunningDirectory( ) + "dark_wizard_icon.png" );
                    else
                        return global::MissionPlanner.Properties.Resources.wizardicon;
                }
            }
        }

        Controls.MainSwitcher MyView;

        private static DisplayView _displayConfiguration = new DisplayView( ).Advanced( );

        public static event EventHandler LayoutChanged;

        public static DisplayView DisplayConfiguration
        {
            get { return _displayConfiguration; }
            set
            {
                _displayConfiguration = value;
                Settings.Instance[ "displayview" ] = _displayConfiguration.ConvertToString( );
                LayoutChanged?.Invoke( null, EventArgs.Empty );
            }
        }

        public static bool ShowAirports { get; set; }
        public static bool ShowTFR { get; set; }

        private Utilities.adsb _adsb;

        public bool EnableADSB
        {
            get { return _adsb != null; }
            set
            {
                if ( value == true )
                {
                    _adsb = new Utilities.adsb( );

                    if ( Settings.Instance[ "adsbserver" ] != null )
                        Utilities.adsb.server = Settings.Instance[ "adsbserver" ];
                    if ( Settings.Instance[ "adsbport" ] != null )
                        Utilities.adsb.serverport = int.Parse( Settings.Instance[ "adsbport" ].ToString( ) );
                }
                else
                {
                    Utilities.adsb.Stop( );
                    _adsb = null;
                }
            }
        }

        //public static event EventHandler LayoutChanged;

        /// <summary>
        /// Active Comport interface
        /// </summary>
        public static MAVLinkInterface ComPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                if ( _comPort == value )
                    return;
                _comPort = value;
                _comPort.MavChanged -= instance.ComPort_MavChanged;
                _comPort.MavChanged += instance.ComPort_MavChanged;
                instance.ComPort_MavChanged( null, null );
            }
        }

        private void ConnectButtonEnabled( bool enabled = false )
        {
            var settings = tabMenuView.settingsTab;
            var blackBox = tabMenuView.blackBoxTab;

            settings.btnCompass.Enabled = enabled;
            settings.btnAccelerometer.Enabled = enabled;
            settings.btnESC.Enabled = enabled;
            settings.btnBattery.Enabled = enabled;
            settings.btnConfig.Enabled = enabled;

            blackBox.btnDownload.Enabled = enabled;

            btnConnect.Visible = !enabled;
            btnDisconnect.Visible = enabled;
        }

        static MAVLinkInterface _comPort = new MAVLinkInterface( );

        /// <summary>
        /// passive comports
        /// </summary>
        public static List<MAVLinkInterface> Comports = new List<MAVLinkInterface>( );

        public delegate void WMDeviceChangeEventHandler( WM_DEVICECHANGE_enum cause );

        public event WMDeviceChangeEventHandler DeviceChanged;

        /// <summary>
        /// other planes in the area from adsb
        /// </summary>
        public object adsblock = new object( );

        public ConcurrentDictionary<string, adsb.PointLatLngAltHdg> adsbPlanes = new ConcurrentDictionary<string, adsb.PointLatLngAltHdg>( );

        /// <summary>
        /// Comport name
        /// </summary>
        public static string comPortName = "";

        public static int comPortBaud = 115200;

        /// <summary>
        /// mono detection
        /// </summary>
        public static bool MONO = false;

        /// <summary>
        /// speech engine enable
        /// </summary>
        public static bool SpeechEnable
        {
            get { return SpeechEngine == null ? false : SpeechEngine.speechEnable; }
            set
            {
                if ( SpeechEngine != null ) SpeechEngine.speechEnable = value;
            }
        }

        /// <summary>
        /// spech engine static class
        /// </summary>
        public static ISpeech SpeechEngine { get; set; }

        /// <summary>
        /// joystick static class
        /// </summary>
        public static Joystick.Joystick Joystick { get; set; }

        /// <summary>
        /// track last joystick packet sent. used to control rate
        /// </summary>
        DateTime lastjoystick = DateTime.Now;

        /// <summary>
        /// determine if we are running sitl
        /// </summary>
        public static bool Sitl
        {
            get
            {
                if ( MissionPlanner.GCSViews.SITL.SITLSEND == null ) return false;
                if ( MissionPlanner.GCSViews.SITL.SITLSEND.Client.Connected ) return true;
                return false;
            }
        }

        /// <summary>
        /// hud background image grabber from a video stream - not realy that efficent. ie no hardware overlays etc.
        /// </summary>
        public static WebCamService.Capture Cam { get; set; }

        /// <summary>
        /// controls the main serial reader thread
        /// </summary>
        bool serialThread = false;

        bool pluginthreadrun = false;

        bool joystickthreadrun = false;

        private Form _activeWindow;

        Thread httpthread;
        Thread joystickthread;
        Thread serialreaderthread;
        Thread pluginthread;

        private bool _isFlightCalcedLabelsShow;

        /// <summary>
        /// track the last heartbeat sent
        /// </summary>
        private DateTime heatbeatSend = DateTime.Now;

        /// <summary>
        /// used to call anything as needed.
        /// </summary>
        public static MainV2 instance = null;

        public static MainSwitcher View;

        /// <summary>
        /// store the time we first connect
        /// </summary>
        DateTime connecttime = DateTime.Now;

        DateTime nodatawarning = DateTime.Now;
        DateTime connectButtonUpdate = DateTime.Now;

        public GCSViews.FlightPlanner FlightPlanner;
        GCSViews.SITL Simulation;

        private Form connectionStatsForm;
        private ConnectionStats _connectionStats;

        /// <summary>
        /// This 'Control' is the toolstrip control that holds the comport combo, baudrate combo etc
        /// Otiginally seperate controls, each hosted in a toolstip sqaure, combined into this custom
        /// control for layout reasons.
        /// </summary>
        public static ConnectionControl _connectionControl;
        public static bool TerminalTheming = true;
        public bool startup;

        public void UpdateLayout( object sender, EventArgs e )
        {
            MenuSimulation.Visible = DisplayConfiguration.displaySimulation;
            MenuHelp.Visible = DisplayConfiguration.displayHelp;
            MissionPlanner.Controls.BackstageView.BackstageView.Advanced = DisplayConfiguration.isAdvancedMode;

            if ( Settings.Instance.GetBoolean( "menu_autohide" ) != DisplayConfiguration.autoHideMenuForce )
            {
                Settings.Instance[ "menu_autohide" ] = DisplayConfiguration.autoHideMenuForce.ToString( );
            }
        }

        void BtnImport_Click( object sender, EventArgs e)
        {
            FlightPlanner.BUT_read_Click( sender, e );
        }

        void BtnExport_Click( object sender, EventArgs e )
        {
            FlightPlanner.cmb_missiontype.SelectedIndex = ( int ) MAVLink.MAV_MISSION_TYPE.MISSION;
            FlightPlanner.BUT_write_Click( sender, e );
        }

        void BtnSave_Click( object sender, EventArgs e )
        {
            FlightPlanner.BUT_saveWPFile_Click( sender, e );
        }

        void BtnOpen_Click( object sender, EventArgs e )
        {
            FlightPlanner.BUT_loadwpfile_Click( sender, e );
        }

        void BtnSetups_Click( object sender, EventArgs e )
        {
            new SettingView( ).ShowDialog( );
        }

        void BtnBBoxDownload_Click ( object sender, EventArgs e ) 
        {
            new LogDownloadMavLink( ).ShowDialog( );
        }

        void BtnBBoxOpen_Click ( object sender, EventArgs e )
        {
            new LogBrowse().ShowDialog();
        }

        void BtnControl_Click( object sender, EventArgs e )
        {
            new JoyRespondForm( ).ShowDialog( );
        }

        void BtnAlignment_Click( object sender, EventArgs e )
        {
            new Alignment( ).ShowDialog( );
        }

        void BtnCompass_Click( object sender, EventArgs e )
        {
            if ( MainV2.ComPort.MAV.param.ContainsKey( "COMPASS_PRIO1_ID" ) )
            {
                var compass2 = new ConfigHWCompass2( );
                compass2.Activate( );
                compass2.ShowUserControl( );
            }
            else
            {
                var compass1 = new ConfigHWCompass( );
                compass1.ShowUserControl( );
                compass1.ShowUserControl( );
            }
        }

        void BtnAccelerometer_Click( object sender, EventArgs e )
        {
            new Accelerometer( ).ShowDialog( );
        }

        void BtnEsc_Click( object sender, EventArgs e )
        {
            new ESC( ).ShowDialog( );
        }

        void BtnConfig_Click( object sender, EventArgs e )
        {
            new Config( ).ShowDialog( );
        }

        void BtnBattery_Click ( object sender, EventArgs e )
        {
            new BatteryMonitor( ).ShowDialog( );
        }

        void BtnTaskEdit_Click ( object sender, EventArgs e )
        {
            ForEditTabsEnabled( false );
        }

        private void EnableMainButtons ( bool enabled )
        {   
            btnHome.Enabled = enabled;
            btnFlyPoint.Enabled = enabled;
            btnLanding.Enabled = enabled;
            btnTakeoff.Enabled = enabled;
            btnAerodrome.Enabled = enabled;
            btnNavigationLights.Enabled = enabled;
        }

        public void ForEditTabsEnabled( bool enabled )
        {   
            FlightPlanner.Commands.Enabled = !enabled;
            FlightPlanner.MainMapEdited = !enabled;

            tabMenuView.panelMapEdit.Visible = !enabled;
            tabMenuView.panelMenu.Visible = enabled;
        }

        public MainV2()
        {
            log.Info("Mainv2 ctor");

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            // create one here - but override on load
            Settings.Instance["guid"] = Guid.NewGuid().ToString();

            // load config
            LoadConfig();

            // force language to be loaded
            L10N.GetConfigLang();
            
            Settings.Instance[ "logdirectory" ] = Settings.GetDefaultLogDir();

            ShowAirports = true;

            // setup adsb
            Utilities.adsb.UpdatePlanePosition += Adsb_UpdatePlanePosition;

            MAVLinkInterface.UpdateADSBPlanePosition += Adsb_UpdatePlanePosition;

            MAVLinkInterface.UpdateADSBCollision += (sender, tuple) =>
            {
                lock (adsblock)
                {
                    if (MainV2.instance.adsbPlanes.ContainsKey(tuple.id))
                    {
                        // update existing
                        ((adsb.PointLatLngAltHdg)instance.adsbPlanes[tuple.id]).ThreatLevel = tuple.threat_level;
                    }
                }
            };

            MAVLinkInterface.gcssysid = (byte)Settings.Instance.GetByte("gcsid", MAVLinkInterface.gcssysid);

            Form splash = Program.Splash;

            splash?.Refresh();

            Application.DoEvents();

            instance = this;
            InitializeComponent();

            ConnectButtonEnabled( );

            //Init Theme table and load BurntKermit as a default
            ThemeManager.thmColor = new ThemeColorTable(); //Init colortable
            ThemeManager.thmColor.InitColors();     //This fills up the table with BurntKermit defaults. 
            ThemeManager.thmColor.SetTheme();              //Set the colors, this need to handle the case when not all colors are defined in the theme file

            if (Settings.Instance["theme"] == null) Settings.Instance["theme"] = "BurntKermit.mpsystheme";

            ThemeManager.LoadTheme(Settings.Instance["theme"]);

            Utilities.ThemeManager.ApplyThemeTo(this);

            MyView = new MainSwitcher(this);

            View = MyView;

            //startup console
            TCPConsole.Write((byte)'S');

            // define default basestream
            ComPort.BaseStream = new SerialPort();
            ComPort.BaseStream.BaudRate = 115200;

            _connectionControl = toolStripConnectionControl.ConnectionControl;
            _connectionControl.CMB_baudrate.TextChanged += this.CMB_baudrate_TextChanged;
            _connectionControl.CMB_serialport.SelectedIndexChanged += this.CMB_serialport_SelectedIndexChanged;
            _connectionControl.CMB_serialport.Click += this.CMB_serialport_Click;
            _connectionControl.cmb_sysid.Click += Cmb_sysid_Click;

            _connectionControl.ShowLinkStats += (sender, e) => ShowConnectionStatsForm();
            srtm.datadirectory = Settings.GetDataDirectory() +
                                 "srtm";

            var t = Type.GetType("Mono.Runtime");
            MONO = (t != null);

            try
            {
                SpeechEngine = new Speech();
                MAVLinkInterface.Speech = SpeechEngine;
                CurrentState.Speech = SpeechEngine;
            }
            catch { }

            Warnings.CustomWarning.defaultsrc = ComPort.MAV.cs;
            Warnings.WarningEngine.Start(SpeechEnable ? SpeechEngine : null);
            Warnings.WarningEngine.WarningMessage += (sender, s) =>
            {
                MainV2.ComPort.MAV.cs.messageHigh = s;
            };

            // proxy loader - dll load now instead of on config form load
            new Transition(new TransitionType_EaseInEaseOut(2000));

            PopulateSerialportList();
            /*if (_connectionControl.CMB_serialport.Items.Count > 0)
            {
                _connectionControl.CMB_baudrate.SelectedIndex = 8;
                _connectionControl.CMB_serialport.SelectedIndex = 0;
            }
            */
            // ** Done

            splash?.Refresh();
            Application.DoEvents();

            // load last saved connection settings
            var uav = Configurator.Connection.Uav;
            _connectionControl.CMB_serialport.SelectedIndex = _connectionControl.CMB_serialport.Items.IndexOf( uav.Name );
            _connectionControl.CMB_baudrate.SelectedIndex = _connectionControl.CMB_baudrate.Items.IndexOf( uav.Baudrate.ToString() );

            /*if (!string.IsNullOrEmpty(temp))
            {
                _connectionControl.CMB_serialport.SelectedIndex = _connectionControl.CMB_serialport.FindString(temp);
                if (_connectionControl.CMB_serialport.SelectedIndex == -1)
                {
                    _connectionControl.CMB_serialport.Text = temp; // allows ports that dont exist - yet
                }
                comPort.BaseStream.PortName = temp;
                comPortName = temp;
            }
            string temp2 = Settings.Instance.BaudRate;
            if (!string.IsNullOrEmpty(temp2))
            {
                var idx = _connectionControl.CMB_baudrate.FindString(temp2);
                if (idx == -1)
                {
                    _connectionControl.CMB_baudrate.Text = temp2;
                }
                else
                {
                    _connectionControl.CMB_baudrate.SelectedIndex = idx;
                }

                comPortBaud = int.Parse(temp2);
            }
            */

            MissionPlanner.Utilities.Tracking.cid = new Guid(Settings.Instance["guid"].ToString());

            if (Settings.Instance.ContainsKey("language") && !string.IsNullOrEmpty(Settings.Instance["language"]))
            {
                Changelanguage(CultureInfoEx.GetCultureInfo(Settings.Instance["language"]));
            }
            if (splash != null)
            {
                this.Text = splash?.Text;
            }

            if (!MONO) // windows only
            {
                if (Settings.Instance["showconsole"] != null && Settings.Instance["showconsole"].ToString() == "True")
                {
                }
                else
                {
                    int win = NativeMethods.FindWindow("ConsoleWindowClass", null);
                    NativeMethods.ShowWindow(win, NativeMethods.SW_HIDE); // hide window
                }

                // prevent system from sleeping while mp open
                var previousExecutionState =
                    NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
            }

            ChangeUnits();

            if (Settings.Instance["showairports"] != null)
            {
                MainV2.ShowAirports = bool.Parse(Settings.Instance["showairports"]);
            }

            // set default
            ShowTFR = true;
            // load saved
            if (Settings.Instance["showtfr"] != null)
            {
                MainV2.ShowTFR = Settings.Instance.GetBoolean("showtfr", ShowTFR);
            }

            if (Settings.Instance["enableadsb"] != null)
            {
                MainV2.instance.EnableADSB = Settings.Instance.GetBoolean("enableadsb");
            }

            try
            {
                log.Info(Process.GetCurrentProcess().Modules.ToJSON());
            }
            catch
            {
            }

            try
            {
                log.Info("Create FD");
                // FlightData = new GCSViews.FlightData();
                log.Info("Create FP");
                FlightPlanner = new GCSViews.FlightPlanner();
                //Configuration = new GCSViews.ConfigurationView.Setup();
                log.Info("Create SIM");
                Simulation = new GCSViews.SITL();
                //Firmware = new GCSViews.Firmware();
                //Terminal = new GCSViews.Terminal();

               // FlightData.Width = MyView.Width;
                FlightPlanner.Width = MyView.Width;
                Simulation.Width = MyView.Width;
            }
            catch (ArgumentException e)
            {
                //http://www.microsoft.com/en-us/download/details.aspx?id=16083
                //System.ArgumentException: Font 'Arial' does not support style 'Regular'.

                log.Fatal(e);
                CustomMessageBox.Show(e.ToString() +
                                      "\n\n Font Issues? Please install this http://www.microsoft.com/en-us/download/details.aspx?id=16083");
                //splash.Close();
                //this.Close();
                Application.Exit();
            }
            catch (Exception e)
            {
                log.Fatal(e);
                CustomMessageBox.Show("A Major error has occured : " + e.ToString());
                Application.Exit();
            }

            //set first instance display configuration
            if (DisplayConfiguration == null)
            {
                DisplayConfiguration = DisplayConfiguration.Advanced();
            }

            // load old config
            if (Settings.Instance["advancedview"] != null)
            {
                if (Settings.Instance.GetBoolean("advancedview") == true)
                {
                    DisplayConfiguration = new DisplayView().Advanced();
                }
                // remove old config
                Settings.Instance.Remove("advancedview");
            }            //// load this before the other screens get loaded
            if (Settings.Instance["displayview"] != null)
            {
                try
                {
                    DisplayConfiguration = Settings.Instance.GetDisplayView("displayview");
                }
                catch
                {
                    DisplayConfiguration = DisplayConfiguration.Advanced();
                }
            }

            LayoutChanged += UpdateLayout;
            LayoutChanged(null, EventArgs.Empty);
            /*
            if (Settings.Instance["CHK_GDIPlus"] != null)
                GCSViews.FlightData.myhud.opengl = !bool.Parse(Settings.Instance["CHK_GDIPlus"].ToString());

            if (Settings.Instance["CHK_hudshow"] != null)
                GCSViews.FlightData.myhud.hudon = bool.Parse(Settings.Instance["CHK_hudshow"].ToString());
            */
            try
            {
                if (Settings.Instance["MainLocX"] != null && Settings.Instance["MainLocY"] != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    var startpos = new System.Drawing.Point(Settings.Instance.GetInt32("MainLocX"),
                        Settings.Instance.GetInt32("MainLocY"));

                    // fix common bug which happens when user removes a monitor, the app shows up
                    // offscreen and it is very hard to move it onscreen.  Also happens with 
                    // remote desktop a lot.  So this only restores position if the position
                    // is visible.
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (s.WorkingArea.Contains(startpos))
                        {
                            this.Location = startpos;
                            break;
                        }
                    }

                }

                if (Settings.Instance["MainMaximised"] != null)
                {
                    this.WindowState =
                        (FormWindowState)Enum.Parse(typeof(FormWindowState), Settings.Instance["MainMaximised"]);
                    // dont allow minimised start state
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.Location = new System.Drawing.Point(100, 100);
                    }
                }

                if (Settings.Instance["MainHeight"] != null)
                    this.Height = Settings.Instance.GetInt32("MainHeight");
                if (Settings.Instance["MainWidth"] != null)
                    this.Width = Settings.Instance.GetInt32("MainWidth");

                // set presaved default telem rates
                if (Settings.Instance["CMB_rateattitude"] != null)
                    CurrentState.rateattitudebackup = Settings.Instance.GetInt32("CMB_rateattitude");
                if (Settings.Instance["CMB_rateposition"] != null)
                    CurrentState.ratepositionbackup = Settings.Instance.GetInt32("CMB_rateposition");
                if (Settings.Instance["CMB_ratestatus"] != null)
                    CurrentState.ratestatusbackup = Settings.Instance.GetInt32("CMB_ratestatus");
                if (Settings.Instance["CMB_raterc"] != null)
                    CurrentState.ratercbackup = Settings.Instance.GetInt32("CMB_raterc");
                if (Settings.Instance["CMB_ratesensors"] != null)
                    CurrentState.ratesensorsbackup = Settings.Instance.GetInt32("CMB_ratesensors");

                //Load customfield names from config

                for (short i = 0; i < 10; i++)
                {
                    var fieldname = "customfield" + i.ToString();
                    if (Settings.Instance.ContainsKey(fieldname))
                        CurrentState.custom_field_names.Add(fieldname, Settings.Instance[fieldname].ToUpper());
                }

                // make sure rates propogate
                MainV2.ComPort.MAV.cs.ResetInternals();

                if (Settings.Instance["speechenable"] != null)
                    MainV2.SpeechEnable = Settings.Instance.GetBoolean("speechenable");

                if (Settings.Instance["analyticsoptout"] != null)
                    MissionPlanner.Utilities.Tracking.OptOut = Settings.Instance.GetBoolean("analyticsoptout");

                try
                {
                    if (Settings.Instance["TXT_homelat"] != null)
                        MainV2.ComPort.MAV.cs.PlannedHomeLocation.Lat = Settings.Instance.GetDouble("TXT_homelat");

                    if (Settings.Instance["TXT_homelng"] != null)
                        MainV2.ComPort.MAV.cs.PlannedHomeLocation.Lng = Settings.Instance.GetDouble("TXT_homelng");

                    if (Settings.Instance["TXT_homealt"] != null)
                        MainV2.ComPort.MAV.cs.PlannedHomeLocation.Alt = Settings.Instance.GetDouble("TXT_homealt");

                    // remove invalid entrys
                    if (Math.Abs(MainV2.ComPort.MAV.cs.PlannedHomeLocation.Lat) > 90 ||
                        Math.Abs(MainV2.ComPort.MAV.cs.PlannedHomeLocation.Lng) > 180)
                        MainV2.ComPort.MAV.cs.PlannedHomeLocation = new PointLatLngAlt();
                }
                catch
                {
                }
            }
            catch
            {
            }

            if (CurrentState.rateattitudebackup == 0) // initilised to 10, configured above from save
            {
                CustomMessageBox.Show(
                    "NOTE: your attitude rate is 0, the hud will not work\nChange in Configuration > Planner > Telemetry Rates");
            }

            // create log dir if it doesnt exist
            try
            {
                if (!Directory.Exists(Settings.Instance.LogDir))
                    Directory.CreateDirectory(Settings.Instance.LogDir);
            }
            catch (Exception ex) { log.Error(ex); }
#if !NETSTANDARD2_0
#if !NETCOREAPP2_0
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
#endif
#endif

            // make sure new enough .net framework is installed
            if (!MONO)
            {
                Microsoft.Win32.RegistryKey installed_versions =
                    Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                string[] version_names = installed_versions.GetSubKeyNames();
                //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
                double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1),
                    CultureInfo.InvariantCulture);
                int SP =
                    Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length - 1])
                        .GetValue("SP", 0));

                if (Framework < 4.0)
                {
                    CustomMessageBox.Show("This program requires .NET Framework 4.0. You currently have " + Framework);
                }
            }

            if (Program.IconFile != null)
            {
                this.Icon = Icon.FromHandle(((Bitmap)Program.IconFile).GetHicon());
            }

            MenuArduPilot.Image = new Bitmap(Properties.Resources._0d92fed790a3a70170e61a86db103f399a595c70, (int)(200), 31);
            MenuArduPilot.Width = MenuArduPilot.Image.Width;

            if (Program.Logo2 != null)
                MenuArduPilot.Image = Program.Logo2;

            Application.DoEvents();

            Comports.Add(ComPort);

            MainV2.ComPort.MavChanged += ComPort_MavChanged;

            _lighting = new Lighting( );
            _lighting.IsOn = true;
            _lighting.LightingType = ELightingType.Constant;
            btnNavigationLights.Image = Properties.Resources.LampOn;

            // save config to test we have write access
            SaveConfig();

            /* Hide buttons by default : */

            MenuInitConfig.Visible             = false;
            MenuConfigTune.Visible             = false;
            MenuSimulation.Visible             = false;
            MenuArduPilot.Visible              = false;
            MenuHelp.Visible                   = false;
            toolStripConnectionControl.Visible = false;
            tabMenuView.taskTab.btnArm.Enabled = false;
            
            startup = true;
            GenerateLanguages();
            startup = false;

            timer1.Start( );

            var connection = Configurator.Connection.Joystick;
            _movingBase = new MovingBase( connection );
            _movingBase.BUT_connect_Click( this, new EventArgs( ) );
        }

        private Lighting _lighting;

        private CurrentMeasure _measure;

        public void GetLocalMeasure ( )
        {
            var measure = Configurator.Measurement.GetCurrentMeasure( );
            var speed = Configurator.Setting.Interface.ESpeed;

            _measure = new CurrentMeasure
            {
                Local = measure.Local,
                Voltage = measure.Voltage,
                Capacity = measure.Capacity,
                Speed = speed == ESpeed.M_s ? measure.Speed[ 0 ] : measure.Speed[ 1 ],
                Distance = speed == ESpeed.M_s ? measure.Distance[ 0 ] : measure.Distance[ 1 ],
                CardinalPoints = measure.CardinalPoints,
                FlightMode = measure.FlightMode,
                FlightStatus = measure.FlightStatus
            };
        }

        void GenerateLanguages()
        {
            // setup language selection
            var cultureCodes = new[]
            {
                "en-US", "zh-Hans", "zh-TW", "ru-RU", "Fr", "Pl", "it-IT", "es-ES", "de-DE", "ja-JP", "id-ID", "ko-KR",
                "ar", "pt", "tr", "ru-KZ"
            };

            var _languages = cultureCodes
                .Select(CultureInfoEx.GetCultureInfo)
                .Where(c => c != null)
                .ToList();

            var currentUiCulture      = Thread.CurrentThread.CurrentUICulture;
        }

        void Cmb_sysid_Click(object sender, EventArgs e)
        {
            MainV2._connectionControl.UpdateSysIDS();
        }

        void ComPort_MavChanged(object sender, EventArgs e)
        {
            log.Info("Mav Changed " + MainV2.ComPort.MAV.sysid);

            HUD.Custom.src = MainV2.ComPort.MAV.cs;

            CustomWarning.defaultsrc = MainV2.ComPort.MAV.cs;

            MissionPlanner.Controls.PreFlight.CheckListItem.defaultsrc = MainV2.ComPort.MAV.cs;

            // when uploading a firmware we dont want to reload this screen.
            if (instance.MyView.current.Control != null && instance.MyView.current.Control.GetType() == typeof(GCSViews.InitialSetup))
            {
                var page = ((GCSViews.InitialSetup)instance.MyView.current.Control).backstageView.SelectedPage;
                if (page != null && page.Text.Contains("Install Firmware"))
                {
                    return;
                }
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
               {
                   //enable the payload control page if a mavlink gimbal is detected
                   if (instance.FlightPlanner != null)
                   {
                       instance.FlightPlanner.UpdateDisplayView();
                   }

                   instance.MyView.Reload();
               });
            }
            else
            {
                //enable the payload control page if a mavlink gimbal is detected
                if ( instance.FlightPlanner != null )
                {
                    instance.FlightPlanner.UpdateDisplayView( );
                }

                instance.MyView.Reload();
            }
        }
#if !NETSTANDARD2_0
#if !NETCOREAPP2_0
        void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            // try prevent crash on resume
            if (e.Mode == Microsoft.Win32.PowerModes.Suspend)
            {
                DoDisconnect(MainV2.ComPort);
            }
        }
#endif
#endif
        private void BGLoadAirports(object nothing)
        {
            // read airport list
            try
            {
                Utilities.Airports.ReadOurairports(Settings.GetRunningDirectory() +
                                                   "airports.csv");

                Utilities.Airports.checkdups = true;

                //Utilities.Airports.ReadOpenflights(Application.StartupPath + Path.DirectorySeparatorChar + "airports.dat");

                log.Info("Loaded " + Utilities.Airports.GetAirportCount + " airports");
            }
            catch
            {
            }
        }

        public void Switchicons(MenuIcons icons)
        {
            //Check if we starting 
            if (displayicons != null)
            {
                // dont update if no change
                if (displayicons.GetType() == icons.GetType())
                    return;
            }

            displayicons = icons;

            MainMenu.BackColor = SystemColors.MenuBar;

            MainMenu.BackgroundImage = displayicons.Bg;

           // MenuFlightData.Image = displayicons.fd;
            MenuFlightPlanner.Image = displayicons.Fp;
            MenuInitConfig.Image = displayicons.Initsetup;
            MenuSimulation.Image = displayicons.Sim;
            MenuConfigTune.Image = displayicons.Config_tuning;
            MenuConnect.Image = displayicons.Connect;
            MenuHelp.Image = displayicons.Help;


            //MenuFlightData.ForeColor = ThemeManager.TextColor;
            MenuFlightPlanner.ForeColor = ThemeManager.TextColor;
            MenuInitConfig.ForeColor = ThemeManager.TextColor;
            MenuSimulation.ForeColor = ThemeManager.TextColor;
            MenuConfigTune.ForeColor = ThemeManager.TextColor;
            MenuConnect.ForeColor = ThemeManager.TextColor;
            MenuHelp.ForeColor = ThemeManager.TextColor;
        }

        void Adsb_UpdatePlanePosition(object sender, MissionPlanner.Utilities.adsb.PointLatLngAltHdg adsb)
        {
            lock (adsblock)
            {
                var id = adsb.Tag;

                if (MainV2.instance.adsbPlanes.ContainsKey(id))
                {
                    // update existing
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Lat = adsb.Lat;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Lng = adsb.Lng;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Alt = adsb.Alt;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Heading = adsb.Heading;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Time = DateTime.Now;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).CallSign = adsb.CallSign;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Squawk = adsb.Squawk;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Raw = adsb.Raw;
                }
                else
                {
                    // create new plane
                    MainV2.instance.adsbPlanes[id] =
                        new adsb.PointLatLngAltHdg(adsb.Lat, adsb.Lng,
                                adsb.Alt, adsb.Heading, adsb.Speed, id,
                                DateTime.Now)
                            {CallSign = adsb.CallSign, Squawk = adsb.Squawk, Raw = adsb.Raw};
                }

                try
                {
                    // dont rebroadcast something that came from the drone
                    if (sender != null && sender is MAVLinkInterface)
                        return;

                    MAVLink.mavlink_adsb_vehicle_t packet = new MAVLink.mavlink_adsb_vehicle_t();

                    packet.altitude = (int)(MainV2.instance.adsbPlanes[id].Alt * 1000);
                    packet.altitude_type = (byte)MAVLink.ADSB_ALTITUDE_TYPE.GEOMETRIC;
                    packet.callsign = adsb.CallSign.MakeBytes();
                    packet.squawk = adsb.Squawk;
                    packet.emitter_type = (byte)MAVLink.ADSB_EMITTER_TYPE.NO_INFO;
                    packet.heading = (ushort)(MainV2.instance.adsbPlanes[id].Heading * 100);
                    packet.lat = (int)(MainV2.instance.adsbPlanes[id].Lat * 1e7);
                    packet.lon = (int)(MainV2.instance.adsbPlanes[id].Lng * 1e7);
                    packet.ICAO_address = uint.Parse(id, NumberStyles.HexNumber);

                    packet.flags = (ushort)(MAVLink.ADSB_FLAGS.VALID_ALTITUDE | MAVLink.ADSB_FLAGS.VALID_COORDS |
                        MAVLink.ADSB_FLAGS.VALID_HEADING | MAVLink.ADSB_FLAGS.VALID_CALLSIGN);

                    //send to current connected
                    MainV2.ComPort.sendPacket(packet, MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid);
                }
                catch
                {

                }
            }
        }


        private void ResetConnectionStats()
        {
            log.Info("Reset connection stats");
            // If the form has been closed, or never shown before, we need do nothing, as 
            // connection stats will be reset when shown
            if (this.connectionStatsForm != null && connectionStatsForm.Visible)
            {
                // else the form is already showing.  reset the stats
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(ComPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                ThemeManager.ApplyThemeTo(this.connectionStatsForm);
            }
        }

        private void ShowConnectionStatsForm()
        {
            if (this.connectionStatsForm == null || this.connectionStatsForm.IsDisposed)
            {
                // If the form has been closed, or never shown before, we need all new stuff
                this.connectionStatsForm = new Form
                {
                    Width = 430,
                    Height = 180,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = Strings.LinkStats
                };
                // Change the connection stats control, so that when/if the connection stats form is showing,
                // there will be something to see
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(ComPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                this.connectionStatsForm.Width = _connectionStats.Width;
            }

            this.connectionStatsForm.Show();
            ThemeManager.ApplyThemeTo(this.connectionStatsForm);
        }

        private void CMB_serialport_Click(object sender, EventArgs e)
        {
            string oldport = _connectionControl.CMB_serialport.Text;
            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Contains(oldport))
                _connectionControl.CMB_serialport.Text = oldport;
        }

        private void PopulateSerialportList()
        {
            _connectionControl.CMB_serialport.Items.Clear();
            _connectionControl.CMB_serialport.Items.Add("AUTO");
            _connectionControl.CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            _connectionControl.CMB_serialport.Items.Add("TCP");
            _connectionControl.CMB_serialport.Items.Add("UDP");
            _connectionControl.CMB_serialport.Items.Add("UDPCl");
            _connectionControl.CMB_serialport.Items.Add("WS");
        }

        private void MenuFlightData_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightData");
        }

        private void MenuFlightPlanner_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightPlanner");
        }

        public void MenuSetup_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("HWConfig");
            }
            else
            {
                var pw = "";
                if (InputBox.Show("Enter Password", "Please enter your password", ref pw, true) ==
    System.Windows.Forms.DialogResult.OK)
                {
                    bool ans = Password.ValidatePassword(pw);

                    if (ans == false)
                    {
                        CustomMessageBox.Show("Bad Password", "Bad Password");
                    }
                }

                if (Password.VerifyPassword(pw))
                {
                    MyView.ShowScreen("HWConfig");
                }
            }
        }

        private void MenuSimulation_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Simulation");
        }

        private void MenuTuning_Click(object sender, EventArgs e)
        {
            

            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("SWConfig");
            }
            else
            {
                var pw = "";
                if (InputBox.Show("Enter Password", "Please enter your password", ref pw, true) ==
    System.Windows.Forms.DialogResult.OK)
                {
                    bool ans = Password.ValidatePassword(pw);

                    if (ans == false)
                    {
                        CustomMessageBox.Show("Bad Password", "Bad Password");
                    }
                }

                if (Password.VerifyPassword(pw))
                {
                    MyView.ShowScreen("SWConfig");
                }
            }
        }

        private void MenuTerminal_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Terminal");
        }

        public void DoDisconnect(MAVLinkInterface comPort)
        {
            if ( PreMethod( ) )
            {
                hudThread?.Abort( );
                hudThread = null;
                
                _movingBase.BUT_connect_Click( this, new EventArgs( ) );

                log.Info( "We are disconnecting" );
                try
                {
                    if ( SpeechEngine != null ) // cancel all pending speech
                        SpeechEngine.SpeakAsyncCancelAll( );

                    comPort.BaseStream.DtrEnable = false;
                    comPort.Close( );
                }
                catch ( Exception ex )
                {
                    log.Error( ex );
                }

                // now that we have closed the connection, cancel the connection stats
                // so that the 'time connected' etc does not grow, but the user can still
                // look at the now frozen stats on the still open form
                try
                {
                    // if terminal is used, then closed using this button.... exception
                    if ( this.connectionStatsForm != null )
                        ( ( ConnectionStats ) this.connectionStatsForm.Controls[ 0 ] ).StopUpdates( );
                }
                catch
                {
                }

                // refresh config window if needed
                if ( MyView.current != null )
                {
                    if ( MyView.current.Name == "HWConfig" )
                        MyView.ShowScreen( "HWConfig" );
                    if ( MyView.current.Name == "SWConfig" )
                        MyView.ShowScreen( "SWConfig" );
                }

                try
                {
                    System.Threading.ThreadPool.QueueUserWorkItem( ( WaitCallback ) delegate
                       {
                           try
                           {
                               MissionPlanner.Log.LogSort.SortLogs( Directory.GetFiles( Settings.Instance.LogDir, "*.tlog" ) );
                           }
                           catch
                           {
                           }
                       }
                 );
                }
                catch
                {
                }

                this.MenuConnect.Image = global::MissionPlanner.Properties.Resources.light_connect_icon;
            }

            LastMethod( );

            _lighting.IsOn = false;
            _lighting.Stop( );
        }

        MovingBase _movingBase;

        public void DoConnect(MAVLinkInterface comPort, string portname, string baud, bool getparams = true)
        {   
            status1.Top = tabMenuView.Height;
            status1.Show( );

            bool skipconnectcheck = false;
            log.Info( "We are connecting to " + portname + " " + baud );

            switch ( portname )
            {
                case "preset":
                    skipconnectcheck = true;
                    if ( comPort.BaseStream is TcpSerial )
                        _connectionControl.CMB_serialport.Text = "TCP";
                    if ( comPort.BaseStream is UdpSerial )
                        _connectionControl.CMB_serialport.Text = "UDP";
                    if ( comPort.BaseStream is UdpSerialConnect )
                        _connectionControl.CMB_serialport.Text = "UDPCl";
                    if ( comPort.BaseStream is SerialPort )
                    {
                        _connectionControl.CMB_serialport.Text = comPort.BaseStream.PortName;
                        _connectionControl.CMB_baudrate.Text = comPort.BaseStream.BaudRate.ToString( );
                    }
                    break;
                case "TCP":
                    comPort.BaseStream = new TcpSerial( );
                    _connectionControl.CMB_serialport.Text = "TCP";
                    break;
                case "UDP":
                    comPort.BaseStream = new UdpSerial( );
                    _connectionControl.CMB_serialport.Text = "UDP";
                    break;
                case "WS":
                    comPort.BaseStream = new WebSocket( );
                    _connectionControl.CMB_serialport.Text = "WS";
                    break;
                case "UDPCl":
                    comPort.BaseStream = new UdpSerialConnect( );
                    _connectionControl.CMB_serialport.Text = "UDPCl";
                    break;
                case "AUTO":
                    // do autoscan
                    Comms.CommsSerialScan.Scan( true );
                    DateTime deadline = DateTime.Now.AddSeconds( 50 );

                    while ( Comms.CommsSerialScan.foundport == false || Comms.CommsSerialScan.run == 1 )
                    {
                        System.Threading.Thread.Sleep( 500 );
                        Console.WriteLine( "wait for port " + CommsSerialScan.foundport + " or " + CommsSerialScan.run );
                        if ( DateTime.Now > deadline )
                        {
                            CustomMessageBox.Show( Strings.Timeout );
                            _connectionControl.IsConnected( false );
                            return;
                        }
                    }
                    return;
                default:
                    comPort.BaseStream = new SerialPort( );
                    break;
            }

            // Tell the connection UI that we are now connected.
            _connectionControl.IsConnected( true );

            // Here we want to reset the connection stats counter etc.
            this.ResetConnectionStats( );

            comPort.MAV.cs.ResetInternals( );

            //cleanup any log being played
            comPort.logreadmode = false;
            if ( comPort.logplaybackfile != null )
                comPort.logplaybackfile.Close( );
            comPort.logplaybackfile = null;

            try
            {
                log.Info( "Set Portname" );
                // set port, then options
                if ( portname.ToLower( ) != "preset" )
                    comPort.BaseStream.PortName = portname;

                log.Info( "Set Baudrate" );
                try
                {
                    if ( baud != "" && baud != "0" )
                        comPort.BaseStream.BaudRate = int.Parse( baud );
                }
                catch ( Exception exp )
                {
                    log.Error( exp );
                }

                // prevent serialreader from doing anything
                comPort.giveComport = true;

                log.Info( "About to do dtr if needed" );
                // reset on connect logic.
                if ( Settings.Instance.GetBoolean( "CHK_resetapmonconnect" ) == true )
                {
                    log.Info( "set dtr rts to false" );
                    comPort.BaseStream.DtrEnable = false;
                    comPort.BaseStream.RtsEnable = false;

                    comPort.BaseStream.toggleDTR( );
                }

                comPort.giveComport = false;

                // setup to record new logs
                try
                {
                    Directory.CreateDirectory( Settings.Instance.LogDir );
                    lock ( this )
                    {
                        // create log names
                        var dt = DateTime.Now.ToString( "yyyy-MM-dd HH-mm-ss" );
                        var tlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                    dt + ".tlog";
                        var rlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                    dt + ".rlog";

                        // check if this logname already exists
                        int a = 1;
                        while ( File.Exists( tlog ) )
                        {
                            Thread.Sleep( 1000 );
                            // create new names with a as an index
                            dt = DateTime.Now.ToString( "yyyy-MM-dd HH-mm-ss" ) + "-" + a.ToString( );
                            tlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                    dt + ".tlog";
                            rlog = Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                    dt + ".rlog";
                        }

                        //open the logs for writing
                        comPort.logfile =
                            new BufferedStream( File.Open( tlog, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None ) );
                        comPort.rawlogfile =
                            new BufferedStream( File.Open( rlog, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None ) );
                        log.Info( "creating logfile " + dt + ".tlog" );
                    }
                }
                catch ( Exception exp2 )
                {
                    log.Error( exp2 );
                    CustomMessageBox.Show( Strings.Failclog );
                } // soft fail

                // reset connect time - for timeout functions
                connecttime = DateTime.Now;

                // do the connect
                comPort.Open( false, skipconnectcheck );

                if ( !comPort.BaseStream.IsOpen )
                {
                    log.Info( "comport is closed. existing connect" );
                    try
                    {
                        _connectionControl.IsConnected( false );
                        UpdateConnectIcon( );
                        comPort.Close( );
                    }
                    catch
                    {
                    }
                    return;
                }

                var ftpfile = false;
                /*
                if ( ( MainV2.ComPort.MAV.cs.capabilities & ( int ) MAVLink.MAV_PROTOCOL_CAPABILITY.FTP ) > 0 )
                {
                    var prd = new ProgressReporterDialogue( );
                    prd.DoWork += ( IProgressReporterDialogue sender ) =>
                    {
                        sender.UpdateProgressAndStatus( -1, "Checking for Param MAVFTP" );
                        var cancel = new CancellationTokenSource( );
                        var paramfileTask = Task.Run<MemoryStream>( ( ) =>
                        {
                            return new MAVFtp( comPort, comPort.MAV.sysid, comPort.MAV.compid ).GetFile(
                                "@PARAM/param.pck", cancel, false, 110 );
                        } );
                        while ( !paramfileTask.IsCompleted )
                        {
                            if ( sender.doWorkArgs.CancelRequested )
                            {
                                cancel.Cancel( );
                                sender.doWorkArgs.CancelAcknowledged = true;
                            }
                        }

                        var paramfile = paramfileTask.Result;
                        if ( paramfile != null && paramfile.Length > 0 )
                        {
                            var mavlist = parampck.unpack( paramfile.ToArray( ) );
                            if ( mavlist != null )
                            {
                                comPort.MAVlist[ comPort.MAV.sysid, comPort.MAV.compid ].param.Clear( );
                                comPort.MAVlist[ comPort.MAV.sysid, comPort.MAV.compid ].param.TotalReported =
                                    mavlist.Count;
                                comPort.MAVlist[ comPort.MAV.sysid, comPort.MAV.compid ].param.AddRange( mavlist );
                                mavlist.ForEach( a =>
                                     comPort.MAVlist[ comPort.MAV.sysid, comPort.MAV.compid ].param_types[ a.Name ] =
                                         a.Type );
                                ftpfile = true;
                            }
                        }
                    };

                    prd.RunBackgroundOperationAsync( );
                }
                */
                if ( !ftpfile )
                 {
                     if ( Settings.Instance.GetBoolean( "Params_BG", false ) )
                         Task.Run( ( ) =>
                         {
                             comPort.getParamList( comPort.MAV.sysid, comPort.MAV.compid );
                         } );
                     else

                         comPort.getParamList( );
                 }

                _connectionControl.UpdateSysIDS( );

                // save the baudrate for this port
                Settings.Instance[ _connectionControl.CMB_serialport.Text + "_BAUD" ] = _connectionControl.CMB_baudrate.Text;

                // refresh config window if needed
                if ( MyView.current != null )
                {
                    if ( MyView.current.Name == "HWConfig" )
                        MyView.ShowScreen( "HWConfig" );
                    if ( MyView.current.Name == "SWConfig" )
                        MyView.ShowScreen( "SWConfig" );
                }

                // load wps on connect option.
                if ( Settings.Instance.GetBoolean( "loadwpsonconnect" ) == true )
                {
                    // only do it if we are connected.
                    if ( comPort.BaseStream.IsOpen )
                    {
                        MenuFlightPlanner_Click( null, null );
                    }
                }

                // get any rallypoints
                if ( MainV2.ComPort.MAV.param.ContainsKey( "RALLY_TOTAL" ) &&
                    int.Parse( MainV2.ComPort.MAV.param[ "RALLY_TOTAL" ].ToString( ) ) > 0 )
                {
                    try
                    {
                        FlightPlanner.GetRallyPointsToolStripMenuItem_Click( null, null );

                        double maxdist = 0;

                        foreach ( var rally in comPort.MAV.rallypoints )
                        {
                            foreach ( var rally1 in comPort.MAV.rallypoints )
                            {
                                var pnt1 = new PointLatLngAlt( rally.Value.y / 10000000.0f, rally.Value.x / 10000000.0f );
                                var pnt2 = new PointLatLngAlt( rally1.Value.y / 10000000.0f,
                                    rally1.Value.x / 10000000.0f );

                                var dist = pnt1.GetDistance( pnt2 );

                                maxdist = Math.Max( maxdist, dist );
                            }
                        }

                        if ( comPort.MAV.param.ContainsKey( "RALLY_LIMIT_KM" ) &&
                            ( maxdist / 1000.0 ) > ( float ) comPort.MAV.param[ "RALLY_LIMIT_KM" ] )
                        {
                            CustomMessageBox.Show( Strings.Warningrallypointdistance + " " +
                                                    ( maxdist / 1000.0 ).ToString( "0.00" ) + " > " +
                                                    ( float ) comPort.MAV.param[ "RALLY_LIMIT_KM" ] );
                        }
                    }
                    catch ( Exception ex ) 
                    { 
                        log.Warn( ex );
                    }
                }

                // get any fences
                if ( MainV2.ComPort.MAV.param.ContainsKey( "FENCE_TOTAL" ) &&
                    int.Parse( MainV2.ComPort.MAV.param[ "FENCE_TOTAL" ].ToString( ) ) > 1 &&
                    MainV2.ComPort.MAV.param.ContainsKey( "FENCE_ACTION" ) )
                {
                    try
                    {
                        FlightPlanner.GeoFencedownloadToolStripMenuItem_Click( null, null );
                    }
                    catch ( Exception ex ) 
                    {
                        log.Warn( ex ); 
                    }
                }
                //Add HUD custom items source 
                HUD.Custom.src = MainV2.ComPort.MAV.cs;

                FlightPlanner.TXT_homelat.Text = MainV2.ComPort.MAV.cs.Location.Lat.ToString( );
                FlightPlanner.TXT_homealt.Text = MainV2.ComPort.MAV.cs.Location.Alt.ToString( );
                FlightPlanner.TXT_homelng.Text = MainV2.ComPort.MAV.cs.Location.Lng.ToString( );

                // set connected icon
                this.MenuConnect.Image = displayicons.Disconnect;
            }
            catch ( Exception ex )
            {
                log.Warn( ex );
                try
                {
                    _connectionControl.IsConnected( false );
                    UpdateConnectIcon( );
                    comPort.Close( );
                }
                catch ( Exception ex2 )
                {
                    log.Warn( ex2 );
                }
                CustomMessageBox.Show( "Can not establish a connection\n\n" + ex.Message );
                return;
            }

            finally
            {
                status1.Hide( );
            }
        }

        private void MenuConnect_Click(object sender, EventArgs e)
        {
            var uav = Configurator.Connection.Uav;

            _connectionControl.CMB_serialport.Text = uav.Name;
            _connectionControl.CMB_serialport.SelectedIndex = _connectionControl.CMB_serialport.FindString( uav.Name );
            _connectionControl.CMB_baudrate.Text = uav.Baudrate.ToString( );

            Connect();
        }

        private void MenuAction_Click(object sender, EventArgs e)
        {
            using ( var joysticSetup = new JoystickSetup( ) )
            {
                joysticSetup.BUT_enable_Click(sender, e);
            }
        }

        private Thread hudThread;
        private bool isCreatedThread;

        private bool PreMethod ( )
        {
            ComPort.giveComport = false;

            log.Info( "MenuConnect Start" );

            // sanity check
            if ( ComPort.BaseStream.IsOpen && ComPort.MAV.cs.groundspeed > 4 )
            {
                if ( ( int ) DialogResult.No ==
                    CustomMessageBox.Show( Strings.Stillmoving, Strings.Disconnect, MessageBoxButtons.YesNo ) )
                {
                    return false;
                }
            }

            try
            {
                log.Info( "Cleanup last logfiles" );
                // cleanup from any previous sessions
                if ( ComPort.logfile != null )
                    ComPort.logfile.Close( );

                if ( ComPort.rawlogfile != null )
                    ComPort.rawlogfile.Close( );
            }
            catch ( Exception ex )
            {
                CustomMessageBox.Show( Strings.ErrorClosingLogFile + ex.Message, Strings.ERROR );
                return false;
            }

            ComPort.logfile = null;
            ComPort.rawlogfile = null;
            return true;
        }

        public void Connect()
        {   
            if ( PreMethod() )
            {
                var uav = Configurator.Connection.Uav;
                DoConnect(ComPort, uav.Name, uav.Baudrate.ToString());

                if ( IsConnected )
                {
                    if ( !isCreatedThread )
                    {
                        using ( var streamReader = new StreamReader( "Hud.txt" ) )
                        {
                            var str = streamReader.ReadLine( );

                            try
                            {
                                _videoProces = new Process( );
                                _videoProces.StartInfo.FileName = str;
                                _videoProces.StartInfo.Arguments = " -w " + Process.GetCurrentProcess( ).Id.ToString( );
                                _videoProces.StartInfo.UseShellExecute = false;
                                _videoProces.StartInfo.RedirectStandardInput = true;
                                _videoProces.Start( );
                                isCreatedThread = true;
                            }
                            catch ( Exception )
                            {
                                isCreatedThread = false;
                            }
                        }
                    }

                    if ( isCreatedThread )
                    {
                        var streamWorker = new StreamWorker( _videoProces.StandardInput );
                        streamWorker.SetCrossOffset( Configurator.Setting.AimPoint );

                        hudThread = new Thread( HudFunc );
                        hudThread.Start( );

                        GlbContext.StreamWorker = streamWorker;
                        GlbContext.VisibleHud( );
                    }
                }
            }

            LastMethod( );
        }

        private void LastMethod ( )
        {

            _connectionControl.UpdateSysIDS( );

            if ( ComPort.BaseStream.IsOpen )
                Loadph_serial( );
        }

        void Loadph_serial()
        {
            try
            {
                if (ComPort.MAV.SerialString == "")
                    return;

                if (ComPort.MAV.SerialString.Contains("CubeBlack") && !ComPort.MAV.SerialString.Contains("CubeBlack+") &&
                    ComPort.MAV.param.ContainsKey("INS_ACC3_ID") && ComPort.MAV.param["INS_ACC3_ID"].Value == 0 &&
                    ComPort.MAV.param.ContainsKey("INS_GYR3_ID") && ComPort.MAV.param["INS_GYR3_ID"].Value == 0 &&
                    ComPort.MAV.param.ContainsKey("INS_ENABLE_MASK") && ComPort.MAV.param["INS_ENABLE_MASK"].Value >= 7)
                {
                    MissionPlanner.Controls.SB.Show("Param Scan");
                }
            }
            catch { }

            try
            {
                if (ComPort.MAV.SerialString == "")
                    return;

                // brd type should be 3
                // devids show which sensor is not detected
                // baro does not list a devid

                //devop read spi lsm9ds0_ext_am 0 0 0x8f 1
                if (ComPort.MAV.SerialString.Contains("CubeBlack") && !ComPort.MAV.SerialString.Contains("CubeBlack+"))
                {
                    Task.Run(() =>
                        {
                            bool bad1 = false;
                            byte[] data = new byte[0];

                            ComPort.device_op(ComPort.MAV.sysid, ComPort.MAV.compid, out data,
                                MAVLink.DEVICE_OP_BUSTYPE.SPI,
                                "lsm9ds0_ext_g", 0, 0, 0x8f, 1);
                            if (data.Length != 0 && (data[0] != 0xd4 && data[0] != 0xd7))
                                bad1 = true;

                            ComPort.device_op(ComPort.MAV.sysid, ComPort.MAV.compid, out data,
                                MAVLink.DEVICE_OP_BUSTYPE.SPI,
                                "lsm9ds0_ext_am", 0, 0, 0x8f, 1);
                            if (data.Length != 0 && data[0] != 0x49)
                                bad1 = true;

                            if (bad1)
                                this.BeginInvoke(method: (Action)delegate
                               {
                                   MissionPlanner.Controls.SB.Show("SPI Scan");
                               });
                        });
                }

            }
            catch { }
        }

        private void CMB_serialport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_connectionControl.CMB_serialport.SelectedItem == _connectionControl.CMB_serialport.Text)
                return;

            comPortName = _connectionControl.CMB_serialport.Text;
            if (comPortName == "UDP" || comPortName == "UDPCl" || comPortName == "TCP" || comPortName == "AUTO")
            {
                _connectionControl.CMB_baudrate.Enabled = false;
            }
            else
            {
                _connectionControl.CMB_baudrate.Enabled = true;
            }

            try
            {
                // check for saved baud rate and restore
                if (Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] != null)
                {
                    _connectionControl.CMB_baudrate.Text =
                        Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"];
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// overriding the OnCLosing is a bit cleaner than handling the event, since it 
        /// is this object.
        /// 
        /// This happens before FormClosed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            log.Info("MainV2_FormClosing");

            log.Info("GMaps write cache");
            // speed up tile saving on exit
            GMap.NET.GMaps.Instance.CacheOnIdleRead = false;
            GMap.NET.GMaps.Instance.BoostCacheEngine = true;

            Settings.Instance["MainHeight"] = this.Height.ToString();
            Settings.Instance["MainWidth"] = this.Width.ToString();
            Settings.Instance["MainMaximised"] = this.WindowState.ToString();

            Settings.Instance["MainLocX"] = this.Location.X.ToString();
            Settings.Instance["MainLocY"] = this.Location.Y.ToString();

            log.Info("close logs");
            AltitudeAngel.Dispose();

            // close bases connection
            try
            {
                ComPort.logreadmode = false;
                if (ComPort.logfile != null)
                    ComPort.logfile.Close();

                if (ComPort.rawlogfile != null)
                    ComPort.rawlogfile.Close();

                ComPort.logfile = null;
                ComPort.rawlogfile = null;
            }
            catch
            {
            }

            log.Info("close ports");
            // close all connections
            foreach (var port in Comports)
            {
                try
                {
                    port.logreadmode = false;
                    if (port.logfile != null)
                        port.logfile.Close();

                    if (port.rawlogfile != null)
                        port.rawlogfile.Close();

                    port.logfile = null;
                    port.rawlogfile = null;
                }
                catch
                {
                }
            }

            log.Info("stop adsb");
            Utilities.adsb.Stop();

            log.Info("stop WarningEngine");
            Warnings.WarningEngine.Stop();

            log.Info("stop GStreamer");
            GStreamer.StopAll();

            log.Info("closing vlcrender");
            try
            {
                while (vlcrender.store.Count > 0)
                    vlcrender.store[0].Stop();
            }
            catch
            {
            }

            log.Info("closing pluginthread");

            pluginthreadrun = false;

            if (pluginthread != null)
                pluginthread.Join();

            log.Info("closing serialthread");

            serialThread = false;

            if (serialreaderthread != null)
                serialreaderthread.Join();

            log.Info("closing joystickthread");

            joystickthreadrun = false;

            if (joystickthread != null)
                joystickthread.Join();

            log.Info("closing httpthread");

            // if we are waiting on a socket we need to force an abort
            httpserver.Stop();

            log.Info("sorting tlogs");
            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem((WaitCallback)delegate
                   {
                       try
                       {
                           MissionPlanner.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));
                       }
                       catch
                       {
                       }
                   }
                );
            }
            catch
            {
            }

            log.Info("closing MyView");

            // close all tabs
            MyView.Dispose();

            log.Info("closing fd");
            try
            {
                //FlightData.Dispose();
            }
            catch
            {
            }
            log.Info("closing fp");
            try
            {
                FlightPlanner.Dispose();
            }
            catch
            {
            }
            log.Info("closing sim");
            try
            {
                Simulation.Dispose();
            }
            catch
            {
            }

            try
            {
                if (ComPort.BaseStream.IsOpen)
                    ComPort.Close();
            }
            catch
            {
            } // i get alot of these errors, the port is still open, but not valid - user has unpluged usb

            // save config
            SaveConfig();

            Console.WriteLine(httpthread?.IsAlive);
            Console.WriteLine(joystickthread?.IsAlive);
            Console.WriteLine(serialreaderthread?.IsAlive);
            Console.WriteLine(pluginthread?.IsAlive);

            log.Info("MainV2_FormClosing done");

            if (MONO)
                this.Dispose();
        }

        private void LoadConfig()
        {
            try
            {
                log.Info("Loading config");

                Settings.Instance.Load();

                comPortName = Settings.Instance.ComPort;
            }
            catch (Exception ex)
            {
                log.Error("Bad Config File", ex);
            }
        }

        private void SaveConfig()
        {
            try
            {
                log.Info("Saving config");
                Settings.Instance.ComPort = comPortName;

                if (_connectionControl != null)
                    Settings.Instance.BaudRate = _connectionControl.CMB_baudrate.Text;

                Settings.Instance.APMFirmware = MainV2.ComPort.MAV.cs.firmware.ToString();

                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// needs to be true by default so that exits properly if no joystick used.
        /// </summary>
        volatile private bool joysendThreadExited = true;

        /// <summary>
        /// thread used to send joystick packets to the MAV
        /// </summary>
        public void Joysticksend()
        {
            float rate = 50; // 1000 / 50 = 20 hz
            int count = 0;

            joystickthreadrun = true;

            while (joystickthreadrun)
            {
                joysendThreadExited = false;
                //so we know this thread is stil alive.           
                try
                {
                    //joystick stuff
                    if (Joystick != null && Joystick.enabled)
                    {
                        if (!Joystick.manual_control)
                        {
                            MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();

                            rc.target_component = ComPort.MAV.compid;
                            rc.target_system = ComPort.MAV.sysid;

                            if ( Joystick.getJoystickAxis(1) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan1_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(2) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan2_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(3) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan3_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(4) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan4_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(5) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan5_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(6) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan6_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(7) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan7_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(8) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan8_raw = ushort.MaxValue;
                            if ( Joystick.getJoystickAxis(9) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan9_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(10) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan10_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(11) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan11_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(12) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan12_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(13) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan13_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(14) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan14_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(15) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan15_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(16) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan16_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(17) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan17_raw = (ushort)0;
                            if ( Joystick.getJoystickAxis(18) == MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan18_raw = (ushort)0;

                            if ( Joystick.getJoystickAxis(1) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan1_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech1;
                            if ( Joystick.getJoystickAxis(2) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan2_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech2;
                            if ( Joystick.getJoystickAxis(3) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan3_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech3;
                            if ( Joystick.getJoystickAxis(4) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan4_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech4;
                            if ( Joystick.getJoystickAxis(5) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan5_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech5;
                            if ( Joystick.getJoystickAxis(6) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan6_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech6;
                            if ( Joystick.getJoystickAxis(7) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan7_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech7;
                            if ( Joystick.getJoystickAxis(8) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan8_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech8;
                            if ( Joystick.getJoystickAxis(9) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan9_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech9;
                            if ( Joystick.getJoystickAxis(10) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan10_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech10;
                            if ( Joystick.getJoystickAxis(11) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan11_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech11;
                            if ( Joystick.getJoystickAxis(12) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan12_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech12;
                            if ( Joystick.getJoystickAxis(13) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan13_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech13;
                            if ( Joystick.getJoystickAxis(14) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan14_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech14;
                            if ( Joystick.getJoystickAxis(15) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan15_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech15;
                            if ( Joystick.getJoystickAxis(16) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan16_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech16;
                            if ( Joystick.getJoystickAxis(17) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan17_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech17;
                            if ( Joystick.getJoystickAxis(18) != MissionPlanner.Joystick.Joystick.joystickaxis.None) rc.chan18_raw = (ushort) MainV2.ComPort.MAV.cs.rcoverridech18;

                            if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                            {
                                /*
                            if (MainV2.comPort.MAV.cs.rssi > 0 && MainV2.comPort.MAV.cs.remrssi > 0)
                            {
                                if (lastratechange.Second != DateTime.Now.Second)
                                {
                                    if (MainV2.comPort.MAV.cs.txbuffer > 90)
                                    {
                                        if (rate < 20)
                                            rate = 21;
                                        rate--;

                                        if (MainV2.comPort.MAV.cs.linkqualitygcs < 70)
                                            rate = 50;
                                    }
                                    else
                                    {
                                        if (rate > 100)
                                            rate = 100;
                                        rate++;
                                    }

                                    lastratechange = DateTime.Now;
                                }
                                 
                            }
                            */
                                //                                Console.WriteLine(DateTime.Now.Millisecond + " {0} {1} {2} {3} {4}", rc.chan1_raw, rc.chan2_raw, rc.chan3_raw, rc.chan4_raw,rate);

                                //Console.WriteLine("Joystick btw " + comPort.BaseStream.BytesToWrite);

                                if (!ComPort.BaseStream.IsOpen)
                                    continue;

                                if (ComPort.BaseStream.BytesToWrite < 50)
                                {
                                    if (Sitl)
                                    {
                                        MissionPlanner.GCSViews.SITL.rcinput();
                                    }
                                    else
                                    {
                                        ComPort.sendPacket(rc, rc.target_system, rc.target_component);
                                    }
                                    count++;
                                    lastjoystick = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            MAVLink.mavlink_manual_control_t rc = new MAVLink.mavlink_manual_control_t();

                            rc.target = ComPort.MAV.compid;

                            if ( Joystick.getJoystickAxis(1) != MissionPlanner.Joystick.Joystick.joystickaxis.None)
                                rc.x = MainV2.ComPort.MAV.cs.rcoverridech1;
                            if ( Joystick.getJoystickAxis(2) != MissionPlanner.Joystick.Joystick.joystickaxis.None)
                                rc.y = MainV2.ComPort.MAV.cs.rcoverridech2;
                            if ( Joystick.getJoystickAxis(3) != MissionPlanner.Joystick.Joystick.joystickaxis.None)
                                rc.z = MainV2.ComPort.MAV.cs.rcoverridech3;
                            if ( Joystick.getJoystickAxis(4) != MissionPlanner.Joystick.Joystick.joystickaxis.None)
                                rc.r = MainV2.ComPort.MAV.cs.rcoverridech4;

                            if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                            {
                                if (!ComPort.BaseStream.IsOpen)
                                    continue;

                                if (ComPort.BaseStream.BytesToWrite < 50)
                                {
                                    if (Sitl)
                                    {
                                        MissionPlanner.GCSViews.SITL.rcinput();
                                    }
                                    else
                                    {
                                        ComPort.sendPacket(rc, ComPort.MAV.sysid, ComPort.MAV.compid);
                                    }
                                    count++;
                                    lastjoystick = DateTime.Now;
                                }
                            }
                        }
                    }
                    
                    Thread.Sleep(20);
                }
                catch
                {
                } // cant fall out
            }
            joysendThreadExited = true; //so we know this thread exited.    
        }

        /// <summary>
        /// Used to fix the icon status for unexpected unplugs etc...
        /// </summary>
        private void UpdateConnectIcon()
        {
            if ((DateTime.Now - connectButtonUpdate).Milliseconds > 500)
            {
                //                        Console.WriteLine(DateTime.Now.Millisecond);
                if (ComPort.BaseStream.IsOpen)
                {
                    if (this.MenuConnect.Image == null || (string)this.MenuConnect.Image.Tag != "Disconnect")
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                       {
                           this.MenuConnect.Image = displayicons.Disconnect;
                           this.MenuConnect.Image.Tag = "Disconnect";
                           this.MenuConnect.Text = Strings.DISCONNECTc;

                           _connectionControl.IsConnected(true);
                            IsConnected = true;
                           ConnectButtonEnabled( IsConnected );
                       } );
                    }
                }
                else
                {
                    if (this.MenuConnect.Image != null && (string)this.MenuConnect.Image.Tag != "Connect")
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                       {
                           this.MenuConnect.Image = displayicons.Connect;
                           this.MenuConnect.Image.Tag = "Connect";
                           this.MenuConnect.Text = Strings.CONNECTc;

                           _connectionControl.IsConnected(false);
                           IsConnected = false;
                           ConnectButtonEnabled( IsConnected );

                           if (_connectionStats != null)
                           {
                               _connectionStats.StopUpdates();
                           }
                       });
                    }

                    if (ComPort.logreadmode)
                    {
                        this.BeginInvoke((MethodInvoker)delegate { _connectionControl.IsConnected(true); });
                    }
                }
                connectButtonUpdate = DateTime.Now;
            }
        }

        ManualResetEvent PluginThreadrunner = new ManualResetEvent(false);

        private void PluginThread()
        {
            Hashtable nextrun = new Hashtable();

            pluginthreadrun = true;

            PluginThreadrunner.Reset();

            while (pluginthreadrun)
            {
                try
                {
                    lock (Plugin.PluginLoader.Plugins)
                    {
                        foreach (var plugin in Plugin.PluginLoader.Plugins)
                        {
                            if (!nextrun.ContainsKey(plugin))
                                nextrun[plugin] = DateTime.MinValue;

                            if (DateTime.Now > plugin.NextRun)
                            {
                                // get ms till next run
                                int msnext = (int)(1000 / plugin.loopratehz);
                                // allow the plug to modify this, if needed
                                plugin.NextRun = DateTime.Now.AddMilliseconds(msnext);

                                try
                                {
                                    bool ans = plugin.Loop();
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }

                // max rate is 100 hz - prevent massive cpu usage
                System.Threading.Thread.Sleep(10);
            }
            
            while (Plugin.PluginLoader.Plugins.Count > 0)
            {
                var plugin = Plugin.PluginLoader.Plugins[0];
                try
                {
                    plugin.Exit();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
                Plugin.PluginLoader.Plugins.Remove(plugin);
            }

            PluginThreadrunner.Set();

            return;
        }

        ManualResetEvent SerialThreadrunner = new ManualResetEvent(false);

        /// <summary>
        /// main serial reader thread
        /// controls
        /// serial reading
        /// link quality stats
        /// speech voltage - custom - alt warning - data lost
        /// heartbeat packet sending
        /// 
        /// and can't fall out
        /// </summary>
        private async void SerialReader()
        {
            if (serialThread == true)
                return;
            serialThread = true;

            SerialThreadrunner.Reset();

            int minbytes = 10;

            int altwarningmax = 0;

            bool armedstatus = false;

            string lastmessagehigh = "";

            DateTime speechcustomtime = DateTime.Now;

            DateTime speechlowspeedtime = DateTime.Now;

            DateTime linkqualitytime = DateTime.Now;

            while (serialThread)
            {
                try
                {
                    Thread.Sleep(1); // was 5

                    try
                    {
                        if (GCSViews.ConfigTerminal.comPort is MAVLinkSerialPort)
                        {
                        }
                        else
                        {
                            if (GCSViews.ConfigTerminal.comPort != null && GCSViews.ConfigTerminal.comPort.IsOpen)
                                continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // update connect/disconnect button and info stats
                    try
                    {
                        UpdateConnectIcon();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // 30 seconds interval speech options
                    if (SpeechEnable && SpeechEngine != null && (DateTime.Now - speechcustomtime).TotalSeconds > 30 &&
                        (MainV2.ComPort.logreadmode || ComPort.BaseStream.IsOpen))
                    {
                        if (MainV2.SpeechEngine.IsReady)
                        {
                            if (Settings.Instance.GetBoolean("speechcustomenabled"))
                            {
                                MainV2.SpeechEngine.SpeakAsync(ArduPilot.Common.speechConversion(ComPort.MAV, "" + Settings.Instance["speechcustom"]));
                            }

                            speechcustomtime = DateTime.Now;
                        }

                        // speech for battery alerts
                        //speechbatteryvolt
                        float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                        float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                        if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                            MainV2.ComPort.MAV.cs.battery_voltage <= warnvolt &&
                            MainV2.ComPort.MAV.cs.battery_voltage >= 5.0)
                        {
                            if (MainV2.SpeechEngine.IsReady)
                            {
                                MainV2.SpeechEngine.SpeakAsync(ArduPilot.Common.speechConversion(ComPort.MAV, "" + Settings.Instance["speechbattery"]));
                            }
                        }
                        else if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                                 (MainV2.ComPort.MAV.cs.battery_remaining) < warnpercent &&
                                 MainV2.ComPort.MAV.cs.battery_voltage >= 5.0 &&
                                 MainV2.ComPort.MAV.cs.battery_remaining != 0.0)
                        {
                            if (MainV2.SpeechEngine.IsReady)
                            {
                                MainV2.SpeechEngine.SpeakAsync(
                                    ArduPilot.Common.speechConversion(ComPort.MAV, "" + Settings.Instance["speechbattery"]));
                            }
                        }
                    }

                    // speech for airspeed alerts
                    if (SpeechEnable && SpeechEngine != null && (DateTime.Now - speechlowspeedtime).TotalSeconds > 10 &&
                        (MainV2.ComPort.logreadmode || ComPort.BaseStream.IsOpen))
                    {
                        if (Settings.Instance.GetBoolean("speechlowspeedenabled") == true && MainV2.ComPort.MAV.cs.armed)
                        {
                            float warngroundspeed = Settings.Instance.GetFloat("speechlowgroundspeedtrigger");
                            float warnairspeed = Settings.Instance.GetFloat("speechlowairspeedtrigger");

                            if (MainV2.ComPort.MAV.cs.airspeed < warnairspeed)
                            {
                                if (MainV2.SpeechEngine.IsReady)
                                {
                                    MainV2.SpeechEngine.SpeakAsync(
                                        ArduPilot.Common.speechConversion(ComPort.MAV, "" + Settings.Instance["speechlowairspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else if (MainV2.ComPort.MAV.cs.groundspeed < warngroundspeed)
                            {
                                if (MainV2.SpeechEngine.IsReady)
                                {
                                    MainV2.SpeechEngine.SpeakAsync(
                                        ArduPilot.Common.speechConversion(ComPort.MAV, "" + Settings.Instance["speechlowgroundspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else
                            {
                                speechlowspeedtime = DateTime.Now;
                            }
                        }
                    }

                    // speech altitude warning - message high warning
                    if (SpeechEnable && SpeechEngine != null &&
                        (MainV2.ComPort.logreadmode || ComPort.BaseStream.IsOpen))
                    {
                        float warnalt = float.MaxValue;
                        if (Settings.Instance.ContainsKey("speechaltheight"))
                        {
                            warnalt = Settings.Instance.GetFloat("speechaltheight");
                        }
                        try
                        {
                            altwarningmax = (int)Math.Max(MainV2.ComPort.MAV.cs.alt, altwarningmax);

                            if (Settings.Instance.GetBoolean("speechaltenabled") == true && MainV2.ComPort.MAV.cs.alt != 0.00 &&
                                (MainV2.ComPort.MAV.cs.alt <= warnalt) && MainV2.ComPort.MAV.cs.armed)
                            {
                                if (altwarningmax > warnalt)
                                {
                                    if (MainV2.SpeechEngine.IsReady)
                                        MainV2.SpeechEngine.SpeakAsync(
                                            ArduPilot.Common.speechConversion(ComPort.MAV, "" + Settings.Instance["speechalt"]));
                                }
                            }
                        }
                        catch
                        {
                        } // silent fail


                        try
                        {
                            // say the latest high priority message
                            if (MainV2.SpeechEngine.IsReady &&
                                lastmessagehigh != MainV2.ComPort.MAV.cs.messageHigh && MainV2.ComPort.MAV.cs.messageHigh != null)
                            {
                                if (!MainV2.ComPort.MAV.cs.messageHigh.StartsWith("PX4v2 "))
                                {
                                    MainV2.SpeechEngine.SpeakAsync(MainV2.ComPort.MAV.cs.messageHigh);
                                    lastmessagehigh = MainV2.ComPort.MAV.cs.messageHigh;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // not doing anything
                    if (!MainV2.ComPort.logreadmode && !ComPort.BaseStream.IsOpen)
                    {
                        altwarningmax = 0;
                    }

                    // attenuate the link qualty over time
                    if ((DateTime.Now - MainV2.ComPort.MAV.lastvalidpacket).TotalSeconds >= 1)
                    {
                        if (linkqualitytime.Second != DateTime.Now.Second)
                        {
                            MainV2.ComPort.MAV.cs.linkqualitygcs = (ushort)(MainV2.ComPort.MAV.cs.linkqualitygcs * 0.8f);
                            linkqualitytime = DateTime.Now;

                            // force redraw if there are no other packets are being read
                            //GCSViews.FlightData.myhud.Invalidate();
                        }
                    }

                    // data loss warning - wait min of 10 seconds, ignore first 30 seconds of connect, repeat at 5 seconds interval
                    if ((DateTime.Now - MainV2.ComPort.MAV.lastvalidpacket).TotalSeconds > 10
                        && (DateTime.Now - connecttime).TotalSeconds > 30
                        && (DateTime.Now - nodatawarning).TotalSeconds > 5
                        && (MainV2.ComPort.logreadmode || ComPort.BaseStream.IsOpen)
                        && MainV2.ComPort.MAV.cs.armed)
                    {
                        if (SpeechEnable && SpeechEngine != null)
                        {
                            if (MainV2.SpeechEngine.IsReady)
                            {
                                MainV2.SpeechEngine.SpeakAsync("WARNING No Data for " +
                                                               (int)
                                                                   (DateTime.Now - MainV2.ComPort.MAV.lastvalidpacket)
                                                                       .TotalSeconds + " Seconds");
                                nodatawarning = DateTime.Now;
                            }
                        }
                    }

                    // get home point on armed status change.
                    if (armedstatus != MainV2.ComPort.MAV.cs.armed && ComPort.BaseStream.IsOpen)
                    {
                        armedstatus = MainV2.ComPort.MAV.cs.armed;
                        // status just changed to armed
                        if (MainV2.ComPort.MAV.cs.armed == true &&
                            MainV2.ComPort.MAV.apname != MAVLink.MAV_AUTOPILOT.INVALID &&
                            MainV2.ComPort.MAV.aptype != MAVLink.MAV_TYPE.GIMBAL)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(state =>
                            {
                                Thread.CurrentThread.Name = "Arm State change";
                                try
                                {
                                    while (ComPort.giveComport == true)
                                        Thread.Sleep(100);

                                    MainV2.ComPort.MAV.cs.HomeLocation = new PointLatLngAlt(MainV2.ComPort.getWP(0));
                                    if (MyView.current != null && MyView.current.Name == "FlightPlanner")
                                    {
                                        // update home if we are on flight data tab
                                        this.BeginInvoke((Action)delegate { FlightPlanner.UpdateHome(); });
                                    }

                                }
                                catch
                                {
                                    // dont hang this loop
                                    this.BeginInvoke(
                                        (Action)
                                            delegate
                                            {
                                                CustomMessageBox.Show("Failed to update home location (" +
                                                                      MainV2.ComPort.MAV.sysid + ")");
                                            });
                                }
                            });
                        }

                        if (SpeechEnable && SpeechEngine != null)
                        {
                            if (Settings.Instance.GetBoolean("speecharmenabled"))
                            {
                                string speech = armedstatus ? Settings.Instance["speecharm"] : Settings.Instance["speechdisarm"];
                                if (!string.IsNullOrEmpty(speech))
                                {
                                    MainV2.SpeechEngine.SpeakAsync(ArduPilot.Common.speechConversion(ComPort.MAV, speech));
                                }
                            }
                        }
                    }

                    if (ComPort.MAV.param.TotalReceived < ComPort.MAV.param.TotalReported)
                    {
                        if (ComPort.MAV.param.TotalReported > 0 && ComPort.BaseStream.IsOpen)
                            instance.status1.Percent =
                                (ComPort.MAV.param.TotalReceived / (double)ComPort.MAV.param.TotalReported) * 100.0;
                    }

                    // send a hb every seconds from gcs to ap
                    if (heatbeatSend.Second != DateTime.Now.Second)
                    {
                        MAVLink.mavlink_heartbeat_t htb = new MAVLink.mavlink_heartbeat_t()
                        {
                            type = (byte)MAVLink.MAV_TYPE.GCS,
                            autopilot = (byte)MAVLink.MAV_AUTOPILOT.INVALID,
                            mavlink_version = 3 // MAVLink.MAVLINK_VERSION
                        };

                        // enumerate each link
                        foreach (var port in Comports.ToArray())
                        {
                            if (!port.BaseStream.IsOpen)
                                continue;

                            // poll for params at heartbeat interval - primary mav on this port only
                            if (!port.giveComport)
                            {
                                try
                                {
                                    // poll only when not armed
                                    if (!port.MAV.cs.armed)
                                    {
                                        port.getParamPoll();
                                        port.getParamPoll();
                                    }
                                }
                                catch
                                {
                                }
                            }

                            // there are 3 hb types we can send, mavlink1, mavlink2 signed and unsigned
                            bool sentsigned = false;
                            bool sentmavlink1 = false;
                            bool sentmavlink2 = false;

                            // enumerate each mav
                            foreach (var MAV in port.MAVlist)
                            {
                                try
                                {
                                    // poll for version if we dont have it - every mav every port
                                    if (!port.giveComport && !MAV.cs.armed && (DateTime.Now.Second % 20) == 0 && MAV.cs.version < new Version(0, 1))
                                        port.getVersion(MAV.sysid, MAV.compid, false);

                                    // are we talking to a mavlink2 device
                                    if (MAV.mavlinkv2)
                                    {
                                        // is signing enabled
                                        if (MAV.signing)
                                        {
                                            // check if we have already sent
                                            if (sentsigned)
                                                continue;
                                            sentsigned = true;
                                        }
                                        else
                                        {
                                            // check if we have already sent
                                            if (sentmavlink2)
                                                continue;
                                            sentmavlink2 = true;
                                        }
                                    }
                                    else
                                    {
                                        // check if we have already sent
                                        if (sentmavlink1)
                                            continue;
                                        sentmavlink1 = true;
                                    }

                                    port.sendPacket(htb, MAV.sysid, MAV.compid);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                    // close the bad port
                                    try
                                    {
                                        port.Close();
                                    }
                                    catch
                                    {
                                    }
                                    // refresh the screen if needed
                                    if (port == MainV2.ComPort)
                                    {
                                        // refresh config window if needed
                                        if (MyView.current != null)
                                        {
                                            this.BeginInvoke((MethodInvoker)delegate ()
                                           {
                                               if (MyView.current.Name == "HWConfig")
                                                   MyView.ShowScreen("HWConfig");
                                               if (MyView.current.Name == "SWConfig")
                                                   MyView.ShowScreen("SWConfig");
                                           });
                                        }
                                    }
                                }
                            }
                        }

                        heatbeatSend = DateTime.Now;
                    }

                    // if not connected or busy, sleep and loop
                    if (!ComPort.BaseStream.IsOpen || ComPort.giveComport == true)
                    {
                        if (!ComPort.BaseStream.IsOpen)
                        {
                            // check if other ports are still open
                            foreach (var port in Comports)
                            {
                                if (port.BaseStream.IsOpen)
                                {
                                    Console.WriteLine("Main comport shut, swapping to other mav");
                                    ComPort = port;
                                    break;
                                }
                            }
                        }

                        System.Threading.Thread.Sleep(100);
                    }

                    // read the interfaces
                    foreach (var port in Comports.ToArray())
                    {
                        if (!port.BaseStream.IsOpen)
                        {
                            // skip primary interface
                            if (port == ComPort)
                                continue;

                            // modify array and drop out
                            Comports.Remove(port);
                            port.Dispose();
                            break;
                        }

                        DateTime startread = DateTime.Now;

                        // must be open, we have bytes, we are not yielding the port,
                        // the thread is meant to be running and we only spend 1 seconds max in this read loop
                        while (port.BaseStream.IsOpen && port.BaseStream.BytesToRead > minbytes &&
                               port.giveComport == false && serialThread && startread.AddSeconds(1) > DateTime.Now)
                        {
                            try
                            {
                                await port.readPacketAsync().ConfigureAwait(false);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                        // update currentstate of sysids on the port
                        foreach (var MAV in port.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, port, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Tracking.AddException(e);
                    log.Error("Serial Reader fail :" + e.ToString());
                    try
                    {
                        ComPort.Close();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }

            Console.WriteLine("SerialReader Done");
            SerialThreadrunner.Set();
        }

        private void BtnTask_Click( object sender, EventArgs e )
        {
            FlightPlanner.cmb_missiontype.SelectedIndex = ( int ) MAVLink.MAV_MISSION_TYPE.MISSION;
            FlightPlanner.FlightMissionTableShow( );
        }

        private void BtnView_Click( object sender, EventArgs e )
        {
            FlightPlanner.FlightMissionTableHide( );
        }

        private void BtnAirfields_Click( object sender, EventArgs e )
        {
            FlightPlanner.cmb_missiontype.SelectedIndex = ( int ) MAVLink.MAV_MISSION_TYPE.RALLY;
            FlightPlanner.FlightMissionTableShow( );
        }

        private void BtnArchive_Click( object sender, EventArgs e )
        {
            FlightPlanner.FlightMissionTableHide( );
        }

        private void BtnBlackBox_Click ( object sender, EventArgs e )
        {
            FlightPlanner.FlightMissionTableHide( );
        }

        private void BtnSettings_Click( object sender, EventArgs e )
        {
            FlightPlanner.FlightMissionTableHide( );
        }

        private void BtnClearAirfields_Click( object sender, EventArgs e )
        {
            FlightPlanner.ClearMissionToolStripMenuItem_Click( sender, e );
            FlightPlanner.rallypointoverlay.Clear( );
            MainV2.ComPort.MAV.rallypoints.Clear( );
        }

        private void BtnImportAirfields_Click ( object sender, EventArgs e )
        {
            FlightPlanner.BUT_read_Click( sender, e );
        }

        private void BtnExportAirfields_Click ( object sender, EventArgs e )
        {
            FlightPlanner.BUT_write_Click( sender, e );
        }

        private void BtnEditAirfields_Click( object sender, EventArgs e )
        {
            _isAirfieldsEdit = true;
            ForEditTabsEnabled( false );
            FlightPlanner.MainMapEdited = true;
        }

        private bool _isAirfieldsEdit;

        public void BtnMapEditOk_Click ( object sender, EventArgs e )
        {
            if ( _isAirfieldsEdit )
            {
                if ( Configurator.Setting.General.CheckAlternateAirfields )
                {
                    if ( !MainV2.ComPort.MAV.cs.armed )
                    {
                        if ( FlightPlanner.Commands.RowCount == 0 )
                        {
                            tabMenuView.mapEditTab.lblNotAirfields.Show( );
                            return;
                        }
                        else
                        {
                            JoystickActivate( );
                        }
                    }
                    else
                    {
                        JoystickActivate( );
                    }
                }
                else
                {
                    JoystickActivate( );
                }
            }

            _isAirfieldsEdit = false;
            tabMenuView.mapEditTab.lblNotAirfields.Hide( );

            ForEditTabsEnabled( true );
            FlightPlanner.MainMapEdited = false;
        }

        private void BtnMapEditCancel_Click ( object sender, EventArgs e )
        {
            _isAirfieldsEdit = false;

            ForEditTabsEnabled( true );
            FlightPlanner.MainMapEdited = false;
        }

        private void TabMenuRollingTab( object sender, EventArgs e )
        {
            FlightPlanner.pFlightCalculation.Top = MainV2.instance.tabMenuView.Height;
        }

        private void TabViewBtnHome_Click ( object sender, EventArgs e )
        {
            FlightPlanner.MainMap.Position = MainV2.ComPort.MAV.cs.MovingBase;
            FlightPlanner.MainMap.Zoom = STARTED_MAP_ZOOM;
        }

        private void TabViewBtnStartPlace_Click ( object sender, EventArgs e )
        {
            FlightPlanner.MainMap.Position = MainV2.ComPort.MAV.cs.HomeLocation;
            FlightPlanner.MainMap.Zoom = STARTED_MAP_ZOOM;
        }

        private void TabViewBtnUav_Click ( object sender, EventArgs e )
        {
            FlightPlanner.MainMap.Position = MainV2.ComPort.MAV.cs.Location;
            FlightPlanner.MainMap.Zoom = STARTED_MAP_ZOOM;
        }

        private void BtnTaskClear_Click ( object sender, EventArgs e )
        {   
            FlightPlanner.ClearMissionToolStripMenuItem_Click( sender, e );
        }

        private void BtnArm_Click ( object sender, EventArgs e )
        {
            if ( Configurator.Setting.General.CheckAlternateAirfields )
            {
                if ( FlightPlanner.MainMap.Overlays.Where( a => a.Id == "rally" ).Count( ) == 0 )
                {
                    var resourceManager = new ResourceManager( GetType( ).FullName, Assembly.GetExecutingAssembly( ) );
                    var checkedAirfieldsText = resourceManager.GetString( "checkedAirfieldsText", CultureInfo.CurrentUICulture );
                    var checkedAirfieldsCaption = resourceManager.GetString( "checkedAirfieldsCaption" );

                    MessageBox.Show( checkedAirfieldsText, checkedAirfieldsCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning );

                    return;
                }
                else
                {
                    JoystickActivate( );
                }
            }

            tabMenuView.taskTab.btnDisarm.Show( );
            tabMenuView.taskTab.btnArm.Hide( );

            ArmAndDisarm( );
        }

        private void BtnDisarm_Click ( object sender, EventArgs e )
        {
            tabMenuView.taskTab.btnArm.Show( );
            tabMenuView.taskTab.btnDisarm.Hide( );
            
            ArmAndDisarm( );
        }

        private void BtnMessages_Click ( object sender, EventArgs e )
        {
            new MessageForm( ).ShowDialog( );
        }

        private void BtnLoadMap_Click ( object sender, EventArgs e )
        {
            var area = FlightPlanner.MainMap.ViewArea;

            var resourceManager = new ResourceManager( GetType( ).FullName, Assembly.GetExecutingAssembly( ) );
            var inputDialog = new TBInputDialog( );

            inputDialog.Text = resourceManager.GetString( "tbID_Title", CultureInfo.CurrentUICulture );

            inputDialog.trackBar.Minimum = 1;
            inputDialog.trackBar.Maximum = 20;

            inputDialog.ShowDialog( );

            int maxzoom = inputDialog.trackBar.Value;

            for ( int i = 1; i <= maxzoom; i++ )
            {
                var obj = new TilePrefetcher( );
                ThemeManager.ApplyThemeTo( obj );
                obj.ShowCompleteMessage = false;
                obj.Start( area, i, FlightPlanner.MainMap.MapProvider, 0, 0 );

                if ( obj.UserAborted )
                {
                    obj.Dispose( );
                    break;
                }

                obj.Dispose( );
            }
        }

        private void ArmAndDisarm ( )
        {
            if ( !MainV2.ComPort.BaseStream.IsOpen )
                return;

            // arm the MAV
            try
            {
                var isitarmed = MainV2.ComPort.MAV.cs.armed;
                var action = MainV2.ComPort.MAV.cs.armed ? "Disarm" : "Arm";

                if ( isitarmed )
                    if ( CustomMessageBox.Show( "Are you sure you want to " + action, action,
                            CustomMessageBox.MessageBoxButtons.YesNo ) !=
                        CustomMessageBox.DialogResult.Yes )
                        return;
                StringBuilder sb = new StringBuilder( );
                var sub = MainV2.ComPort.SubscribeToPacketType( MAVLink.MAVLINK_MSG_ID.STATUSTEXT, message =>
                {
                    sb.AppendLine( Encoding.ASCII.GetString( ( ( MAVLink.mavlink_statustext_t ) message.data ).text )
                        .TrimEnd( '\0' ) );
                    return true;
                } );
                bool ans = MainV2.ComPort.doARM( !isitarmed );
                MainV2.ComPort.UnSubscribeToPacketType( sub );
                if ( ans == false )
                {
                    if ( CustomMessageBox.Show(
                            action + " failed.\n" + sb.ToString( ) + "\nForce " + action +
                            " can bypass safety checks,\nwhich can lead to the vehicle crashing\nand causing serious injuries.\n\nDo you wish to Force " +
                            action + "?", Strings.ERROR, CustomMessageBox.MessageBoxButtons.YesNo,
                            CustomMessageBox.MessageBoxIcon.Exclamation, "Force " + action, "Cancel" ) ==
                        CustomMessageBox.DialogResult.Yes )
                    {
                        ans = MainV2.ComPort.doARM( !isitarmed, true );
                        if ( ans == false )
                        {
                            CustomMessageBox.Show( Strings.ErrorRejectedByMAV, Strings.ERROR );
                        }
                    }
                }
            }
            catch
            {
                tabMenuView.taskTab.btnArm.Show( );
                tabMenuView.taskTab.btnDisarm.Hide( );
                
                CustomMessageBox.Show( Strings.ErrorNoResponce, Strings.ERROR );
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            tabMenuView.taskTab.btnImport.Click += BtnImport_Click;
            tabMenuView.taskTab.btnExport.Click += BtnExport_Click;
            tabMenuView.taskTab.btnOpen.Click += BtnOpen_Click;
            tabMenuView.taskTab.btnSave.Click += BtnSave_Click;
            tabMenuView.taskTab.btnEdit.Click += BtnTaskEdit_Click;
            tabMenuView.taskTab.btnClear.Click += BtnTaskClear_Click;
            tabMenuView.taskTab.btnArm.Click += BtnArm_Click;
            tabMenuView.taskTab.btnDisarm.Click += BtnDisarm_Click;
            tabMenuView.taskTab.btnCalcOn.Click += BtnCalcOn_Click;
            tabMenuView.taskTab.btnMessages.Click += BtnMessages_Click;
            tabMenuView.btnTask.Click += BtnTask_Click;

            tabMenuView.airfieldsTab.btnImport.Click += BtnImportAirfields_Click;
            tabMenuView.airfieldsTab.btnExport.Click += BtnExportAirfields_Click;
            tabMenuView.airfieldsTab.btnClear.Click += BtnClearAirfields_Click;
            tabMenuView.airfieldsTab.btnEdit.Click += BtnEditAirfields_Click;
            tabMenuView.btnAirfields.Click += BtnAirfields_Click;

            tabMenuView.mapEditTab.btnOk.Click += BtnMapEditOk_Click;
            tabMenuView.mapEditTab.btnCancel.Click += BtnMapEditCancel_Click;

            tabMenuView.settingsTab.btnCompass.Click += BtnCompass_Click;
            tabMenuView.settingsTab.btnAlignment.Click += BtnAlignment_Click;
            tabMenuView.settingsTab.btnAccelerometer.Click += BtnAccelerometer_Click;
            tabMenuView.settingsTab.btnControl.Click += BtnControl_Click;
            tabMenuView.settingsTab.btnConfig.Click += BtnConfig_Click;
            tabMenuView.settingsTab.btnESC.Click += BtnEsc_Click;
            tabMenuView.settingsTab.btnSetups.Click += BtnSetups_Click;
            tabMenuView.settingsTab.btnBattery.Click += BtnBattery_Click;
            tabMenuView.btnSettings.Click += BtnSettings_Click;
            
            tabMenuView.btnView.Click += BtnView_Click;
            tabMenuView.viewTab.btnHome.Click += TabViewBtnHome_Click;
            tabMenuView.viewTab.btnUAV.Click += TabViewBtnUav_Click;
            tabMenuView.viewTab.btnStartPlace.Click += TabViewBtnStartPlace_Click;
            tabMenuView.viewTab.btnLoadMap.Click += BtnLoadMap_Click;
            
            tabMenuView.btnBlackBox.Click += BtnBlackBox_Click;
            tabMenuView.blackBoxTab.btnDownload.Click += BtnBBoxDownload_Click;
            tabMenuView.blackBoxTab.btnOpen.Click += BtnBBoxOpen_Click;

            tabMenuView.RollingTab += TabMenuRollingTab;

            var isAdminMode = Configurator.App.Mode == Configs.EAppMode.admin;
            
            if ( isAdminMode )
            {
                Text += " [Admin]";
                GlbContext.AppMode = EAppMode.admin;
            }

            ForAppModeVisible( isAdminMode );

            // check if its defined, and force to show it if not known about
            if (Settings.Instance["menu_autohide"] == null)
            {
                Settings.Instance["menu_autohide"] = "false";
            }

            try
            {
                AutoHideMenu(Settings.Instance.GetBoolean("menu_autohide"));
            }
            catch
            {
            }

           // MyView.AddScreen(new MainSwitcher.Screen("FlightData", FlightData, false));
            MyView.AddScreen(new MainSwitcher.Screen("FlightPlanner", FlightPlanner, true));
            MyView.AddScreen(new MainSwitcher.Screen("HWConfig", typeof(GCSViews.InitialSetup), false));
            MyView.AddScreen(new MainSwitcher.Screen("SWConfig", typeof(GCSViews.SoftwareConfig), false));
            MyView.AddScreen(new MainSwitcher.Screen("Simulation", Simulation, true));
            MyView.AddScreen(new MainSwitcher.Screen("Help", typeof(GCSViews.Help), false));

            // hide simulation under mono
            if (Program.MONO)
            {
                MenuSimulation.Visible = false;
            }

            try
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                }
                else
                {
                    log.Info("Load Pluggins");
                    Plugin.PluginLoader.DisabledPluginNames.Clear();
                    foreach (var s in Settings.Instance.GetList("DisabledPlugins")) Plugin.PluginLoader.DisabledPluginNames.Add(s);
                    Plugin.PluginLoader.LoadAll();
                    log.Info("Load Pluggins... Done");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            if (Program.Logo != null && Program.name == "VVVVZ")
            {
                this.PerformLayout();
                MenuFlightPlanner_Click(this, e);
                MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightPlanner));
            }
            else
            {
                this.PerformLayout();
                log.Info("show FlightData");
                //MenuFlightData_Click(this, e);
                log.Info("show FlightData... Done");
                //MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightData));
            }

            // for long running tasks using own threads.
            // for short use threadpool

            this.SuspendLayout();

            // setup http server
            try
            {
                log.Info("start http");
                httpthread = new Thread(new httpserver().listernforclients)
                {
                    Name = "motion jpg stream-network kml",
                    IsBackground = true
                };
                httpthread.Start();
            }
            catch (Exception ex)
            {
                log.Error("Error starting TCP listener thread: ", ex);
                CustomMessageBox.Show(ex.ToString());
            }

            log.Info("start joystick");
            // setup joystick packet sender
            joystickthread = new Thread(new ThreadStart(Joysticksend))
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "Main joystick sender"
            };
            joystickthread.Start();

            log.Info("start serialreader");
            // setup main serial reader
            serialreaderthread = new Thread(SerialReader)
            {
                IsBackground = true,
                Name = "Main Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            serialreaderthread.Start();

            log.Info("start plugin thread");
            // setup main plugin thread
            pluginthread = new Thread(PluginThread)
            {
                IsBackground = true,
                Name = "plugin runner thread",
                Priority = ThreadPriority.BelowNormal
            };
            pluginthread.Start();


            ThreadPool.QueueUserWorkItem(LoadGDALImages);
            
            ThreadPool.QueueUserWorkItem(BGLoadAirports);

            ThreadPool.QueueUserWorkItem(BGCreateMaps);

            //ThreadPool.QueueUserWorkItem(BGGetAlmanac);

            ThreadPool.QueueUserWorkItem(BGgetTFR);

            ThreadPool.QueueUserWorkItem(BGNoFly);

            ThreadPool.QueueUserWorkItem(BGGetKIndex);

            // update firmware version list - only once per day
            ThreadPool.QueueUserWorkItem(BGFirmwareCheck);

            log.Info("start AutoConnect");
            AutoConnect.NewMavlinkConnection += (sender, serial) =>
            {
                try
                {
                    log.Info("AutoConnect.NewMavlinkConnection " + serial.PortName);
                    MainV2.instance.BeginInvoke((Action)delegate
                   {
                       if (MainV2.ComPort.BaseStream.IsOpen)
                       {
                           var mav = new MAVLinkInterface();
                           mav.BaseStream = serial;
                           MainV2.instance.DoConnect(mav, "preset", serial.PortName);

                           MainV2.Comports.Add(mav);
                       }
                       else
                       {
                           MainV2.ComPort.BaseStream = serial;
                           MainV2.instance.DoConnect(MainV2.ComPort, "preset", serial.PortName);
                       }
                   });
                }
                catch (Exception ex) { log.Error(ex); }
            };
            AutoConnect.NewVideoStream += (sender, gststring) =>
            {
                try
                {
                    log.Info("AutoConnect.NewVideoStream " + gststring);
                    GStreamer.gstlaunch = GStreamer.LookForGstreamer();

                    if (!File.Exists(GStreamer.gstlaunch))
                    {
                        if (CustomMessageBox.Show(
                                "A video stream has been detected, but gstreamer has not been configured/installed.\nDo you want to install/config it now?",
                                "GStreamer", System.Windows.Forms.MessageBoxButtons.YesNo) ==
                            (int)System.Windows.Forms.DialogResult.Yes)
                        {
                            {
                                ProgressReporterDialogue prd = new ProgressReporterDialogue();
                                ThemeManager.ApplyThemeTo(prd);
                                prd.DoWork += sender2 =>
                                {
                                    GStreamer.DownloadGStreamer(((i, s) =>
                                    {
                                        prd.UpdateProgressAndStatus(i, s);
                                        if (prd.doWorkArgs.CancelRequested) throw new Exception("User Request");
                                    }));
                                };
                                prd.RunBackgroundOperationAsync();

                                GStreamer.gstlaunch = GStreamer.LookForGstreamer();
                            }
                            if (!File.Exists(GStreamer.gstlaunch))
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    GStreamer.StartA(gststring);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            };
            AutoConnect.Start();

            BinaryLog.onFlightMode += (firmware, modeno) =>
            {
                try
                {
                    if (firmware == "")
                        return null;

                    var modes = ArduPilot.Common.getModesList((Firmwares)Enum.Parse(typeof(Firmwares), firmware));
                    string currentmode = null;

                    foreach (var mode in modes)
                    {
                        if (mode.Key == modeno)
                        {
                            currentmode = mode.Value;
                            break;
                        }
                    }

                    return currentmode;
                }
                catch
                {
                    return null;
                }
            };
            /*
            GStreamer.onNewImage += (sender, image) =>
            {
                if (image == null)
                {
                    GCSViews.FlightData.myhud.bgimage = null;
                    return;
                }

                if (!(image is Drawing::System.Drawing.Bitmap bmp))
                    return;
                var old = GCSViews.FlightData.myhud.bgimage;
                GCSViews.FlightData.myhud.bgimage = new Bitmap(image.Width, image.Height, 4 * image.Width,
                    PixelFormat.Format32bppPArgb,
                    bmp.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888)
                    .Scan0);
                if (old != null)
                    old.Dispose();
            };

            vlcrender.onNewImage += (sender, image) =>
            {
                if (image == null)
                {
                    GCSViews.FlightData.myhud.bgimage = null;
                    return;
                }
                if (!(image is Drawing::System.Drawing.Bitmap bmp))
                    return;
                var old = GCSViews.FlightData.myhud.bgimage;
                GCSViews.FlightData.myhud.bgimage = new Bitmap(image.Width,
                                                               image.Height,
                                                               4 * image.Width,
                                                               PixelFormat.Format32bppPArgb,
                                                               bmp.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888).Scan0);
                if (old != null)
                    old.Dispose();
            };

            CaptureMJPEG.onNewImage += (sender, image) =>
            {
                if (image == null)
                {
                    GCSViews.FlightData.myhud.bgimage = null;
                    return;
                }
                if (!(image is Drawing::System.Drawing.Bitmap bmp))
                    return;
                var old = GCSViews.FlightData.myhud.bgimage;
                GCSViews.FlightData.myhud.bgimage = new Bitmap(image.Width, image.Height, 4 * image.Width,
                                                               PixelFormat.Format32bppPArgb,
                                                               bmp.LockBits(Rectangle.Empty, null, SKColorType.Bgra8888).Scan0);
                if (old != null)
                    old.Dispose();
            };
            */
            try
            {
                ZeroConf.EnumerateAllServicesFromAllHosts().ContinueWith(a => ZeroConf.ProbeForRTSP());
            }
            catch
            {
            }

            CommsSerialScan.doConnect += port =>
            {
                if (MainV2.instance.InvokeRequired)
                {
                    log.Info("CommsSerialScan.doConnect invoke");
                    MainV2.instance.BeginInvoke(
                        (Action)delegate ()
                       {
                           MAVLinkInterface mav = new MAVLinkInterface();
                           mav.BaseStream = port;
                           MainV2.instance.DoConnect(mav, "preset", "0");
                           MainV2.Comports.Add(mav);
                       });
                }
                else
                {

                    log.Info("CommsSerialScan.doConnect NO invoke");
                    MAVLinkInterface mav = new MAVLinkInterface();
                    mav.BaseStream = port;
                    MainV2.instance.DoConnect(mav, "preset", "0");
                    MainV2.Comports.Add(mav);
                }
            };

            try
            {
                if (!MONO)
                {
                    log.Info("Load AltitudeAngel");
                    AltitudeAngel.Configure();
                    AltitudeAngel.Initialize();
                    log.Info("Load AltitudeAngel... Done");
                }
            }
            catch (TypeInitializationException) // windows xp lacking patch level
            {
                //CustomMessageBox.Show("Please update your .net version. kb2468871");
            }
            catch (Exception ex)
            {
                Tracking.AddException(ex);
            }

            this.ResumeLayout();

            Program.Splash?.Close();

            log.Info("appload time");
            MissionPlanner.Utilities.Tracking.AddTiming("AppLoad", "Load Time",
                (DateTime.Now - Program.starttime).TotalMilliseconds, "");

            // play a tlog that was passed to the program/ load a bin log passed
            if (Program.args.Length > 0)
            {
                var cmds = ProcessCommandLine(Program.args);

                if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) && cmds["file"].ToLower().EndsWith(".tlog"))
                {
                   // FlightData.LoadLogFile(Program.args[0]);
                  //  FlightData.BUT_playlog_Click(null, null);
                }
                else if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) &&
                         (cmds["file"].ToLower().EndsWith(".log") || cmds["file"].ToLower().EndsWith(".bin")))
                {
                    LogBrowse logbrowse = new LogBrowse();
                    ThemeManager.ApplyThemeTo(logbrowse);
                    logbrowse.logfilename = Program.args[0];
                    logbrowse.Show(this);
                    logbrowse.BringToFront();
                }

                if (cmds.ContainsKey("script") && File.Exists(cmds["script"]))
                {
                    // invoke for after onload finished
                    this.BeginInvoke((Action)delegate ()
                   {
                       try
                       {
                         //  FlightData.selectedscript = cmds["script"];

                        //   FlightData.BUT_run_script_Click(null, null);
                       }
                       catch (Exception ex)
                       {
                           CustomMessageBox.Show("Start script failed: " + ex.ToString(), Strings.ERROR);
                       }
                   });
                }
                
                if (cmds.ContainsKey("joy") && cmds.ContainsKey("type"))
                {
                    if (cmds["type"].ToLower() == "plane")
                    {
                        MainV2.ComPort.MAV.cs.firmware = Firmwares.ArduPlane;
                    }
                    else if (cmds["type"].ToLower() == "copter")
                    {
                        MainV2.ComPort.MAV.cs.firmware = Firmwares.ArduCopter2;
                    }
                    else if (cmds["type"].ToLower() == "rover")
                    {
                        MainV2.ComPort.MAV.cs.firmware = Firmwares.ArduRover;
                    }
                    else if (cmds["type"].ToLower() == "sub")
                    {
                        MainV2.ComPort.MAV.cs.firmware = Firmwares.ArduSub;
                    }

                    var joy = new Joystick.Joystick(() => MainV2.ComPort);

                    if (joy.start(cmds["joy"]))
                    {
                        MainV2.Joystick = joy;
                        MainV2.Joystick.enabled = true;
                    }
                    else
                    {
                        CustomMessageBox.Show("Failed to start joystick");
                    }
                }

                if (cmds.ContainsKey("rtk"))
                {
                    var inject = new ConfigSerialInjectGPS();
                    if (cmds["rtk"].ToLower().Contains("http"))
                    {
                        inject.CMB_serialport.Text = "NTRIP";
                        var nt = new CommsNTRIP();
                        ConfigSerialInjectGPS.comPort = nt;
                        Task.Run(() =>
                        {
                            try
                            {
                                nt.Open(cmds["rtk"]);
                                nt.lat = MainV2.ComPort.MAV.cs.PlannedHomeLocation.Lat;
                                nt.lng = MainV2.ComPort.MAV.cs.PlannedHomeLocation.Lng;
                                nt.alt = MainV2.ComPort.MAV.cs.PlannedHomeLocation.Alt;
                                this.BeginInvokeIfRequired(() => { inject.DoConnect(); });
                            }
                            catch (Exception ex)
                            {
                                this.BeginInvokeIfRequired(() => { CustomMessageBox.Show(ex.ToString()); });
                            }
                        });
                    }
                }

                if (cmds.ContainsKey("cam"))
                {
                    try
                    {
                        MainV2.Cam = new WebCamService.Capture(int.Parse(cmds["cam"]), null);

                        MainV2.Cam.Start();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(ex.ToString());
                    }
                }

                if (cmds.ContainsKey("gstream"))
                {
                    GStreamer.gstlaunch = GStreamer.LookForGstreamer();

                    if (!File.Exists(GStreamer.gstlaunch))
                    {
                        if (CustomMessageBox.Show(
                                "A video stream has been detected, but gstreamer has not been configured/installed.\nDo you want to install/config it now?",
                                "GStreamer", System.Windows.Forms.MessageBoxButtons.YesNo) ==
                            (int)System.Windows.Forms.DialogResult.Yes)
                        {
                            GStreamerUI.DownloadGStreamer();
                        }
                    }

                    try
                    {
                        new Thread(delegate ()
                        {
                            // 36 retrys
                            for (int i = 0; i < 36; i++)
                            {
                                try
                                {
                                    var st = GStreamer.StartA(cmds["gstream"]);
                                    if (st == null)
                                    {
                                        // prevent spam
                                        Thread.Sleep(5000);
                                    }
                                    else
                                    {
                                        while (st.IsAlive)
                                        {
                                            Thread.Sleep(1000);
                                        }
                                    }
                                }
                                catch (BadImageFormatException ex)
                                {
                                    // not running on x64
                                    log.Error(ex);
                                    return;
                                }
                                catch (DllNotFoundException ex)
                                {
                                    // missing or failed download
                                    log.Error(ex);
                                    return;
                                }
                            }
                        })
                        { 
                            IsBackground = true, Name = "Gstreamer cli" 
                        }.Start();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }

                if (cmds.ContainsKey("port") && cmds.ContainsKey("baud"))
                {
                    _connectionControl.CMB_serialport.Text = cmds["port"];
                    _connectionControl.CMB_baudrate.Text = cmds["baud"];

                    DoConnect(MainV2.ComPort, cmds["port"], cmds["baud"]);
                }
            }

            status1.Hide( );
            
            GMapMarkerBase.length = Settings.Instance.GetInt32("GMapMarkerBase_length", 500);
            GMapMarkerBase.DisplayCOG = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayCOG", true);
            GMapMarkerBase.DisplayHeading = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayHeading", true);
            GMapMarkerBase.DisplayNavBearing = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayNavBearing", true);
            GMapMarkerBase.DisplayRadius = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayRadius", true);
            GMapMarkerBase.DisplayTarget = Settings.Instance.GetBoolean("GMapMarkerBase_DisplayTarget", true);
            
            MyView.ShowScreen( "FlightPlanner" );

            joystickSetup = new JoystickSetup( );

            if ( Configurator.Setting.General.CheckAlternateAirfields )
            {
                if ( FlightPlanner.MainMap.Overlays.Where( a => a.Id == "rally" ).Count( ) == 0 )
                {
                    joystickSetup.BUT_enable_Click( this, new EventArgs( ) );
                }
            }

            FlightPlanner.MainMap.Zoom = STARTED_MAP_ZOOM;

            GetLocalMeasure( );

            ShowConnectDialog( );

            FlightPlanner.pFlightCalculation.Top = MainV2.instance.tabMenuView.Height;

            _shotThread = new ShotThread( );
            _shotThread.Start( );
        }

        JoystickSetup joystickSetup;

        private void JoystickActivate ( )
        {
            if ( joystickSetup.BUT_enable.Text == "Enable" )
            {
                joystickSetup.BUT_enable_Click( this, new EventArgs( ) );
            }
        }

        public void ShowConnectDialog ( )
        {
            if ( Configurator.Setting.General.CheckAlternateAirfields )
            {
                if ( FlightPlanner.MainMap.Overlays.Where( a => a.Id == "rally" ).Count( ) == 0 )
                {
                    joystickSetup.BUT_enable_Click( this, new EventArgs( ) );
                    JoystickActivate( );
                }
            }
            else 
            {
                JoystickActivate( );
            }

            var connectResult = new ConnectionView( ).ShowDialog( );
            tabMenuView.blackBoxTab.btnOpen.Enabled = true;

            switch ( connectResult )
            {
                case DialogResult.OK:
                    MainV2.instance.Connect( );

                    if ( IsConnected )
                    {
                        if ( Configurator.Setting.General.CheckAlternateAirfields )
                        {
                            if ( FlightPlanner.MainMap.Overlays.Where( a => a.Id == "rally" ).Count( ) == 0 )
                            {
                                if ( joystickSetup.BUT_enable.Text == "Enable" )
                                {
                                    joystickSetup.BUT_enable_Click( this, new EventArgs( ) );
                                }
                            }
                        }

                        Update( );

                        timer2.Start( );
                        btnDisconnect.Show( );
                        btnConnect.Hide( );
                        FlightPlanner.MainMap.Position = MainV2.ComPort.MAV.cs.Location;
                        
                        TabMenuEnabled( true );
                        tabMenuView.taskTab.btnArm.Enabled = true;

                        EnableMainButtons( true );
                        ConnectButtonEnabled( true );

                        if ( !FlightPlanner.Instance.timer1.Enabled )
                        {
                            FlightPlanner.Instance.timer1.Start();
                        }

                        SetCamera( GetCurrentCamera() );
                        
                        var findedValues = MainV2.ComPort.MAV.param.Where( p => p.Name == "RC16_MAX" || p.Name == "RC16_TRIM" );
                        var begPart = findedValues.Where( p => p.Name == "RC16_MAX" ).First( ).Value;
                        var endPart = findedValues.Where( p => p.Name == "RC16_TRIM" ).First( ).Value;

                        Configurator.Setting.General.AutoMode.UavId = $"{begPart}{endPart}";
                    }
                    else
                    {
                        ConnectButtonEnabled( false );
                    }
                    break;
                case DialogResult.No:
                    EnableMainButtons( false );
                    tabMenuView.taskTab.btnArm.Enabled = false;
                    ConnectButtonEnabled( false );

                    if ( !FlightPlanner.Instance.timer1.Enabled )
                    {
                        FlightPlanner.Instance.timer1.Start( );
                    }
                    break;
                default: // DialogResult.Cancel
                    TabMenuEnabled( false );
                    EnableMainButtons( false );
                    FlightPlanner.Instance.timer1.Stop( );
                    tabMenuView.blackBoxTab.btnOpen.Enabled = false;
                    break;
            }
            
            FlightPlanner.Commands.Enabled = false;

            UpdateAutoMode( Configurator.Setting.General.AutoMode );

            void TabMenuEnabled(bool enabled )
            {
                tabMenuView.btnTask.Enabled = enabled;
                tabMenuView.btnAirfields.Enabled = enabled;
                
                tabMenuView.taskTab.Enabled = enabled;
                tabMenuView.airfieldsTab.Enabled = enabled;
                
                tabMenuView.viewTab.btnHome.Enabled = enabled;
                tabMenuView.viewTab.btnUAV.Enabled = enabled;
                tabMenuView.viewTab.btnStartPlace.Enabled = enabled;

                tabMenuView.settingsTab.btnAccelerometer.Enabled = enabled;
                tabMenuView.settingsTab.btnAlignment.Enabled = enabled;
                tabMenuView.settingsTab.btnCompass.Enabled = enabled;
                tabMenuView.settingsTab.btnControl.Enabled = enabled;
                tabMenuView.settingsTab.btnESC.Enabled = enabled;
                tabMenuView.settingsTab.btnConfig.Enabled = enabled;
                tabMenuView.settingsTab.btnBattery.Enabled = enabled;
            }
        }

        private ECameras GetCurrentCamera ( )
        {
            try
            {
                switch ( MainV2.Joystick.State.ViewPoints[ 7 ] )
                {
                    case -32768: // УЗ
                        return ECameras.Aiming;
                    case 0: // ИК
                        return ECameras.Infrared;
                    default: // ШЗ
                        return ECameras.Wide;
                }
            }
            catch 
            {
                return ECameras.Wide;
            }
        }

        private void SetCamera ( ECameras cameras )
        {
            _selectCamera = cameras;
            var streamWorker = GlbContext.StreamWorker;

            switch ( cameras )
            {
                case ECameras.Infrared:
                    streamWorker.ShowRanges( );
                    streamWorker.SetCameraAngles( 0.29, 0.225 );
                    break;
                case ECameras.Aiming:
                    streamWorker.ShowRanges( );
                    streamWorker.SetCameraAngles( 0.45, 0.3 );
                    break;
                default:
                    streamWorker.HideRanges( );
                    break;
            }
        }

        private void BtnCalcOn_Click(object sender, EventArgs e)
        {
            if ( _isFlightCalcedLabelsShow )
            {
                _isFlightCalcedLabelsShow = false;
                FlightPlanner.pFlightCalculation.Hide( );
            }
            else
            {
                _isFlightCalcedLabelsShow = true;
                FlightPlanner.pFlightCalculation.Show( );
            }
        }

        public void LoadGDALImages(object nothing)
        {
            if (Settings.Instance.ContainsKey("GDALImageDir"))
            {
                try
                {
                    GDAL.GDAL.ScanDirectory(Settings.Instance["GDALImageDir"]);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
        }

        private Dictionary<string, string> ProcessCommandLine(string[] args)
        {
            Dictionary<string, string> cmdargs = new Dictionary<string, string>();
            string cmd = "";
            foreach (var s in args)
            {
                if (s.StartsWith("-") || s.StartsWith("/") || s.StartsWith("--"))
                {
                    cmd = s.TrimStart(new char[] { '-', '/', '-' }).TrimStart(new char[] { '-', '/', '-' });
                    continue;
                }
                if (cmd != "")
                {
                    cmdargs[cmd] = s;
                    log.Info("ProcessCommandLine: " + cmd + " = " + s);
                    cmd = "";
                    continue;
                }
                if (File.Exists(s))
                {
                    // we are not a command, and the file exists.
                    cmdargs["file"] = s;
                    log.Info("ProcessCommandLine: " + "file" + " = " + s);
                    continue;
                }

                log.Info("ProcessCommandLine: UnKnown = " + s);
            }

            return cmdargs;
        }

        private void BGFirmwareCheck(object state)
        {
            try
            {
                if (Settings.Instance["fw_check"] != DateTime.Now.ToShortDateString())
                {
                    var fw = new Firmware();
                    var list = fw.getFWList();
                    if (list.Count > 1)
                        Firmware.SaveSoftwares(new Firmware.optionsObject() { softwares = list });

                    Settings.Instance["fw_check"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGGetKIndex(object state)
        {
            try
            {
                // check the last kindex date
                if (Settings.Instance["kindexdate"] == DateTime.Now.ToShortDateString())
                {
                    KIndex_KIndex(Settings.Instance.GetInt32("kindex"), null);
                }
                else
                {
                    // get a new kindex
                    KIndex.KIndexEvent += KIndex_KIndex;
                    KIndex.GetKIndex();

                    Settings.Instance["kindexdate"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGgetTFR(object state)
        {
            try
            {
                tfr.tfrcache = Settings.GetUserDataDirectory() + "tfr.xml";
                tfr.GetTFRs();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGNoFly(object state)
        {
            try
            {
                NoFly.NoFly.Scan();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }


        void KIndex_KIndex(object sender, EventArgs e)
        {
            CurrentState.KIndexstatic = (int)sender;
            Settings.Instance["kindex"] = CurrentState.KIndexstatic.ToString();
        }

        private void BGCreateMaps(object state)
        {
            // sort logs
            try
            {
                MissionPlanner.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));

                MissionPlanner.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.rlog"));
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                // create maps
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog", SearchOption.AllDirectories));
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.bin", SearchOption.AllDirectories));
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.log", SearchOption.AllDirectories));

                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    Log.LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    Log.LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void MainV2_Resize(object sender, EventArgs e)
        {
            // mono - resize is called before the control is created
            if (MyView != null)
                log.Info("myview width " + MyView.Width + " height " + MyView.Height);

            log.Info("this   width " + this.Width + " height " + this.Height);
        }

        private void MenuHelp_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Help");
        }

        /// <summary>
        /// keyboard shortcuts override
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (GCSViews.ConfigTerminal.SSHTerminal) { return false; }
            if (keyData == Keys.F12)
            {
                MenuConnect_Click(null, null);
                return true;
            }

            if (keyData == Keys.F2)
            {
                MenuFlightData_Click(null, null);
                return true;
            }
            if (keyData == Keys.F3)
            {
                MenuFlightPlanner_Click(null, null);
                return true;
            }
            if (keyData == Keys.F4)
            {
                MenuTuning_Click(null, null);
                return true;
            }

            if (keyData == Keys.F5)
            {
                ComPort.getParamList();
                MyView.ShowScreen(MyView.current.Name);
                return true;
            }

            if (keyData == (Keys.Control | Keys.F)) // temp
            {
                Form frm = new temp();
                ThemeManager.ApplyThemeTo(frm);
                frm.Show();
                return true;
            }
            /*if (keyData == (Keys.Control | Keys.S)) // screenshot
            {
                ScreenShot();
                return true;
            }*/
            if (keyData == (Keys.Control | Keys.P))
            {
                new PluginUI().Show();
                return true;
            }
            
            if (keyData == (Keys.Control | Keys.G)) // nmea out
            {
                Form frm = new SerialOutputNMEA();
                ThemeManager.ApplyThemeTo(frm);
                frm.Show();
                return true;
            }
            if (keyData == (Keys.Control | Keys.X))
            {
                new GMAPCache().ShowUserControl();
                return true;
            }
            if (keyData == (Keys.Control | Keys.L)) // limits
            {
                new DigitalSkyUI().ShowUserControl();

                return true;
            }
            if (keyData == (Keys.Control | Keys.W)) // test ac config
            {
                new PropagationSettings().Show();

                return true;
            }
            if (keyData == (Keys.Control | Keys.Z))
            {
                //ScanHW.Scan(comPort);
                new Camera().test(MainV2.ComPort);
                return true;
            }
            if (keyData == (Keys.Control | Keys.T)) // for override connect
            {
                try
                {
                    MainV2.ComPort.Open(false);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(ex.ToString());
                }
                return true;
            }
            if (keyData == (Keys.Control | Keys.Y)) // for ryan beall and ollyw42
            {
                // write
                try
                {
                    MainV2.ComPort.doCommand((byte)MainV2.ComPort.sysidcurrent, (byte)MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.PREFLIGHT_STORAGE, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                }
                catch
                {
                    CustomMessageBox.Show("Invalid command");
                    return true;
                }
                //read
                ///////MainV2.comPort.doCommand(MAVLink09.MAV_CMD.PREFLIGHT_STORAGE, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                CustomMessageBox.Show("Done MAV_ACTION_STORAGE_WRITE");
                return true;
            }
            if (keyData == (Keys.Control | Keys.J))
            {
                new DevopsUI().ShowUserControl();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.A))
            {
                MenuAction_Click(this, new EventArgs());
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.C))
            {
                MenuConnect_Click(this, new EventArgs());
            }

            if (keyData == (Keys.Control | Keys.Enter))
            {
                FlightPlanner.btnCalc_Click(this, new EventArgs());
            }

            if (ProcessCmdKeyCallback != null)
            {
                return ProcessCmdKeyCallback(ref msg, keyData);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public delegate bool ProcessCmdKeyHandler(ref Message msg, Keys keyData);

        public event ProcessCmdKeyHandler ProcessCmdKeyCallback;

        public void Changelanguage(CultureInfo ci)
        {
            log.Info("change lang to " + ci.ToString() + " current " + Thread.CurrentThread.CurrentUICulture.ToString());

            if (ci != null && !Thread.CurrentThread.CurrentUICulture.Equals(ci))
            {
                Thread.CurrentThread.CurrentUICulture = ci;
                Settings.Instance["language"] = ci.Name;
                //System.Threading.Thread.CurrentThread.CurrentCulture = ci;

                HashSet<Control> views = new HashSet<Control> { this, FlightPlanner, Simulation };

                foreach (Control view in MyView.Controls)
                    views.Add(view);

                foreach (Control view in views)
                {
                    if (view != null)
                    {
                        ComponentResourceManager rm = new ComponentResourceManager(view.GetType());
                        foreach (Control ctrl in view.Controls)
                        {
                            rm.ApplyResource(ctrl);
                        }
                        rm.ApplyResources(view, "$this");
                    }
                }
            }
        }


        public void ChangeUnits()
        {
            try
            {
                // dist
                if (Settings.Instance["distunits"] != null)
                {
                    switch (
                        (distances)Enum.Parse(typeof(distances), Settings.Instance["distunits"].ToString()))
                    {
                        case distances.Meters:
                            CurrentState.multiplierdist = 1;
                            CurrentState.DistanceUnit = "m";
                            break;
                        case distances.Feet:
                            CurrentState.multiplierdist = 3.2808399f;
                            CurrentState.DistanceUnit = "ft";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierdist = 1;
                    CurrentState.DistanceUnit = "m";
                }

                // alt
                if (Settings.Instance["altunits"] != null)
                {
                    switch (
                        (distances)Enum.Parse(typeof(altitudes), Settings.Instance["altunits"].ToString()))
                    {
                        case distances.Meters:
                            CurrentState.multiplieralt = 1;
                            CurrentState.AltUnit = "m";
                            break;
                        case distances.Feet:
                            CurrentState.multiplieralt = 3.2808399f;
                            CurrentState.AltUnit = "ft";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplieralt = 1;
                    CurrentState.AltUnit = "m";
                }

                // speed
                if (Settings.Instance["speedunits"] != null)
                {
                    switch ((speeds)Enum.Parse(typeof(speeds), Settings.Instance["speedunits"].ToString()))
                    {
                        case speeds.meters_per_second:
                            CurrentState.multiplierspeed = 1;
                            CurrentState.SpeedUnit = "m/s";
                            break;
                        case speeds.fps:
                            CurrentState.multiplierspeed = 3.2808399f;
                            CurrentState.SpeedUnit = "fps";
                            break;
                        case speeds.kph:
                            CurrentState.multiplierspeed = 3.6f;
                            CurrentState.SpeedUnit = "kph";
                            break;
                        case speeds.mph:
                            CurrentState.multiplierspeed = 2.23693629f;
                            CurrentState.SpeedUnit = "mph";
                            break;
                        case speeds.knots:
                            CurrentState.multiplierspeed = 1.94384449f;
                            CurrentState.SpeedUnit = "kts";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierspeed = 1;
                    CurrentState.SpeedUnit = "m/s";
                }
            }
            catch
            {
            }
        }

        private void CMB_baudrate_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(_connectionControl.CMB_baudrate.Text, out comPortBaud))
            {
                CustomMessageBox.Show(Strings.InvalidBaudRate, Strings.ERROR);
                return;
            }
            var sb = new StringBuilder();
            int baud = 0;
            for (int i = 0; i < _connectionControl.CMB_baudrate.Text.Length; i++)
                if (char.IsDigit(_connectionControl.CMB_baudrate.Text[i]))
                {
                    sb.Append(_connectionControl.CMB_baudrate.Text[i]);
                    baud = baud * 10 + _connectionControl.CMB_baudrate.Text[i] - '0';
                }
            if (_connectionControl.CMB_baudrate.Text != sb.ToString())
            {
                _connectionControl.CMB_baudrate.Text = sb.ToString();
            }
            try
            {
                if (baud > 0 && ComPort.BaseStream.BaudRate != baud)
                    ComPort.BaseStream.BaudRate = baud;
            }
            catch (Exception)
            {
            }
        }

        private void MainMenu_MouseLeave(object sender, EventArgs e)
        {
            if (_connectionControl.PointToClient(Control.MousePosition).Y < MainMenu.Height)
                return;

            this.SuspendLayout();

            this.ResumeLayout();
        }

        void Menu_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.ResumeLayout();
        }

        void AutoHideMenu(bool hide)
        {
            if (!hide)
            {
                this.SuspendLayout();
                
                MainMenu.MouseLeave -= MainMenu_MouseLeave;
                toolStripConnectionControl.MouseLeave -= MainMenu_MouseLeave;
                this.ResumeLayout();
            }
            else
            {
                this.SuspendLayout();
                MainMenu.MouseLeave += MainMenu_MouseLeave;
                toolStripConnectionControl.MouseLeave += MainMenu_MouseLeave;
                this.ResumeLayout();
            }
        }

        private void MainV2_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyData == ( Keys.Control | Keys.M ) )
            {
                MenuInitConfig.Visible = !MenuInitConfig.Visible;
                MenuConfigTune.Visible = !MenuConfigTune.Visible;
                MenuSimulation.Visible = !MenuSimulation.Visible;
                MenuArduPilot.Visible = !MenuArduPilot.Visible;
                MenuHelp.Visible = !MenuHelp.Visible;
                toolStripConnectionControl.Visible = !toolStripConnectionControl.Visible;

                var isAdminMode = GlbContext.AppMode == EAppMode.admin;
                var adminText = isAdminMode ? "" : "[ Admin ] ";

                GlbContext.AppMode = isAdminMode ? EAppMode.user : EAppMode.admin;
                Text = "Mission planner " + adminText + FlightPlanner.flightTaskName;

                ForAppModeVisible( !isAdminMode );
            }

            Message temp = new Message();
            ProcessCmdKey(ref temp, e.KeyData);
            Console.WriteLine("MainV2_KeyDown " + e.ToString());
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(
                    "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=mich146%40hotmail%2ecom&lc=AU&item_name=Michael%20Oborne&no_note=0&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHostedGuest");
            }
            catch
            {
                CustomMessageBox.Show("Link open failed. check your default webpage association");
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class DEV_BROADCAST_HDR
        {
            internal Int32 dbch_size;
            internal Int32 dbch_devicetype;
            internal Int32 dbch_reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_PORT
        {
            public int dbcp_size;
            public int dbcp_devicetype;
            public int dbcp_reserved; // MSDN say "do not use"
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)] public byte[] dbcp_name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_DEVICEINTERFACE
        {
            public Int32 dbcc_size;
            public Int32 dbcc_devicetype;
            public Int32 dbcc_reserved;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
            internal Byte[]
                dbcc_classguid;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)] internal Byte[] dbcc_name;
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CREATE:
                    try
                    {
                        DEV_BROADCAST_DEVICEINTERFACE devBroadcastDeviceInterface = new DEV_BROADCAST_DEVICEINTERFACE();
                        IntPtr devBroadcastDeviceInterfaceBuffer;
                        IntPtr deviceNotificationHandle = IntPtr.Zero;
                        Int32 size = 0;

                        // frmMy is the form that will receive device-change messages.


                        size = Marshal.SizeOf(devBroadcastDeviceInterface);
                        devBroadcastDeviceInterface.dbcc_size = size;
                        devBroadcastDeviceInterface.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
                        devBroadcastDeviceInterface.dbcc_reserved = 0;
                        devBroadcastDeviceInterface.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE.ToByteArray();
                        devBroadcastDeviceInterfaceBuffer = Marshal.AllocHGlobal(size);
                        Marshal.StructureToPtr(devBroadcastDeviceInterface, devBroadcastDeviceInterfaceBuffer, true);


                        deviceNotificationHandle = NativeMethods.RegisterDeviceNotification(this.Handle, devBroadcastDeviceInterfaceBuffer, DEVICE_NOTIFY_WINDOW_HANDLE);
                    }
                    catch
                    {
                    }

                    break;

                case WM_DEVICECHANGE:
                    // The WParam value identifies what is occurring.
                    WM_DEVICECHANGE_enum n = (WM_DEVICECHANGE_enum)m.WParam;
                    var l = m.LParam;
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVEPENDING)
                    {
                        Console.WriteLine("DBT_DEVICEREMOVEPENDING");
                    }
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVNODES_CHANGED)
                    {
                        Console.WriteLine("DBT_DEVNODES_CHANGED");
                    }
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEARRIVAL ||
                        n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVECOMPLETE)
                    {
                        Console.WriteLine(((WM_DEVICECHANGE_enum)n).ToString());

                        DEV_BROADCAST_HDR hdr = new DEV_BROADCAST_HDR();
                        Marshal.PtrToStructure(m.LParam, hdr);

                        try
                        {
                            switch (hdr.dbch_devicetype)
                            {
                                case DBT_DEVTYP_DEVICEINTERFACE:
                                    DEV_BROADCAST_DEVICEINTERFACE inter = new DEV_BROADCAST_DEVICEINTERFACE();
                                    Marshal.PtrToStructure(m.LParam, inter);
                                    log.InfoFormat("Interface {0}",
                                        ASCIIEncoding.Unicode.GetString(inter.dbcc_name, 0, inter.dbcc_size - (4 * 3)));
                                    break;
                                case DBT_DEVTYP_PORT:
                                    DEV_BROADCAST_PORT prt = new DEV_BROADCAST_PORT();
                                    Marshal.PtrToStructure(m.LParam, prt);
                                    log.InfoFormat("port {0}",
                                        ASCIIEncoding.Unicode.GetString(prt.dbcp_name, 0, prt.dbcp_size - (4 * 3)));
                                    break;
                            }
                        }
                        catch
                        {
                        }

                        //string port = Marshal.PtrToStringAuto((IntPtr)((long)m.LParam + 12));
                        //Console.WriteLine("Added port {0}",port);
                    }
                    log.InfoFormat("Device Change {0} {1} {2}", m.Msg, (WM_DEVICECHANGE_enum)m.WParam, m.LParam);

                    if (DeviceChanged != null)
                    {
                        try
                        {
                            DeviceChanged((WM_DEVICECHANGE_enum)m.WParam);
                        }
                        catch
                        {
                        }
                    }

                    foreach (var item in MissionPlanner.Plugin.PluginLoader.Plugins)
                    {
                        item.Host.ProcessDeviceChanged((WM_DEVICECHANGE_enum)m.WParam);
                    }

                    break;
                case 0x86: // WM_NCACTIVATE
                    //var thing = Control.FromHandle(m.HWnd);

                    var child = Control.FromHandle(m.LParam);

                    if (child is Form)
                    {
                        log.Debug("ApplyThemeTo " + child.Name);
                        ThemeManager.ApplyThemeTo(child);
                    }
                    break;
                default:
                    //Console.WriteLine(m.ToString());
                    break;
            }
            base.WndProc(ref m);
        }

        const int DBT_DEVTYP_PORT = 0x00000003;
        const int WM_CREATE = 0x0001;
        const Int32 DBT_DEVTYP_DEVICEINTERFACE = 5;
        const Int32 DEVICE_NOTIFY_WINDOW_HANDLE = 0;
        const Int32 WM_DEVICECHANGE = 0X219;
        public static Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");


        public enum WM_DEVICECHANGE_enum
        {
            DBT_CONFIGCHANGECANCELED = 0x19,
            DBT_CONFIGCHANGED = 0x18,
            DBT_CUSTOMEVENT = 0x8006,
            DBT_DEVICEARRIVAL = 0x8000,
            DBT_DEVICEQUERYREMOVE = 0x8001,
            DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
            DBT_DEVICEREMOVECOMPLETE = 0x8004,
            DBT_DEVICEREMOVEPENDING = 0x8003,
            DBT_DEVICETYPESPECIFIC = 0x8005,
            DBT_DEVNODES_CHANGED = 0x7,
            DBT_QUERYCHANGECONFIG = 0x17,
            DBT_USERDEFINED = 0xFFFF,
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem item in MainMenu.Items)
            {
                if (e.ClickedItem == item)
                {
                    item.BackColor = ThemeManager.ControlBGColor;
                }
                else
                {
                    item.BackColor = Color.Transparent;
                    item.BackgroundImage = displayicons.Bg; //.BackColor = Color.Black;
                }
            }
            //MainMenu.BackColor = Color.Black;
            //MainMenu.BackgroundImage = MissionPlanner.Properties.Resources.bgdark;
        }

        private void FullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // full screen
            
                this.TopMost = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
        }

        private void ConnectionOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConnectionOptions().Show(this);
        }

        private void MenuArduPilot_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://ardupilot.org/?utm_source=Menu&utm_campaign=MP");
            }
            catch
            {
                CustomMessageBox.Show("Failed to open url https://ardupilot.org");
            }
        }

        private void ConnectionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if (File.Exists(openFileDialog.FileName))
            {
                var lines = File.ReadAllLines(openFileDialog.FileName);

                Regex tcp = new Regex("tcp://(.*):([0-9]+)");
                Regex udp = new Regex("udp://(.*):([0-9]+)");
                Regex udpcl = new Regex("udpcl://(.*):([0-9]+)");
                Regex serial = new Regex("serial:(.*):([0-9]+)");

                ConcurrentBag<MAVLinkInterface> mavs = new ConcurrentBag<MAVLinkInterface>();

                Parallel.ForEach(lines, line =>
                //foreach (var line in lines)
                {
                    try
                    {
                        MAVLinkInterface mav = new MAVLinkInterface();

                        if (tcp.IsMatch(line))
                        {
                            var matches = tcp.Match(line);
                            var tc = new TcpSerial();
                            tc.client = new TcpClient(matches.Groups[1].Value, int.Parse(matches.Groups[2].Value));
                            mav.BaseStream = tc;
                        }
                        else if (udp.IsMatch(line))
                        {
                            var matches = udp.Match(line);
                            var uc = new UdpSerial(new UdpClient(int.Parse(matches.Groups[2].Value)));
                            uc.Port = matches.Groups[2].Value;
                            mav.BaseStream = uc;
                        }
                        else if (udpcl.IsMatch(line))
                        {
                            var matches = udpcl.Match(line);
                            var udc = new UdpSerialConnect();
                            udc.Port = matches.Groups[2].Value;
                            udc.client = new UdpClient(matches.Groups[1].Value, int.Parse(matches.Groups[2].Value));
                            mav.BaseStream = udc;
                        }
                        else if (serial.IsMatch(line))
                        {
                            var matches = serial.Match(line);
                            var port = new Comms.SerialPort();
                            port.PortName = matches.Groups[1].Value;
                            port.BaudRate = int.Parse(matches.Groups[2].Value);
                            mav.BaseStream = port;
                            mav.BaseStream.Open();
                        }
                        else
                        {
                            return;
                        }

                        mavs.Add(mav);
                    }
                    catch
                    {
                    }
                }
                );

                foreach (var mav in mavs)
                {
                    MainV2.instance.BeginInvoke((Action)delegate
                    {
                        DoConnect(mav, "preset", "0", false);
                        Comports.Add(mav);
                    });
                }
            }
        }

        private int GbLanguageLeftCalc()
        {
            var gbLanguageLeft = 10;

            var lastItemIterationName = MenuHelp.Visible ? MenuHelp.Name : MenuFlightPlanner.Name;

            for (var i = 0; i < MainMenu.Items.Count; i++)
            {
                var item = MainMenu.Items[i];
                gbLanguageLeft += item.ContentRectangle.Left + item.ContentRectangle.Width;

                if (item.Name == lastItemIterationName)
                {
                    break;
                }
            }

            return gbLanguageLeft;
        }

        public void BtnDisconnect_Click( object sender, EventArgs e )
        {
            // decide if this is a connect or disconnect
            if ( ComPort.BaseStream.IsOpen )
            {
                DoDisconnect( ComPort );
            }

            if ( !IsConnected )
            {
                btnConnect.Show( );
                btnDisconnect.Hide( );

                EnableMainButtons( false );
            }
        }

        public void BtnConnect_Click( object sender, EventArgs e )
        {
            ShowConnectDialog( );
        }

        private void BtnHome_Click ( object sender, EventArgs e )
        {
            try
            {
                Locationwp gotoHome = new Locationwp( );

                gotoHome.id = ( ushort ) MAVLink.MAV_CMD.LAND;
                gotoHome.alt = 40;
                gotoHome.lat = ( float ) MainV2.ComPort.MAV.cs.HomeLocation.Lat;
                gotoHome.lng = ( float ) MainV2.ComPort.MAV.cs.HomeLocation.Lng;

                MainV2.ComPort.setGuidedModeWP( gotoHome );
            }
            catch ( Exception ex )
            {
                CustomMessageBox.Show( Strings.CommandFailed + ex.Message, Strings.ERROR );
            }
        }

        private void BtnAerodrome_Click( object sender, EventArgs e )
        {
            try
            {
                ( ( Control ) sender ).Enabled = false;

                var useStartPlace = Configurator.Setting.General.UseAlternateAirfieldStartPlace ? 1 : 0;
                MainV2.ComPort.setParam( "RALLY_INCL_HOME", useStartPlace );
                MainV2.ComPort.setMode( "RTL" );

                FlightPlanner.prop.Update( MainV2.ComPort.MAV.cs.TargetLocation, 10, ECircleItem.Select );
            }
            catch
            {
                CustomMessageBox.Show( Strings.CommandFailed, Strings.ERROR );
            }

            ( ( Control ) sender ).Enabled = true;
        }

        private void BtnTakeoff_Click( object sender, EventArgs e )
        {
            if ( MainV2.ComPort.BaseStream.IsOpen )
            {
                string alt = Settings.Instance[ "takeoff_alt", "5" ];

                if ( DialogResult.Cancel == InputBox.Show( "Enter Alt", "Enter Takeoff Alt", ref alt ) )
                    return;

                var altf = float.Parse( alt, CultureInfo.InvariantCulture );

                Settings.Instance[ "takeoff_alt" ] = altf.ToString( );
                MainV2.ComPort.setMode( "GUIDED" );

                try
                {
                    MainV2.ComPort.doCommand( ( byte ) MainV2.ComPort.sysidcurrent, ( byte ) MainV2.ComPort.compidcurrent,
                        MAVLink.MAV_CMD.TAKEOFF, 0, 0, 0, 0, 0, 0, altf );
                }
                catch
                {
                    CustomMessageBox.Show( Strings.CommandFailed, Strings.ERROR );
                }
            }
        }

        private void BtnLanding_Click( object sender, EventArgs e )
        {
            try
            {
                ( ( Control ) sender ).Enabled = false;
                MainV2.ComPort.setMode( "Land" );
            }
            catch
            {
                CustomMessageBox.Show( Strings.CommandFailed, Strings.ERROR );
            }

            ( ( Control ) sender ).Enabled = true;
        }

        private void ForAppModeVisible( bool isVisible )
        {
            tabMenuView.taskTab.btnMessages.Visible = isVisible;

            var settingTab = tabMenuView.settingsTab;
            settingTab.btnCompass.Visible = isVisible;
            settingTab.btnAccelerometer.Visible = isVisible;
            settingTab.btnESC.Visible = isVisible;
            settingTab.btnBattery.Visible = isVisible;
            settingTab.btnConfig.Visible = isVisible;
            settingTab.panelSplit2.Visible = isVisible;
        }

        private void MainV2_FormClosed ( object sender, FormClosedEventArgs e )
        {
            if ( IsConnected )
            {
                if ( ComPort.BaseStream.IsOpen )
                {
                    DoDisconnect( ComPort );
                }
            }

            if ( _lighting.LightingType == ELightingType.Flickering )
            {
                _lighting.IsOn = false;
                _lighting.Stop( );
            }

            hudThread?.Abort( );

            GlbContext.StreamWorker?.Dispose( );

            if ( _videoProces != null )
            {
                _videoProces.Close( );
                _videoProces.Dispose( );
            }

            if ( timer1.Enabled )
            {
                timer1.Stop( );
            }

            if ( timer2.Enabled )
            {
                timer2.Stop( );
            }

            if ( Joystick != null )
            {
                Joystick.Dispose( );
            }
        }

        PacketInspector<MAVLink.MAVLinkMessage> mavi = new PacketInspector<MAVLink.MAVLinkMessage>( );

        private int    _countPackages = 10;
        private double _windSpeedResult = 0, _windAzResult = 0;
        private double _avgWindSpeed = 0.0, _avgWindAngle = 0.0;

        private void HudFunc ( )
        {
            while ( IsConnected )
            {
                Thread.Sleep( 75 );
                Update( );
            }

            void Update( )
            {
                var streamWorker = GlbContext.StreamWorker;
                var cs = MainV2.ComPort.MAV.cs;

                lat = cs.lat;
                lon = cs.lng;
                yaw = cs.yaw;
                alt = cs.alt;
                _pitch = cs.pitch;

                if ( cs.armed )
                {
                    if ( !recordOnPicture.Visible )
                    {
                        recordOnPicture.Show( );
                        recordOnPicture.Update( );
                    }
                    
                    streamWorker.StartRecording( );
                }
                else
                {
                    if ( recordOnPicture.Visible )
                    {
                        recordOnPicture.Hide( );
                        recordOnPicture.Update( );
                    }

                    streamWorker.StopRecording( );
                }

                streamWorker.Update( EParam.DRONE_NAME, Configurator.Setting.General.AutoMode.UavId );
                streamWorker.Update( EParam.SATELLITES, cs.satcount.ToString( "0" ) );
                streamWorker.Update( EParam.SIGNAL_LEVEL, cs.linkqualitygcs.ToString( "0") );

                var gimbleAngle = GlbContext.Uav.Device.Gimble is null ? Configurator.Setting.General.AutoMode.GimbleAngle : (int) _gimbleAngle;

                streamWorker.Update( EParam.INCLINATION, gimbleAngle.ToString( "0" ) );
                streamWorker.Update( EParam.LATITUDE, lat.ToString( "0.######" ).Replace( ',', '.' ) ); 
                streamWorker.Update( EParam.LONGITUDE, lon.ToString( "0.######" ).Replace( ',', '.' ) );
                streamWorker.Update( EParam.AZIMUTH, yaw.ToString( "0.#" ) );
                streamWorker.Update( EParam.ALTITUDE_WRT_GROUND, cs.ter_curalt.ToString("0") + _measure.Distance );
                streamWorker.Update( EParam.ALTITUDE_WRT_HOME, alt.ToString("0" ) + _measure.Distance );
                streamWorker.Update( EParam.HORIZONTAL_SPEED, SpeedConvert( cs.groundspeed ) + _measure.Speed );
                streamWorker.Update( EParam.VERTICAL_SPEED, SpeedConvert( cs.verticalspeed) + _measure.Speed );
                streamWorker.Update( EParam.ROLL_ANGLE,  cs.roll.ToString( "0.#" ).Replace( ',', '.' ) );
                streamWorker.Update( EParam.PITCH_ANGLE, _pitch.ToString( "0.#" ) );
                streamWorker.Update( EParam.RANGE_1, 50.ToString( "0" ) );
                streamWorker.Update( EParam.RANGE_2, 100.ToString( "0" ) );
                
                var uavBattery = GlbContext.Uav.Device.Battery;
                var voltage = cs.battery_voltage;
                var remainingBatteryPercent = ( voltage < uavBattery.MaxConvertVoltage ) ? map( cs.battery_voltage, uavBattery.VoltageMin, uavBattery.VoltageMax ) : 1;
                var bankCount = cs.battery_voltage / (double) uavBattery.BankCount;

                streamWorker.Update( EParam.BATTERY_LEVEL, remainingBatteryPercent.ToString( ).Replace( ',', '.' ) );
                streamWorker.Update( EParam.BATTERY_VOLTAGE, cs.battery_voltage.ToString( "0.0" ).Replace( ',', '.' ) + _measure.Voltage + " | " + bankCount.ToString( "0.#" ).Replace( ',', '.' ) + _measure.Voltage );
                streamWorker.Update( EParam.BATTERY_CAPACITY, FlightPlanner.Instance.lblSpentBattery.Text.Replace( ',', '.' ) + _measure.Capacity );
                streamWorker.Update( EParam.BATTERY_TIME_LEFT, FlightPlanner.Instance.lblRemainingTime.Text.Replace( ',', '.' ) );
                streamWorker.Update( EParam.FLIGHT_PATH, cs.distTraveled.ToString( "0" ) + _measure.Distance );
                streamWorker.Update( EParam.FLIGHT_TIME, ( cs.timeInAir / 60 ).ToString( "0" ) + "." + ( cs.timeInAir % 60 ).ToString( "0" ) );
                // streamWorker.Update( EParam.TARGET_WIDTH, .ToString( "0.#" );
                // streamWorker.Update( EParam.TARGET_HEIGHT, .ToString( "0.#" );
                streamWorker.Update( EParam.FLIGHT_STATUS, FlightStatus( cs.mode ) );
                streamWorker.Update( EParam.FLIGHT_MODE, FlightMode( cs.mode ) );
                streamWorker.Update( EParam.TARGET_LATITUDE, _targetPoint.Lat.ToString( "0.######" ).Replace( ',', '.' ) );
                streamWorker.Update( EParam.TARGET_LONGITUDE, _targetPoint.Lng.ToString( "0.######" ).Replace( ',', '.' ) );

                //streamWorker.Visible( EParam.ARMING_STATUS, cs.armed );

                var windSpeed = _windSpeedResult;
                var windAzimuth = _windAzResult;

                HomeAngle( );

                if ( cs.groundspeed < 0.5 && cs.mode == "LOITER" && cs.armed )
                {
                    if ( _countPackages < 100 )
                    {
                        _countPackages++;
                    }

                    windSpeed = WindSpeed( );

                    //if ( cs.gpsvel_acc < 0.5 )
                    {
                        windAzimuth = WindAzimuth( );
                    }
                }

                streamWorker.Update( EParam.WIND_SPEED, windSpeed.ToString( "0.#" ).Replace( ',', '.' ) + _measure.Speed );
                streamWorker.Update( EParam.WIND_ANGLE, windAzimuth.ToString( "0" ) );

                string FlightModeTumbler ( )
                {
                    if ( MainV2.Joystick != null )
                    {
                        var buttons = MainV2.Joystick.State.Buttons;

                        if ( buttons[ 3 ] )
                        {
                            return _measure.FlightMode[ 0 ];
                        }

                        if ( buttons[ 4 ] )
                        {
                            return _measure.FlightMode[ 1 ];
                        }

                        if ( buttons[ 5 ] )
                        {
                            return _measure.FlightMode[ 0 ];
                        }
                    }

                    return "";
                }

                string SpeedConvert ( double speed )
                {
                    if ( Configurator.Setting.Interface.ESpeed == ESpeed.Km_h )
                    {
                        return SpeedConverter.ToKilometersPerHours( speed ).ToString( "0" );
                    }
                    else
                    {
                        return speed.ToString( "0" );
                    }
                }

                string FlightMode ( string flmode )
                {
                    switch ( flmode )
                    {
                        case "AltHold": return _measure.FlightMode[ 0 ];
                        case "Auto": return _measure.FlightMode[ 2 ];
                        case "Loiter": return _measure.FlightMode[ 1 ];
                        default: return _measure.FlightMode[ 2 ];
                    }
                }

                string FlightStatus ( string flmode )
                {
                    switch ( flmode )
                    {
                        case "RTL": return _measure.FlightStatus[ 0 ];
                        case "Guided": return _measure.FlightStatus[ 1 ];
                        case "Land": return _measure.FlightStatus[ 2 ];
                        case "Takeoff": return _measure.FlightStatus[ 3 ];
                        default: return "";
                    }
                }

                double map ( double x, double min, double max )
                {
                    return ( x - min ) / ( max - min );
                }

                double WindSpeed ( )
                {
                    var pitchDeg = DegToRad( cs.pitch );
                    var rollRad = DegToRad( cs.roll );
                    var windSpeedCoefficient = GlbContext.Uav.Device.Motor.WindSpeedCoefficient;
                    var value = Math.Sqrt( pitchDeg * pitchDeg + rollRad * rollRad ) * windSpeedCoefficient;

                    return _windSpeedResult = _avgWindSpeed = ( _avgWindSpeed * ( _countPackages - 1 ) + value ) / _countPackages;
                }

                double WindAzimuth ( )
                {
                    var pitchRad = DegToRad( cs.pitch );
                    var rollRad = DegToRad( cs.roll );
                    var value = Math.Atan2( rollRad, -pitchRad ) * 57.2;

                    _avgWindAngle = ( _avgWindAngle * ( _countPackages - 1 ) + value ) / _countPackages;

                    return _windAzResult = 180 + _avgWindAngle;
                }

                double DegToRad ( double angle ) => angle * Math.PI / 180;

                void HomeAngle ( )
                {
                    var scaleLongDown = Math.Cos( Math.Abs( cs.lat ) * 0.0174532925 );
                    var dstlat = ( cs.lat - cs.lat ) * 111319.5;
                    var dstlon = ( cs.lng - cs.lng ) * 111319.5 * scaleLongDown;
                    var bearing = Math.Atan2( dstlat, -dstlon ) * 57.295775; //absolute home direction

                    bearing -= cs.yaw;

                    if ( bearing < 0 ) bearing += 360;
                    if ( bearing > 360 ) bearing -= 360;
                    
                    var dist = cs.DistToHome;

                    streamWorker.Update( EParam.HOME_DISTANCE, dist.ToString( "0" ) + _measure.Distance );
                    streamWorker.Update( EParam.HOME_ANGLE, bearing.ToString( "0" ) );
                }
            }
        }

        public void UpdateAutoMode ( AutoMode autoMode )
        {
            var strAlt = autoMode.Height.ToString( );
            Settings.Instance[ "takeoff_alt" ] = strAlt;
            Settings.Instance[ "guided_alt" ] = strAlt;

            MainV2.ComPort.doCommandAsync( MainV2.ComPort.MAV.sysid, MainV2.ComPort.MAV.compid, MAVLink.MAV_CMD.DO_CHANGE_SPEED, 0, autoMode.Speed, 0, 0, 0, 0, 0 );
            FlightPlanner.TXT_loiterrad.Text = autoMode.PatrolRadius.ToString( );
        }

        private void MainV2_Paint ( object sender, PaintEventArgs e )
        {
            btnDisconnect.Left = Width - btnDisconnect.Width - 15;
        }

        private PointLatLngAlt _targetPoint = new PointLatLngAlt();

        private double GetGimblePitch()
        {
            //Угол наклона подвеса
            MainV2.ComPort.OnPacketReceived += ( o, linkMessage ) =>
            {
                mavi.Add( linkMessage.sysid, linkMessage.compid, linkMessage.msgid, linkMessage, linkMessage.Length );
            };

            var mavLinkMessages = mavi.GetPacketMessages( );
            var foundMessages = mavLinkMessages.Where( t => t.msgtypename == "ATTITUDE" && t.sysid == 3 );
            var pitch = 0.0;

            if ( foundMessages != null && foundMessages.Count( ) > 0 )
            {
                var message = foundMessages.First( );

                if ( message != null )
                {
                    var attitude = ( MAVLink.mavlink_attitude_t ) message.data;
                    pitch = attitude.pitch;
                }
            }

            return pitch;
        }

        private double _gimbleAngle;

        private double lat, lon, yaw, _pitch, alt;

        

        private void BtnNavigationLights_Click ( object sender, EventArgs e )
        {
            var navigationLights = new NavigationLights( _lighting );
            navigationLights.ShowDialog( );

            _lighting = navigationLights.Lighting;

            if ( _lighting.IsOn )
            {
                if ( _lighting.LightingType == ELightingType.Constant )
                {
                    btnNavigationLights.Image = Properties.Resources.LampOn;
                }
                else
                {
                    btnNavigationLights.Image = Properties.Resources.LampLight;
                }
            }
            else
            {  
                btnNavigationLights.Image = Properties.Resources.LampOff;
            }
        }

        private void BtnFlyPoint_Click ( object sender, EventArgs e )
        {
            if ( IsConnected )
            {
                FlightPlanner.IsFlyToPoint = true;
            }
        }

        private void MainV2_Load ( object sender, EventArgs e )
        {

        }

        private Color getEkfStatus ( ) 
        {
            var status = MainV2.ComPort.MAV.cs.ekfstatus;

            switch ( status )
            {
                case 0:
                    return Color.White;
                case 1:
                    return Color.Red;
                default:
                    return Color.White;
            }
        }

        private void lblGpsStatus_Click ( object sender, EventArgs e )
        {
            MainV2.Joystick.Gps = ( short ) ( MainV2.ComPort.MAV.cs.gpsstatus < 2 ? 1000 : 2000 );
        }

        private Color getTelemLvl () 
        {
            var value = MainV2.ComPort.MAV.cs.linkqualitygcs;
            Color color = new Color( );
            if ( value > 70 )
                color = Color.White;
            if ( value < 70 && value > 50 ) 
                color =  Color.Yellow;
            if ( value < 50 )
                color =  Color.Red;
            return color;
        }

        private void Timer2_Tick ( object sender, EventArgs e )
        {
            lblRSSI.Text = MainV2.ComPort.MAV.cs.linkqualitygcs.ToString( );
            lblRSSI.ForeColor = getTelemLvl( );
            lblEkfStatus.ForeColor = getEkfStatus();
            FlightPlanner.MainMap.Overlays[ 4 ].Markers.Clear( );
            FlightPlanner.routesoverlay.Markers.Clear( );

            var gimble = GlbContext.Uav.Device.Gimble;
            var gimbleAngle = Configurator.Setting.General.AutoMode.GimbleAngle * Math.PI / 180;
            var pitch = _gimbleAngle = gimble is null ? gimbleAngle : GetGimblePitch( );
            var targetDistance = alt / Math.Tan( Math.Abs(  _pitch * Math.PI / 180 - pitch ));
            var EARTH_RAD = 6371000;
            var azimuth = yaw;
            var targetLat = lat + targetDistance * Math.Cos( azimuth * Math.PI / 180 ) / ( EARTH_RAD * Math.PI / 180 );
            var targetLon = lon + targetDistance * Math.Sin( azimuth * Math.PI / 180 ) / Math.Cos( lat * Math.PI / 180 ) / ( EARTH_RAD * Math.PI / 180 );

            _targetPoint = new PointLatLng( targetLat, targetLon );

            var targetMarker = new GMarkerGoogle( _targetPoint, GMarkerGoogleType.target );
            var marker = Common.getMAVMarker( MainV2.ComPort.MAV );
            FlightPlanner.routesoverlay.Markers.Add( marker );

            FlightPlanner.MainMap.Overlays[ 4 ].Markers.Add( targetMarker );
        }

        private const float magic_force_arm_value = 2989.0f;
        private const float magic_force_disarm_value = 21196.0f;

        private bool isClick19, isClick18;

        private enum ECameras
        {
            Infrared,
            Wide,
            Aiming
        };

        private ECameras _selectCamera;

        private void Timer1_Tick ( object sender, EventArgs e )
        {
            if ( MainV2.ComPort.MAV.cs.gpsstatus < 2 )
            {
                lblGpsStatus.Text = "GPS : Off";
                lblGpsStatus.ForeColor = Color.Red;
            }
            else
            {
                lblGpsStatus.Text = "GPS : On";
                lblGpsStatus.ForeColor = Color.Lime;
            }

            if ( MainV2.ComPort.MAV.cs.armed )
            {
                tabMenuView.taskTab.btnDisarm.Show( );
                tabMenuView.taskTab.btnArm.Hide( );
            }
            else
            {
                tabMenuView.taskTab.btnArm.Show( );
                tabMenuView.taskTab.btnDisarm.Hide( );
            }

            try
            {
                if ( MainV2.Joystick != null )
                {
                    var buttons = MainV2.Joystick.State.Buttons;

                    var crossColor = ( buttons[ 7 ] || buttons[ 9 ] ) ? Color.Lime : Color.Yellow;

                    GlbContext.StreamWorker.ForegroundColor( EParam.CROSS_MARK, crossColor );

                    if ( buttons[ 19 ] && !isClick19 )
                    {
                        isClick18 = false;
                        MainV2.ComPort.doCommand( ( byte ) MainV2.ComPort.sysidcurrent, ( byte ) MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_RELAY, 1, 1, 0, 0, 0, 0, 0 );
                        isClick19 = true;
                    }

                    if ( buttons[ 18 ] && !isClick18 )
                    {
                        isClick19 = false;
                        MainV2.ComPort.doCommand( ( byte ) MainV2.ComPort.sysidcurrent, ( byte ) MainV2.ComPort.compidcurrent, MAVLink.MAV_CMD.DO_SET_RELAY, 1, 0, 0, 0, 0, 0, 0 );
                        isClick18 = true;
                    }

                    var streamWorker = GlbContext.StreamWorker;

                    if ( streamWorker != null )
                    {
                        var currentCamera = GetCurrentCamera( );

                        if ( _selectCamera != currentCamera )
                        {
                            SetCamera(currentCamera);
                        }
                    }
                }

                MainV2.ComPort.MAV.cs.messages.ForEach(
                    ( x ) =>
                    {
                        if ( x.message.IndexOf( "PreArm" ) > -1 )
                        {
                            //MessageBox.Show( x.message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                        }
                    }
                );
                
                if ( !MONO )
                {
                    timer1.Stop( );
                    return;
                }
                
                VirtualKeyboardInvocator.AddTextBoxClickListener( );
            }
            catch 
            { }
        }

        private ShotThread _shotThread;
    }
}