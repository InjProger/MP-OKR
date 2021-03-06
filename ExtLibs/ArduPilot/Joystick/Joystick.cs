using System;
using System.Collections.Generic;
using System.Collections;
using log4net;
using System.Reflection;
using System.IO;
using System.Threading;
using MissionPlanner.ArduPilot;
using MissionPlanner.Utilities;
using System.Linq;

using static SDL.Sdl;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SDL;
using SDL.Joysticks;

namespace MissionPlanner.Joystick
{
    public class Joystick : IDisposable
    {
        private const int DEFAUL_ID = 0;

        private static SDL.Joysticks.Joystick _joystick;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public bool enabled = false;
        public bool[] buttonpressed = new bool[128];
        public string name;
        public bool elevons = false;
        public bool manual_control = false;
        public short Gps { get; set; } = 1000;

        string joystickconfigbutton = "joystickbuttons.xml";
        string joystickconfigaxis = "joystickaxis.xml";

        public State State { get; set; }
        static public int Id { get; private set; }

        static public IntPtr Ptr { get; private set; }

        // set to default midpoint
        int hat1 = 65535/2;
        int hat2 = 65535/2;
        int custom0 = 65535/2;
        int custom1 = 65535/2;

        public struct JoyChannel
        {
            public int channel;
            public joystickaxis axis;
            public bool reverse;
            public int expo;
        }

        public int GetPressButtonIndex ( )
        {
            for ( var i = 0; i < buttonpressed.Length; i++ )
            {
                if ( buttonpressed[i] )
                {
                    return i;
                }
            }

            return -1;
        }

        public struct JoyButton
        {
            /// <summary>
            /// System button number
            /// </summary>
            public int buttonno;

            /// <summary>
            /// Fucntion we are doing for this button press
            /// </summary>
            public buttonfunction function;

            /// <summary>
            /// Mode we are changing to on button press
            /// </summary>
            public string mode;

            /// <summary>
            /// param 1
            /// </summary>
            public float p1;

            /// <summary>
            /// param 2
            /// </summary>
            public float p2;

            /// <summary>
            /// param 3
            /// </summary>
            public float p3;

            /// <summary>
            /// param 4
            /// </summary>
            public float p4;

            /// <summary>
            /// Relay state
            /// </summary>
            public bool state;
        }
        
        public enum buttonfunction
        {
            ChangeMode,
            Do_Set_Relay,
            Do_Repeat_Relay,
            Do_Set_Servo,
            Do_Repeat_Servo,
            Arm,
            Disarm,
            Digicam_Control,
            TakeOff,
            Mount_Mode,
            Toggle_Pan_Stab,
            Gimbal_pnt_track,
            Mount_Control_0,
            Button_axis0,
            Button_axis1,
        }

        public void Dispose()
        {
            _joystick.Dispose( );
            Dispose(true);
        }

        /// <summary>
        /// Implement reccomended best practice dispose pattern
        /// http://msdn.microsoft.com/en-us/library/b1yfkh5e%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="disposing"></param>
        virtual protected void Dispose(bool disposing)
        {
            //tell gc not to call finalize, this object will be GC'd quicker now.
            GC.SuppressFinalize(this);
        }

        //no need for finalizer...
        //~Joystick()
        //{
        //    Dispose(false);
        //}

        private Func<MAVLinkInterface> _Interface;

        private SynchronizationContext _context;

        private MAVLinkInterface Interface
        {
            get { return _Interface(); }
        }

        private static IntPtr GetJoyPtr ( int id = DEFAUL_ID )
        {
            /* Инициализация SDL для использования джойстика */
            var result = SDL_Init( SDL_INIT_JOYSTICK );

            if ( result == -1 )
            {
                throw new Exception( "Error joystick connection" );
            }
            
            SDL_JoystickEventState( SDL_ENABLE ); // включить джойстик
            return SDL_JoystickOpen( id ); // открыть джойстик
        }

        private static void Close ( )
        {
            _joystick?.Dispose( );
        }

        static Joystick ( )
        {
            _joystick = new SDL.Joysticks.Joystick( 0 );
        }

        public Joystick ( int id = 0 )
        {
            _joystick = new SDL.Joysticks.Joystick( id );
        }

        public Joystick(string name )
        {
            _joystick = new SDL.Joysticks.Joystick( name );
        }

        public Joystick(Func<MAVLinkInterface> currentInterface)
        {
            this._Interface = currentInterface;
            this._context = SynchronizationContext.Current;

            if ( _context == null )
            {
                _context = new SynchronizationContext( );
            }

            for ( int a = 0; a < JoyButtons.Length; a++ )
                JoyButtons[ a ].buttonno = -1;

            if ( currentInterface( ) == null )
                return;

            if ( Interface.MAV.cs.firmware == Firmwares.ArduPlane )
            {
                loadconfig( "joystickbuttons" + Interface.MAV.cs.firmware + ".xml",
                    "joystickaxis" + Interface.MAV.cs.firmware + ".xml" );
            }
            else if ( Interface.MAV.cs.firmware == Firmwares.ArduCopter2 )
            {
                loadconfig( "joystickbuttons" + Interface.MAV.cs.firmware + ".xml",
                    "joystickaxis" + Interface.MAV.cs.firmware + ".xml" );
            }
            else if ( Interface.MAV.cs.firmware == Firmwares.ArduRover )
            {
                loadconfig( "joystickbuttons" + Interface.MAV.cs.firmware + ".xml",
                    "joystickaxis" + Interface.MAV.cs.firmware + ".xml" );
            }
            else
            {
                loadconfig( );
            }
        }

        public void loadconfig(string joystickconfigbuttonin = "joystickbuttons.xml",
            string joystickconfigaxisin = "joystickaxis.xml")
        {
            log.Info("Loading joystick config files " + joystickconfigbuttonin + " " + joystickconfigaxisin);

            // save for later
            if (File.Exists(joystickconfigaxisin))
            {
                this.joystickconfigbutton = joystickconfigbuttonin;
                this.joystickconfigaxis = joystickconfigaxisin;
            }
            else
            {
                this.joystickconfigbutton = Settings.GetUserDataDirectory() + joystickconfigbuttonin;
                this.joystickconfigaxis = Settings.GetUserDataDirectory() + joystickconfigaxisin;
            }
            
            // load config
            if (File.Exists(this.joystickconfigbutton) && File.Exists(this.joystickconfigaxis))
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer reader =
                        new System.Xml.Serialization.XmlSerializer(typeof (JoyButton[]), new Type[] {typeof (JoyButton)});

                    using (StreamReader sr = new StreamReader(this.joystickconfigbutton))
                    {
                        JoyButtons = (JoyButton[]) reader.Deserialize(sr);
                    }
                }
                catch
                {
                }
                
                try
                {
                    System.Xml.Serialization.XmlSerializer reader =
                        new System.Xml.Serialization.XmlSerializer(typeof (JoyChannel[]),
                            new Type[] {typeof (JoyChannel)});

                    using (StreamReader sr = new StreamReader(this.joystickconfigaxis))
                    {
                        JoyChannels = (JoyChannel[]) reader.Deserialize(sr);
                    }
                }
                catch
                {
                }
            }
            
            Array.Resize(ref JoyChannels, 20);
        }

        public void saveconfig()
        {
            log.Info("Saving joystick config files " + joystickconfigbutton + " " + joystickconfigaxis);

            // save config
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof (JoyButton[]), new Type[] {typeof (JoyButton)});

            using (StreamWriter sw = new StreamWriter(joystickconfigbutton))
            {
                writer.Serialize(sw, JoyButtons);
            }

            writer = new System.Xml.Serialization.XmlSerializer(typeof (JoyChannel[]), new Type[] {typeof (JoyChannel)});

            using (StreamWriter sw = new StreamWriter(joystickconfigaxis))
            {
                writer.Serialize(sw, JoyChannels);
            }
        }

        JoyChannel[] JoyChannels = new JoyChannel[20]; // we are base 1

        public JoyButton[] JoyButtons { get; set; } = new JoyButton[ 128 ]; // base 0

        public bool start(string name)
        {
            this.name = name;
            
            enabled = true;
            
            System.Threading.Thread t11 = new System.Threading.Thread(new System.Threading.ThreadStart(mainloop))
            {
                Name = "Joystick loop",
                Priority = System.Threading.ThreadPriority.AboveNormal,
                IsBackground = true
            };

            t11.Start();

            return true;
        }

        public static joystickaxis getMovingAxis(string name, int threshold)
        {
            var state = _joystick.GetState();
            Hashtable values = new Hashtable();

            // get the state of the joystick before.
            Type type = state.GetType();
            PropertyInfo[] properties = type.GetProperties();
            
            foreach (PropertyInfo property in properties)
            {
                values[property.Name] = int.Parse(property.GetValue(state, null).ToString());
            }

            values["Slider1"] = state.Sliders[0];
            values["Slider2"] = state.Sliders[1];
            values["Hatud1"] = state.ViewPoints[0];
            values["Hatlr2"] = state.ViewPoints[0];
            values["Custom1"] = 0;
            values["Custom2"] = 0;

            CustomMessageBox.Show("Please move the joystick axis you want assigned to this function after clicking ok");

            DateTime start = DateTime.Now;
            
            while (start.AddSeconds(10) > DateTime.Now)
            {
                System.Threading.Thread.Sleep(50);
                var nextstate = _joystick.GetState();

                int[] slider = nextstate.Sliders;

                int[] hat1 = nextstate.ViewPoints;

                type = nextstate.GetType();
                properties = type.GetProperties();
                
                foreach (PropertyInfo property in properties)
                {
                    //Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null));

                    log.InfoFormat("test name {0} old {1} new {2} ", property.Name, values[property.Name],
                        int.Parse(property.GetValue(nextstate, null).ToString()));
                    log.InfoFormat("{0}  {1} {2}", property.Name, (int) values[property.Name],
                        (int.Parse(property.GetValue(nextstate, null).ToString()) + threshold));
                    if ((int) values[property.Name] >
                        (int.Parse(property.GetValue(nextstate, null).ToString()) + threshold) ||
                        (int) values[property.Name] <
                        (int.Parse(property.GetValue(nextstate, null).ToString()) - threshold))
                    {
                        log.Info(property.Name);
                        return (joystickaxis) Enum.Parse(typeof (joystickaxis), property.Name);
                    }
                }

                // slider1
                if ((int) values["Slider1"] > (slider[0] + threshold) ||
                    (int) values["Slider1"] < (slider[0] - threshold))
                {
                    return joystickaxis.Slider1;
                }

                // slider2
                if ((int) values["Slider2"] > (slider[1] + threshold) ||
                    (int) values["Slider2"] < (slider[1] - threshold))
                {
                    return joystickaxis.Slider2;
                }

                // Hatud1
                if ((int) values["Hatud1"] != (hat1[0]))
                {
                    return joystickaxis.Hatud1;
                }

                // Hatlr2
                if ((int) values["Hatlr2"] != (hat1[0]))
                {
                    return joystickaxis.Hatlr2;
                }
            }

            CustomMessageBox.Show("No valid option was detected");

            return joystickaxis.None;
        }
        
        private static IntPtr GetJoyIdByName (string name )
        {
            var intPtr = IntPtr.Zero;
            var joyCount = SDL_NumJoysticks( );

            for ( int id = 0; id < joyCount ; id++ )
            {
                intPtr = GetJoyPtr( id );

                if ( SDL_JoystickName( intPtr ) == name )
                {
                    return intPtr;
                }
            }

            return intPtr;
        }

        public static int getPressedButton(string name)
        {
            var joystick = new Joystick(name);

            if (joystick == null)
                return -1;

            //joystick.SetDataFormat(DeviceDataFormat.Joystick);

            var obj = _joystick.GetState( );

            var buttonsbefore = obj.Buttons;

            CustomMessageBox.Show("Please press the joystick button you want assigned to this function after clicking ok");

            DateTime start = DateTime.Now;

            while (start.AddSeconds(10) > DateTime.Now)
            {
                var nextstate = _joystick.GetState();
                var buttons = nextstate.Buttons;
                var joyBtnCount = SDL_JoystickNumButtons( Ptr );

                for (int a = 0; a < joyBtnCount; a++)
                {
                    if (buttons[a] != buttonsbefore[a])
                        return a;
                }
            }

            CustomMessageBox.Show("No valid option was detected");

            return -1;
        }

        public void setReverse(int channel, bool reverse)
        {
            JoyChannels[channel].reverse = reverse;
        }

        public void setAxis(int channel, joystickaxis axis)
        {
            JoyChannels[channel].axis = axis;
        }

        public void setChannel(int channel, joystickaxis axis, bool reverse, int expo)
        {
            JoyChannel joy = new JoyChannel();
            joy.axis = axis;
            joy.channel = channel;
            joy.expo = expo;
            joy.reverse = reverse;

            JoyChannels[channel] = joy;
        }

        public void setChannel(JoyChannel chan)
        {
            JoyChannels[chan.channel] = chan;
        }

        public JoyChannel getChannel(int channel)
        {
            return JoyChannels[channel];
        }

        public void setButton(int arrayoffset, JoyButton buttonconfig)
        {
            JoyButtons[arrayoffset] = buttonconfig;
        }

        public JoyButton getButton(int arrayoffset)
        {
            return JoyButtons[arrayoffset];
        }

        public void changeButton(int buttonid, int newid)
        {
            JoyButtons[buttonid].buttonno = newid;
        }

        public int getHatSwitchDirection()
        {
            return State.ViewPoints[0];
        }

        int BOOL_TO_SIGN(bool input)
        {
            if (input == true)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// Updates the rcoverride values and controls the mode changes
        /// </summary>
        void mainloop()
        {
            while (enabled)
            {
                try
                {
                    System.Threading.Thread.Sleep( 50 );

                    State = _joystick.GetState( );

                    //Console.WriteLine("JML " + _state);

                    if ( SDL_JoystickNumAxes( Ptr ) > 0 )
                    {
                        int pov = getHatSwitchDirection( );

                        if ( pov != -1 )
                        {
                            int angle = pov / 100;

                            //0 = down = 18000
                            //0 = up = 0

                            // 0
                            if ( angle > 270 || angle < 90 )
                                hat1 += 500;
                            // 180
                            if ( angle > 90 && angle < 270 )
                                hat1 -= 500;
                            // 90
                            if ( angle > 0 && angle < 180 )
                                hat2 += 500;
                            // 270
                            if ( angle > 180 && angle < 360 )
                                hat2 -= 500;
                        }
                    }

                    if ( elevons )
                    {
                        //g.channel_roll.set_pwm(BOOL_TO_SIGN(g.reverse_elevons) * (BOOL_TO_SIGN(g.reverse_ch2_elevon) * int(ch2_temp - elevon2_trim) - BOOL_TO_SIGN(g.reverse_ch1_elevon) * int(ch1_temp - elevon1_trim)) / 2 + 1500);
                        //g.channel_pitch.set_pwm(                                 (BOOL_TO_SIGN(g.reverse_ch2_elevon) * int(ch2_temp - elevon2_trim) + BOOL_TO_SIGN(g.reverse_ch1_elevon) * int(ch1_temp - elevon1_trim)) / 2 + 1500);
                        short roll = pickchannel( 1, JoyChannels[ 1 ].axis, false, JoyChannels[ 1 ].expo );
                        short pitch = pickchannel( 2, JoyChannels[ 2 ].axis, false, JoyChannels[ 2 ].expo );

                        if ( getJoystickAxis( 1 ) != Joystick.joystickaxis.None )
                            Interface.MAV.cs.rcoverridech1 = (short)
                             (BOOL_TO_SIGN(JoyChannels[1].reverse)*((int) (pitch - 1500) - (int) (roll - 1500))/2 +
                              1500);
                        if ( getJoystickAxis( 2 ) != Joystick.joystickaxis.None )
                            Interface.MAV.cs.rcoverridech2 = 
                        (short)
                            (BOOL_TO_SIGN(JoyChannels[2].reverse)*((int) (pitch - 1500) + (int) (roll - 1500))/2 +
                             1500);
                    }
                    else
                    {
                        if ( getJoystickAxis( 1 ) != Joystick.joystickaxis.None )
                            Interface.MAV.cs.rcoverridech1 = pickchannel(1, JoyChannels[1].axis,
                                JoyChannels[1].reverse, JoyChannels[1].expo);
                        //(ushort)(((int)state.Rz / 65.535) + 1000);
                        if ( getJoystickAxis( 2 ) != Joystick.joystickaxis.None )
                            Interface.MAV.cs.rcoverridech2 = pickchannel(2, JoyChannels[2].axis,
                                JoyChannels[2].reverse, JoyChannels[2].expo);
                                //(ushort)(((int)state.Y / 65.535) + 1000);
                    }
                    if ( getJoystickAxis( 3 ) != Joystick.joystickaxis.None )
                        Interface.MAV.cs.rcoverridech3 = pickchannel( 3, JoyChannels[ 3 ].axis, JoyChannels[ 3 ].reverse,
                            JoyChannels[ 3 ].expo ); //(ushort)(1000 - ((int)slider[0] / 65.535) + 1000);
                    if ( getJoystickAxis( 4 ) != Joystick.joystickaxis.None )
                        Interface.MAV.cs.rcoverridech4 = pickchannel( 4, JoyChannels[ 4 ].axis, JoyChannels[ 4 ].reverse,
                            JoyChannels[ 4 ].expo ); //(ushort)(((int)state.X / 65.535) + 1000);

                    if ( getJoystickAxis( 5 ) != Joystick.joystickaxis.None )
                        Interface.MAV.cs.rcoverridech5 = pickchannel( 5, JoyChannels[ 5 ].axis, JoyChannels[ 5 ].reverse,
                            JoyChannels[ 5 ].expo );
                    if ( getJoystickAxis( 6 ) != Joystick.joystickaxis.None )
                        Interface.MAV.cs.rcoverridech6 = pickchannel( 6, JoyChannels[ 6 ].axis, JoyChannels[ 6 ].reverse,
                            JoyChannels[ 6 ].expo );
                    if ( getJoystickAxis( 7 ) != Joystick.joystickaxis.None )
                        Interface.MAV.cs.rcoverridech7 = pickchannel( 7, JoyChannels[ 7 ].axis, JoyChannels[ 7 ].reverse,
                            JoyChannels[ 7 ].expo );
                    if ( getJoystickAxis( 8 ) != Joystick.joystickaxis.None )
                        Interface.MAV.cs.rcoverridech8 = pickchannel( 8, JoyChannels[ 8 ].axis, JoyChannels[ 8 ].reverse,
                            JoyChannels[ 8 ].expo );
                    
                    if ( getJoystickAxis( 9 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech9 = pickchannel( 9, JoyChannels[ 9 ].axis, JoyChannels[ 9 ].reverse, JoyChannels[ 9 ].expo );
                    if ( getJoystickAxis( 10 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech10 = Gps; //pickchannel( 10, JoyChannels[ 10 ].axis, JoyChannels[ 10 ].reverse, JoyChannels[ 10 ].expo );
                    if ( getJoystickAxis( 11 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech11 = pickchannel( 11, JoyChannels[ 11 ].axis, JoyChannels[ 11 ].reverse, JoyChannels[ 11 ].expo );
                    if ( getJoystickAxis( 12 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech12 = pickchannel( 12, JoyChannels[ 12 ].axis, JoyChannels[ 12 ].reverse, JoyChannels[ 12 ].expo );
                    if ( getJoystickAxis( 13 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech13 = pickchannel( 13, JoyChannels[ 13 ].axis, JoyChannels[ 13 ].reverse, JoyChannels[ 13 ].expo );
                    if ( getJoystickAxis( 14 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech14 = pickchannel( 14, JoyChannels[ 14 ].axis, JoyChannels[ 14 ].reverse, JoyChannels[ 14 ].expo );
                    if ( getJoystickAxis( 15 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech15 = pickchannel( 15, JoyChannels[ 15 ].axis, JoyChannels[ 15 ].reverse, JoyChannels[ 15 ].expo );
                    if ( getJoystickAxis( 16 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech16 = pickchannel( 16, JoyChannels[ 16 ].axis, JoyChannels[ 16 ].reverse, JoyChannels[ 16 ].expo );
                    if ( getJoystickAxis( 17 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech17 = pickchannel( 17, JoyChannels[ 17 ].axis, JoyChannels[ 17 ].reverse, JoyChannels[ 17 ].expo );
                    if ( getJoystickAxis( 18 ) != Joystick.joystickaxis.None ) Interface.MAV.cs.rcoverridech18 = pickchannel( 18, JoyChannels[ 18 ].axis, JoyChannels[ 18 ].reverse, JoyChannels[ 18 ].expo );

                    // disable button actions when not connected.
                    if ( Interface.BaseStream.IsOpen )
                        DoJoystickButtonFunction( );

                    //Console.WriteLine("{0} {1} {2} {3}", Interface.MAV.cs.rcoverridech1, Interface.MAV.cs.rcoverridech2, Interface.MAV.cs.rcoverridech3, Interface.MAV.cs.rcoverridech4);
                }
                catch (Exception ex)
                {
                    log.Info("Joystick thread error " + ex.ToString());
                } // so we cant fall out
            }
        }

        public void clearRCOverride()
        {
            // disable it, before continuing
            enabled = false;

            MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();

            rc.target_component = Interface.MAV.compid;
            rc.target_system = Interface.MAV.sysid;

            rc.chan1_raw = 0;
            rc.chan2_raw = 0;
            rc.chan3_raw = 0;
            rc.chan4_raw = 0;
            rc.chan5_raw = 0;
            rc.chan6_raw = 0;
            rc.chan7_raw = 0;
            rc.chan8_raw = 0;
            rc.chan9_raw = 0;
            rc.chan10_raw = 0;
            rc.chan11_raw = 0;
            rc.chan12_raw = 0;
            rc.chan13_raw = 0;
            rc.chan14_raw = 0;
            rc.chan15_raw = 0;
            rc.chan16_raw = 0;
            rc.chan17_raw = 0;
            rc.chan18_raw = 0;

            Interface.MAV.cs.rcoverridech1 = 0;
            Interface.MAV.cs.rcoverridech2 = 0;
            Interface.MAV.cs.rcoverridech3 = 0;
            Interface.MAV.cs.rcoverridech4 = 0;
            Interface.MAV.cs.rcoverridech5 = 0;
            Interface.MAV.cs.rcoverridech6 = 0;
            Interface.MAV.cs.rcoverridech7 = 0;
            Interface.MAV.cs.rcoverridech8 = 0;
            Interface.MAV.cs.rcoverridech9 = 0;
            Interface.MAV.cs.rcoverridech10 = 0;
            Interface.MAV.cs.rcoverridech11 = 0;
            Interface.MAV.cs.rcoverridech12 = 0;
            Interface.MAV.cs.rcoverridech13 = 0;
            Interface.MAV.cs.rcoverridech14 = 0;
            Interface.MAV.cs.rcoverridech15 = 0;
            Interface.MAV.cs.rcoverridech16 = 0;
            Interface.MAV.cs.rcoverridech17 = 0;
            Interface.MAV.cs.rcoverridech18 = 0;

            try
            {
                Interface.sendPacket(rc, rc.target_system, rc.target_component);
                System.Threading.Thread.Sleep(20);
                Interface.sendPacket(rc, rc.target_system, rc.target_component);
                System.Threading.Thread.Sleep(20);
                Interface.sendPacket(rc, rc.target_system, rc.target_component);
                System.Threading.Thread.Sleep(20);
                Interface.sendPacket(rc, rc.target_system, rc.target_component);
                System.Threading.Thread.Sleep(20);
                Interface.sendPacket(rc, rc.target_system, rc.target_component);
                System.Threading.Thread.Sleep(20);
                Interface.sendPacket(rc, rc.target_system, rc.target_component);

                Interface.sendPacket(rc, rc.target_system, rc.target_component);
                Interface.sendPacket(rc, rc.target_system, rc.target_component);
                Interface.sendPacket(rc, rc.target_system, rc.target_component);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void DoJoystickButtonFunction()
        {
            foreach (JoyButton but in JoyButtons)
            {
                if (but.buttonno != -1)
                {
                    getButtonState(but, but.buttonno);
                }
            }
        }

        void ProcessButtonEvent(JoyButton but, bool buttondown)
        {
            if (but.buttonno != -1)
            {
                // only do_set_relay and Button_axis0-1 uses the button up option
                if (buttondown == false)
                {
                    if (but.function != buttonfunction.Do_Set_Relay &&
                        but.function != buttonfunction.Button_axis0 &&
                        but.function != buttonfunction.Button_axis1)
                    {
                        return;
                    }
                }

                switch (but.function)
                {
                    case buttonfunction.ChangeMode:
                        string mode = but.mode;
                        if (mode != null)
                        {
                            _context.Send(delegate
                            {
                                try
                                {
                                    Interface.setMode(mode);
                                }
                                catch
                                {
                                    CustomMessageBox.Show("Failed to change Modes");
                                }
                            }, null);
                        }
                        break;
                    case buttonfunction.Mount_Mode:
                        _context.Send( delegate
                        {
                            try
                            {
                                Interface.setParam("MNT_MODE", but.p1);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to change mount mode");
                            }
                        }, null);

                        break;

                    case buttonfunction.Arm:
                        _context.Send( delegate
                        {
                            try
                            {
                                Interface.doARM(true);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to Arm");
                            }
                        }, null);
                        break;
                    case buttonfunction.TakeOff:
                        _context.Send( delegate
                        {
                            try
                            {
                                Interface.setMode("Guided");
                                if (Interface.MAV.cs.firmware == Firmwares.ArduCopter2)
                                {
                                    Interface.doCommand(MAVLink.MAV_CMD.TAKEOFF, 0, 0, 0, 0, 0, 0, 2);
                                }
                                else
                                {
                                    Interface.doCommand(MAVLink.MAV_CMD.TAKEOFF, 0, 0, 0, 0, 0, 0, 20);
                                }
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to takeoff");
                            }
                        }, null);
                        break;
                    case buttonfunction.Disarm:
                        _context.Send( delegate
                        {
                            try
                            {
                                Interface.doARM(false);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to Disarm");
                            }
                        }, null);
                        break;
                    case buttonfunction.Do_Set_Relay:
                        _context.Send( delegate
                        {
                            try
                            {
                                int number = (int) but.p1;
                                int state = buttondown == true ? 1 : 0;
                                Interface.doCommand(MAVLink.MAV_CMD.DO_SET_RELAY, number, state, 0, 0, 0, 0, 0);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to DO_SET_RELAY");
                            }
                        }, null);
                        break;
                    case buttonfunction.Digicam_Control:
                        Interface.setDigicamControl(true);
                        break;
                    case buttonfunction.Do_Repeat_Relay:
                        _context.Send( delegate
                        {
                            try
                            {
                                int relaynumber = (int) but.p1;
                                int repeat = (int) but.p2;
                                int time = (int) but.p3;
                                Interface.doCommand(MAVLink.MAV_CMD.DO_REPEAT_RELAY, relaynumber, repeat, time, 0,
                                    0, 0, 0);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to DO_REPEAT_RELAY");
                            }
                        }, null);
                        break;
                    case buttonfunction.Do_Set_Servo:
                        _context.Send( delegate
                        {
                            try
                            {
                                var channel = 0;
                                var pwm = 0;
                                channel = ( int ) but.p1;
                                pwm = ( int ) but.p2;

                                Interface.doCommand( MAVLink.MAV_CMD.DO_SET_SERVO, channel, pwm, 0, 0, 0, 0, 0 );
                            }
                            catch
                            {
                                CustomMessageBox.Show( "Failed to DO_SET_SERVO" );
                            }
                        }, null);
                        break;
                    case buttonfunction.Do_Repeat_Servo:
                        _context.Send( delegate
                        {
                            try
                            {
                                int channelno = (int) but.p1;
                                int pwmvalue = (int) but.p2;
                                int repeattime = (int) but.p3;
                                int delay_ms = (int) but.p4;
                                Interface.doCommand(MAVLink.MAV_CMD.DO_REPEAT_SERVO, channelno, pwmvalue,
                                    repeattime, delay_ms, 0, 0, 0);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to DO_REPEAT_SERVO");
                            }
                        }, null);
                        break;
                    case buttonfunction.Toggle_Pan_Stab:
                        _context.Send( delegate
                        {
                            try
                            {
                                float current = (float) Interface.MAV.param["MNT_STAB_PAN"];
                                float newvalue = (current > 0) ? 0 : 1;
                                Interface.setParam("MNT_STAB_PAN", newvalue);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to Toggle_Pan_Stab");
                            }
                        }, null);
                        break;
                    case buttonfunction.Gimbal_pnt_track:
                        _context.Send( delegate
                        {
                            try
                            {
                                Interface.doCommand(MAVLink.MAV_CMD.DO_SET_ROI, 0, 0, 0, 0,
                                    Interface.MAV.cs.gimballat, Interface.MAV.cs.gimballng,
                                    (float) Interface.MAV.cs.GimbalPoint.Alt);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to Gimbal_pnt_track");
                            }
                        }, null);
                        break;
                    case buttonfunction.Mount_Control_0:
                        _context.Send( delegate
                        {
                            try
                            {
                                Interface.setMountControl(0, 0, 0, false);
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to Mount_Control_0");
                            }
                        }, null);
                        break;
                    case buttonfunction.Button_axis0:
                        _context.Send( delegate
                        {
                            try
                            {
                                int pwmmin = (int) but.p1;
                                int pwmmax = (int) but.p2;

                                if (buttondown)
                                    custom0 = pwmmax;
                                else
                                    custom0 = pwmmin;
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to Button_axis0");
                            }
                        }, null);
                        break;
                    case buttonfunction.Button_axis1:
                        _context.Send( delegate
                        {
                            try
                            {
                                int pwmmin = (int) but.p1;
                                int pwmmax = (int) but.p2;

                                if (buttondown)
                                    custom1 = pwmmax;
                                else
                                    custom1 = pwmmin;
                            }
                            catch
                            {
                                CustomMessageBox.Show("Failed to Button_axis1");
                            }
                        }, null);
                        break;
                }
            }
        }

        public enum joystickaxis
        {
            None,
            Pass,
            ARx,
            ARy,
            ARz,
            AX,
            AY,
            AZ,
            FRx,
            FRy,
            FRz,
            FX,
            FY,
            FZ,
            Rx,
            Ry,
            Rz,
            VRx,
            VRy,
            VRz,
            VX,
            VY,
            VZ,
            X,
            Y,
            Z,
            Slider1,
            Slider2,
            Hatud1,
            Hatlr2,
            Custom1,
            Custom2
        }

        const int RESXu = 1024;
        const int RESXul = 1024;
        const int RESXl = 1024;
        const int RESKul = 100;

        /*
        ushort expou(ushort x, ushort k)
        {
          // k*x*x*x + (1-k)*x
          return ((ulong)x*x*x/0x10000*k/(RESXul*RESXul/0x10000) + (RESKul-k)*x+RESKul/2)/RESKul;
        }
        // expo-funktion:
        // ---------------
        // kmplot
        // f(x,k)=exp(ln(x)*k/10) ;P[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20]
        // f(x,k)=x*x*x*k/10 + x*(1-k/10) ;P[0,1,2,3,4,5,6,7,8,9,10]
        // f(x,k)=x*x*k/10 + x*(1-k/10) ;P[0,1,2,3,4,5,6,7,8,9,10]
        // f(x,k)=1+(x-1)*(x-1)*(x-1)*k/10 + (x-1)*(1-k/10) ;P[0,1,2,3,4,5,6,7,8,9,10]

        short expo(short x, short k)
        {
            if (k == 0) return x;
            short y;
            bool neg = x < 0;
            if (neg) x = -x;
            if (k < 0)
            {
                y = RESXu - expou((ushort)(RESXu - x), (ushort)-k);
            }
            else
            {
                y = expou((ushort)x, (ushort)k);
            }
            return neg ? -y : y;
        }
        */

        /// <summary>
        /// Button press check with debounce
        /// </summary>
        /// <param name="buttonno"></param>
        /// <returns></returns>
        bool getButtonState(JoyButton but, int buttonno)
        {
            var buts = State.Buttons;

            // button down
            bool ans = buts[buttonno] && !buttonpressed[buttonno]; // press check + debounce
            if (ans)
                ButtonDown(but);

            // button up
            ans = !buts[buttonno] && buttonpressed[buttonno];
            if (ans)
                ButtonUp(but);

            buttonpressed[buttonno] = buts[buttonno]; // set only this button

            return ans;
        }

        void ButtonDown(JoyButton but)
        {
            ProcessButtonEvent(but, true);
        }

        void ButtonUp(JoyButton but)
        {
            ProcessButtonEvent(but, false);
        }

        public int getNumButtons()
        {
            return _joystick?.JoystickState?.Buttons.Length ?? -1;
        }

        public joystickaxis getJoystickAxis(int channel)
        {
            try
            {
                return JoyChannels[channel].axis;
            }
            catch
            {
                return joystickaxis.None;
            }
        }

        public bool isButtonPressed(int buttonno)
        {
            if (State == null)
                return false;

            var buts = State.Buttons;

            if (buts == null || JoyButtons[buttonno].buttonno < 0)
                return false;

            return buts[JoyButtons[buttonno].buttonno];
        }

        public short getValueForChannel(int channel, string name)
        {
            if (Ptr == IntPtr.Zero)
                return 0;

            State = _joystick.GetState();

            short ans = pickchannel(channel, JoyChannels[channel].axis, JoyChannels[channel].reverse, JoyChannels[channel].expo);
            log.DebugFormat("{0} = {1} = {2}", channel, ans, State.X);
            return ans;
        }

        public short getRawValueForChannel(int channel)
        {
            if ( Ptr == IntPtr.Zero )
                return 0;

            State = _joystick.GetState();

            short ans = pickchannel(channel, JoyChannels[channel].axis, false, 0);
            log.DebugFormat("{0} = {1} = {2}", channel, ans, State.X);
            return ans;
        }

        short pickchannel(int chan, joystickaxis axis, bool rev, int expo)
        {
            int min, max, trim = 0;

            if (Interface.MAV.param.Count > 0)
            {
                try
                {
                    if (Interface.MAV.param.ContainsKey("RC" + chan + "_MIN"))
                    {
                        min = (int) (float) (Interface.MAV.param["RC" + chan + "_MIN"]);
                        max = (int) (float) (Interface.MAV.param["RC" + chan + "_MAX"]);
                        trim = (int) (float) (Interface.MAV.param["RC" + chan + "_TRIM"]);
                    }
                    else
                    {
                        min = 1000;
                        max = 2000;
                        trim = 1500;
                    }
                }
                catch
                {
                    min = 1000;
                    max = 2000;
                    trim = 1500;
                }
            }
            else
            {
                min = 1000;
                max = 2000;
                trim = 1500;
            }

            if (manual_control)
            {
                min = -1000;
                max = 1000;
                trim = 0;
            }

            if (chan == 3)
            {
                trim = (min + max)/2;
                // trim = min; // throttle
            }

            int range = Math.Abs(max - min);

            int working = 0;

            switch (axis)
            {
                case joystickaxis.None:
                    working = ushort.MaxValue/2;
                    break;
                case joystickaxis.Pass:
                    working = (int) (((float) (trim - min)/range)*ushort.MaxValue);
                    break;
                case joystickaxis.ARx:
                    working = State.AngularAccelerationX;
                    break;

                case joystickaxis.ARy:
                    working = State.AngularAccelerationY;
                    break;

                case joystickaxis.ARz:
                    working = State.AngularAccelerationZ;
                    break;

                case joystickaxis.AX:
                    working = State.AccelerationX;
                    break;

                case joystickaxis.AY:
                    working = State.AccelerationY;
                    break;

                case joystickaxis.AZ:
                    working = State.AccelerationZ;
                    break;

                case joystickaxis.FRx:
                    working = State.TorqueX;
                    break;

                case joystickaxis.FRy:
                    working = State.TorqueY;
                    break;

                case joystickaxis.FRz:
                    working = State.TorqueZ;
                    break;

                case joystickaxis.FX:
                    working = State.ForceX;
                    break;

                case joystickaxis.FY:
                    working = State.ForceY;
                    break;

                case joystickaxis.FZ:
                    working = State.ForceZ;
                    break;

                case joystickaxis.Rx:
                    working = State.RotationX;
                    break;

                case joystickaxis.Ry:
                    working = State.RotationY;
                    break;

                case joystickaxis.Rz:
                    working = State.RotationZ;
                    break;

                case joystickaxis.VRx:
                    working = State.AngularVelocityX;
                    break;

                case joystickaxis.VRy:
                    working = State.AngularVelocityY;
                    break;

                case joystickaxis.VRz:
                    working = State.AngularVelocityZ;
                    break;

                case joystickaxis.VX:
                    working = State.VelocityX;
                    break;

                case joystickaxis.VY:
                    working = State.VelocityY;
                    break;

                case joystickaxis.VZ:
                    working = State.VelocityZ;
                    break;

                case joystickaxis.X:
                    working = State.X;
                    break;

                case joystickaxis.Y:
                    working = State.Y;
                    break;

                case joystickaxis.Z:
                    working = State.Z;
                    break;

                case joystickaxis.Slider1:
                    int[] slider = State.Sliders;
                    working = slider[0];
                    break;

                case joystickaxis.Slider2:
                    int[] slider1 = State.Sliders;
                    working = slider1[1];
                    break;

                case joystickaxis.Hatud1:
                    hat1 = (int) Constrain(hat1, 0, 65535);
                    working = hat1;
                    break;

                case joystickaxis.Hatlr2:
                    hat2 = (int) Constrain(hat2, 0, 65535);
                    working = hat2;
                    break;

                case joystickaxis.Custom1:
                    working = (int)(((float)(custom0 - min) / range) * ushort.MaxValue);
                    working = (int)Constrain(working, 0, 65535);
                    break;

                case joystickaxis.Custom2:
                    working = (int)(((float)(custom1 - min) / range) * ushort.MaxValue);
                    working = (int)Constrain(working, 0, 65535);
                    break;
            }
            // between 0 and 65535 - convert to int -500 to 500
            working = (int)map(working, 0, 65535, -500, 500);

            if (rev)
                working *= -1;

            // save for later
            int raw = working;

            working = (int) Expo(working, expo, min, max, trim);

            //add limits to movement
            working = Math.Max(min, working);
            working = Math.Min(max, working);

            return (short) working;
        }

        public static double Expo(double input, double expo, double min, double max, double mid)
        {
            // input range -500 to 500

            double expomult = expo/100.0;

            if (input >= 0)
            {
                // linear scale
                double linearpwm = map(input, 0, 500, mid, max);
                double expomid = (max - mid)/2;
                double factor = 0;

                // over half way though input
                if (input > 250)
                {
                    factor = 250 - (input - 250);
                }
                else
                {
                    factor = input;
                }

                return linearpwm - (factor*expomult);
            }
            else
            {
                double linearpwm = map(input, -500, 0, min, mid);

                double expomid = (mid - min)/2;

                double factor = 0;

                // over half way though input
                if (input < -250)
                {
                    factor = -250 - (input + 250);
                }
                else
                {
                    factor = input;
                }

                return linearpwm - (factor*expomult);
            }
        }

        static double map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min)*(out_max - out_min)/(in_max - in_min) + out_min;
        }

        double Constrain(double value, double min, double max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }
    }
}