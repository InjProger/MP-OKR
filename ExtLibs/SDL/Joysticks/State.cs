
using System.Globalization;

namespace SDL.Joysticks
{
    public class State
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Z
        {
            get;
            set;
        }

        public int RotationX
        {
            get;
            set;
        }

        public int RotationY
        {
            get;
            set;
        }

        public int RotationZ
        {
            get;
            set;
        }

        public int[] Sliders
        {
            get;
            internal set;
        }

        public int[] ViewPoints
        {
            get;
            internal set;
        }

        public bool[] Buttons
        {
            get;
            internal set;
        }

        public int VelocityX
        {
            get;
            set;
        }

        public int VelocityY
        {
            get;
            set;
        }

        public int VelocityZ
        {
            get;
            set;
        }

        public int AngularVelocityX
        {
            get;
            set;
        }

        public int AngularVelocityY
        {
            get;
            set;
        }

        public int AngularVelocityZ
        {
            get;
            set;
        }

        public int[] VelocitySliders
        {
            get;
            internal set;
        }

        public int AccelerationX
        {
            get;
            set;
        }

        public int AccelerationY
        {
            get;
            set;
        }

        public int AccelerationZ
        {
            get;
            set;
        }

        public int AngularAccelerationX
        {
            get;
            set;
        }

        public int AngularAccelerationY
        {
            get;
            set;
        }

        public int AngularAccelerationZ
        {
            get;
            set;
        }

        public int[] AccelerationSliders
        {
            get;
            internal set;
        }

        public int ForceX
        {
            get;
            set;
        }

        public int ForceY
        {
            get;
            set;
        }

        public int ForceZ
        {
            get;
            set;
        }

        public int TorqueX
        {
            get;
            set;
        }

        public int TorqueY
        {
            get;
            set;
        }

        public int TorqueZ
        {
            get;
            set;
        }

        public int[] ForceSliders
        {
            get;
            internal set;
        }

        public State ( )
        {
            Sliders = new int[ 2 ];
            ViewPoints = new int[ 4 ];
            Buttons = new bool[ 128 ];
            VelocitySliders = new int[ 2 ];
            AccelerationSliders = new int[ 2 ];
            ForceSliders = new int[ 2 ];
        }

        public override string ToString ( )
        {
            var sliders = string.Join( ";", Sliders );
            var viewPoints = string.Join( ";", ViewPoints );
            var buttons = string.Join( ";", Buttons );
            var velocitySliders = string.Join( ";", VelocitySliders );
            var accelerationSliders = string.Join( ";", AccelerationSliders );
            var forceSliders = string.Join( ";", ForceSliders );

            return string.Format
            (
                CultureInfo.InvariantCulture,
                $"X: {X}, Y: {Y}, Z: {Z}, " +
                $"RotationX: {RotationX}, RotationY: {RotationY}, RotationZ: {RotationZ}, " +
                $"Sliders: {sliders}, ViewPoints: {viewPoints}, Buttons: {buttons}, " +
                $"VelocityX: {VelocityX}, VelocityY: {VelocityY}, VelocityZ: {VelocityZ}, " +
                $"AngularVelocityX: {AngularVelocityX}, AngularVelocityY: {AngularAccelerationY}, AngularVelocityZ: {AngularAccelerationZ}, VelocitySliders: {velocitySliders}, " +
                $"AccelerationX: {AccelerationX}, AccelerationY: {AccelerationY}, AccelerationZ: {AccelerationZ}, " +
                $"AngularAccelerationX: {AngularAccelerationX}, AngularAccelerationY: {AngularAccelerationY}, AngularAccelerationZ: {AngularAccelerationZ}, AccelerationSliders: {accelerationSliders}, " +
                $"ForceX: {ForceX}, ForceY: {ForceY}, ForceZ: {ForceZ}, " +
                $"TorqueX: {TorqueX}, TorqueY: {TorqueY}, TorqueZ: {TorqueZ}, ForceSliders: {forceSliders}"
            );
        }
    }
}
