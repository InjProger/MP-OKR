namespace SDL.Windows
{
    using System;

    using static SDL.Sdl;

    public class WindowWorker : IDisposable
    {
        public readonly IntPtr WindowPtr;

        public WindowWorker ( )
        {
            //SDL_GetNumVideoDisplays( );
            SDL_GetCurrentDisplayMode( 1, out SDL_DisplayMode displayMode );

            var newX = displayMode.w + 1;
            var newY = displayMode.h + 1;

            WindowPtr = SDL_CreateWindow( "Hello, SDL 2!", newX, newY, 100, 100, SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | SDL_WindowFlags.SDL_WINDOW_SHOWN );
        }

        public void Close ( )
        {
            SDL_DestroyWindow( WindowPtr );
            SDL_Quit( );
        }

        public void Dispose ( )
        {
            Close( );
        }
    }
}
