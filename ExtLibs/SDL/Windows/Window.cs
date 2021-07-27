using System;

namespace SDL.Windows
{
    public class Window : IDisposable
    {
        private Graphic _graphic;

        public readonly WindowWorker WindowWorker;

        public Window ( )
        {
            WindowWorker = new WindowWorker( );
            _graphic = new Graphic( this );
        }

        public void Dispose ( )
        {
            WindowWorker.Close( );
        }
    }
}
