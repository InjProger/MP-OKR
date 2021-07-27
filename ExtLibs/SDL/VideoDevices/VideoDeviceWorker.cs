namespace SDL.VideoDevices
{
    using static Sdl;

    public class VideoDeviceWorker
    {
        private SDL_DisplayMode _displayMode;

        public void Init ( )
        {
            if ( SDL_Init( SDL_INIT_VIDEO ) < 0 )
            {
                throw new SdlException("Not init SDL Video");
            }

            SDL_GetDesktopDisplayMode( 1, out _displayMode );
        }
    }
}
