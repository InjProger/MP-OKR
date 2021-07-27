
using System;
using System.Linq;

using static SDL.Sdl;

namespace SDL.Joysticks
{
    public static class StateUpdater
    {
        private const int DELTA = 32768;

        private static T[] GetItems<T>( int itemCount, Func<int, T> ItemWorking )
        {
            var items = new T[ itemCount ];

            for ( var i = 0; i < itemCount; i++ )
            {
                items[ i ] = ItemWorking( i );
            }

            return items;
        }

        private static bool[] GetButtons( IntPtr joyPtr )
        {
            var buttonCount = SDL_JoystickNumButtons( joyPtr );
            return GetItems( buttonCount, ( i ) => SDL_JoystickGetButton( joyPtr, i ) == 1 );
        }

        private static int[] GetViewPoints ( IntPtr joyPtr )
        {
            var sliderCount = SDL_JoystickNumAxes( joyPtr );
            return GetItems( sliderCount, ( i ) => (int) SDL_JoystickGetAxis(joyPtr, i) );
        }

        private static int[] GetSliders ( IntPtr joyPtr )
        {
            var sliders = new int [5];

            sliders[ 0 ] = SDL_JoystickGetAxis( joyPtr, 7 ) + DELTA;
            sliders[ 1 ] = SDL_JoystickGetAxis( joyPtr, 6 ) + DELTA;

            return sliders;
        }

        public static State Update( IntPtr joyPtr )
        {
            return new State
            {
                X = SDL_JoystickGetAxis( joyPtr, 0 ) + DELTA,
                Y = SDL_JoystickGetAxis( joyPtr, 1 ) + DELTA,
                Z = SDL_JoystickGetAxis( joyPtr, 2 ) + DELTA,
                RotationX = SDL_JoystickGetAxis( joyPtr, 3 ) + DELTA,
                RotationY = SDL_JoystickGetAxis( joyPtr, 4 ) + DELTA,
                RotationZ = SDL_JoystickGetAxis( joyPtr, 5 ) + DELTA,
                //VelocityX = SDL_,
                //VelocityY = SDL_,
                //VelocityZ = SDL_,
                //AngularVelocityX = SDL_,
                //AngularVelocityY = SDL_,
                //AngularVelocityZ = SDL_,
                //AccelerationX = SDL_,
                //AccelerationY = SDL_,
                //AccelerationZ = SDL_,
                //AngularAccelerationX = SDL_,
                //AngularAccelerationY = SDL_,
                //AngularAccelerationZ = SDL_,
                //ForceX = SDL_,
                //ForceY = SDL_,
                //ForceZ = SDL_,
                //TorqueX = SDL_,
                //TorqueY = SDL_,
                //TorqueZ = SDL_,
                Buttons = GetButtons( joyPtr ),
                ViewPoints = GetViewPoints( joyPtr ),
                Sliders = GetSliders( joyPtr ),
                //VelocitySliders     = GetVelocitySliders( joyPtr ),
                //AccelerationSliders = GetAccelerationSliders( joyPtr ),
                //ForceSliders        = GetForceSliders( joyPtr )
            };
        }
    }
}
