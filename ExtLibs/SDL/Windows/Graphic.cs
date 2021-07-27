namespace SDL.Windows
{
    using System;

    using static SDL.Sdl;

    public class Graphic
    {
        private IntPtr _surfacePtr;

        public Graphic ( Window window )
        {
            _surfacePtr = SDL_GetWindowSurface( window.WindowWorker.WindowPtr );
        }

        public void DrawLine(SDL_FPoint pointA, SDL_FPoint pointB)
        {

        }
    }
}
