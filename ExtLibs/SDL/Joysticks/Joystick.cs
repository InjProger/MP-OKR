
using System;

using static SDL.Sdl;
using static SDL.Joysticks.JoystickWorker;

namespace SDL.Joysticks
{
    public class Joystick : IDisposable
    {
        private readonly IntPtr _joyPtr;

        public State JoystickState { get; private set; }
        public string Name => SDL_JoystickName( _joyPtr );

        public Joystick ( int id )
        {
            _joyPtr = GetJoystickValidation( GetJoyPtrById() );
        }

        public Joystick ( string name )
        {
            _joyPtr = GetJoystickValidation( GetJoyPtrByName( name ) );
        }

        private IntPtr GetJoystickValidation( IntPtr joyPtr )
        {
            if ( joyPtr == IntPtr.Zero )
            {
                throw new SdlException( "Joystick was not created: joyPtr is Zero" );
            }

            return joyPtr;
        }

        public State GetState ( )
        {
            return JoystickState = Update( _joyPtr );
        }

        public void Close ( )
        {
            SDL_JoystickClose( _joyPtr );
        }

        public void Dispose ( )
        {
            Close( );
        }
    }
}
