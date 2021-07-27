
using System;

using static SDL.Sdl;

namespace SDL.Joysticks
{
    public static class JoystickWorker
    {
        public const int DEFAUL_ID = 0;

        public static IntPtr GetJoyPtrById ( int id = DEFAUL_ID )
        {
            /* Инициализация */
            if ( SDL_Init( SDL_INIT_JOYSTICK ) < 0 )
            {
                throw new SdlException( "Not init joystick" );
            }

            SDL_JoystickEventState( SDL_ENABLE ); // включение
            return SDL_JoystickOpen( id );        // открытие
        }

        public static IntPtr GetJoyPtrByName ( string name )
        {
            GetJoyPtrById( );

            var joyPtr = IntPtr.Zero;
            var joyCount = SDL_NumJoysticks( );

            for ( var id = DEFAUL_ID; id < joyCount; id++ )
            {
                joyPtr = GetJoyPtrById( id );

                if ( joyPtr != IntPtr.Zero && SDL_JoystickName( joyPtr ) == name )
                {
                    return joyPtr;
                }

               // SDL_JoystickClose( joyPtr );
            }
            
            return joyPtr;
        }

        public static State Update( IntPtr joyPtr )
        {
            SDL_Event _sdlEvent;
            SDL_PollEvent ( out _sdlEvent );
            return StateUpdater.Update( joyPtr );
        }

        public static string[] GetJoyNames ( )
        {
            try
            {
                var joyCount = SDL_NumJoysticks( );
                var joyNames = new string[ joyCount ];

                for ( var id = DEFAUL_ID; id < joyCount; id++ )
                {
                    var joyPtr = GetJoyPtrById( id );
                    joyNames[ id ] = SDL_JoystickName( joyPtr );
                    // SDL_JoystickClose( joyPtr );
                }

                return joyNames;
            }
            catch
            {
                return null;
            }
        }
    }
}
