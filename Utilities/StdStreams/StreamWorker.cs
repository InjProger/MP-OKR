
using System;
using System.Text;
using System.Drawing;
using System.IO;

using MissionPlanner.GCSViews.Alignments;

namespace MissionPlanner.Utilities.Streams
{
    public class StreamWorker : IDisposable
    {
        private const double ANGLE_MARK_1 = 20;
        private const double ANGLE_MARK_2 = 40;

        private StreamWriter _streamWriter;

        public StreamWorker ( StreamWriter streamWriter )
        {
            streamWriter.AutoFlush = false;
            _streamWriter = streamWriter;
        }

        public string ConvertParamToString ( EParam eParam, string value )
        {
            var paramName = Enum.GetName( typeof( EParam ), eParam );
            return $"set {paramName} \"{value}\"\n";
        }

        public void Update ( EParam eParam, string value )
        {
            var paramName = Enum.GetName( typeof( EParam ), eParam );

            _streamWriter.WriteLine( $"set {paramName} \"{value}\"\n" );
        }

        public void Update ( string text )
        {
            _streamWriter.WriteLine( $"{text}\n" );
        }

        public void Visible ( EParam eParam, bool isVisible )
        {
            var action = isVisible ? "show" : "hide";
            var paramName = Enum.GetName( typeof( EParam ), eParam );

            _streamWriter.WriteLine( $"{action} {paramName}\n" );
        }

        public void SetCrossOffset ( MissionPlanner.GCSViews.Alignments.Point point )
        {
            var xOffset = point.X.ToString( ).Replace( ',', '.' );
            var yOffset = point.Y.ToString( ).Replace( ',', '.' );

            var angle1Txt = ANGLE_MARK_1.ToString( ).Replace( ',', '.' );
            var angle2Txt = ANGLE_MARK_2.ToString( ).Replace( ',', '.' );

            _streamWriter.WriteLine( $"set_cross_offset {xOffset} {yOffset} {angle1Txt} {angle2Txt}\n" );
        }

        public void SetRangesSizes ( double rangeSize1, double rangeSize2 )
        {
            var rangeSize1Txt = rangeSize1.ToString( ).Replace( ',', '.' );
            var rangeSize2Txt = rangeSize2.ToString( ).Replace( ',', '.' );

            _streamWriter.WriteLine( $"set RANGE_1 {rangeSize1Txt} \n" );
            _streamWriter.WriteLine( $"set RANGE_2 {rangeSize2Txt} \n" );
        }

        public void SetCameraAngles ( double angleX = 0.314, double angleY = 0.244 )
        {
            var strAngleXTxt = angleX.ToString( ).Replace( ',', '.' );
            var strAngleYTxt = angleY.ToString( ).Replace( ',', '.' );

            _streamWriter.WriteLine( $"set CAMERA_H_ANGLE {strAngleXTxt}\n" );
            _streamWriter.WriteLine( $"set CAMERA_V_ANGLE {strAngleYTxt}\n" );
        }

        public void ShowCorrectionMarks ( double angle1 = ANGLE_MARK_1, double angle2 = ANGLE_MARK_2 )
        {
            var point = Configs.Configurator.Setting.AimPoint;

            var angle1Txt = angle1.ToString( ).Replace( ',', '.' );
            var angle2Txt = angle2.ToString( ).Replace( ',', '.' );

            _streamWriter.WriteLine( $"set_cross_offset {point.X} {point.Y} {angle1Txt} {angle2Txt}\n" );
        }

        public void HideCorrectionMarks ( )
        {
            _streamWriter.WriteLine( $"hide CORRECTION_MARK_1\n" );
            _streamWriter.WriteLine( $"hide CORRECTION_MARK_2\n" );
        }

        public void ShowRanges ( )
        {
            _streamWriter.WriteLine( $"show RANGE_1\n" );
            _streamWriter.WriteLine( $"show RANGE_2\n" );
        }

        public void HideRanges ( )
        {
            _streamWriter.WriteLine( $"hide RANGE_1\n" );
            _streamWriter.WriteLine( $"hide RANGE_2\n" );
        }

        public void StartRecording ( )
        {
            _streamWriter.WriteLine( "start_recording\n" );
        }

        public void StopRecording ( )
        {
            _streamWriter.WriteLine( "stop_recording\n" );
        }

        public void Pause ( )
        {
            _streamWriter.WriteLine( "pause\n" );
        }

        public void ForegroundColor( EParam param, Color color )
        {
            var paramName = Enum.GetName( typeof( EParam ), param );
            _streamWriter.WriteLine( $"fg {paramName} {color.R} {color.G} {color.B} {color.A}\n" );
        }

        public void Resume ( )
        {
            _streamWriter.WriteLine( "resume\n" );
        }

        public void Quit ( )
        {
            _streamWriter.WriteLine( "quit\n" );
        }

        public void Close ( )
        {
            Quit( );
            _streamWriter.Close( );
        }

        public void Dispose ( )
        {
            Close( );
            _streamWriter.Dispose( );
        }
    }
}
