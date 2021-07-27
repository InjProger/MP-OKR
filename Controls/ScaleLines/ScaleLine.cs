
using System.Drawing;
using MissionPlanner.Utilities;
using System.Drawing.Drawing2D;

namespace MissionPlanner.Controls.ScaleLines
{
    public class ScaleLine
    {   
        private const int BOTTOM_INDENT = 15;
        private const int TEXT_VERTICAL_INDENT = 25;
        private const int HALF_SIZE_VERTICAL_LINES = 10;

        private int _rightMargin;
        private int _Length; // длина линии в рх
        private string _distance;
        private Size _size;

        private Graphics _graphics;
        private PointF _centerLine;
        private Line _horizontalLine;
        private Line _verticalLeftLine, _verticalRigthLine;

        public ScaleLine( Graphics graphics, int scale, Size size, int rightMargin = 0 )
        {
            _rightMargin = rightMargin;
            _graphics = graphics;
            _size = size;

            var sizeScale = new SizeScale( scale );
            _distance = sizeScale.Distance;
            _Length = sizeScale.PixelCount;
            
            CreateHorizontalLine( );
            CreateVerticalLines( );

            _centerLine = _horizontalLine.Center;

            void CreateHorizontalLine()
            {
                var endPoint = new Point
                {
                    X = _size.Width - _rightMargin,
                    Y = _size.Height - BOTTOM_INDENT
                };

                var begPoint = new Point
                {
                    X = endPoint.X - _Length - _rightMargin,
                    Y = endPoint.Y
                };

                _horizontalLine = new Line( begPoint, endPoint );
            }
        }

        private void CreateVerticalLines()
        {
            _verticalLeftLine = CreateLeftVerticalLine( );
            _verticalRigthLine = CreateRigthtVerticalLine( );

            Line CreateLeftVerticalLine()
            {
                var begPoint = new Point
                {
                    X = _horizontalLine.BegPoint.X,
                    Y = _horizontalLine.BegPoint.Y + HALF_SIZE_VERTICAL_LINES
                };

                var endPoint = new Point
                {
                    X = _horizontalLine.BegPoint.X,
                    Y = _horizontalLine.BegPoint.Y - HALF_SIZE_VERTICAL_LINES
                };

                return new Line( begPoint, endPoint );
            }

            Line CreateRigthtVerticalLine()
            {
                var begPoint = new Point
                {
                    X = _horizontalLine.EndPoint.X,
                    Y = _horizontalLine.EndPoint.Y + HALF_SIZE_VERTICAL_LINES
                };

                var endPoint = new Point
                {
                    X = _horizontalLine.EndPoint.X,
                    Y = _horizontalLine.EndPoint.Y - HALF_SIZE_VERTICAL_LINES
                };

                return new Line( begPoint, endPoint );
            }
        }

        private PointF CreateTextPoint(float centerX, float textPixelLength)
        { 
            return new PointF
            {
                X = centerX - textPixelLength / 2,
                Y = _horizontalLine.EndPoint.Y - TEXT_VERTICAL_INDENT
            };
        }

        private void DrawBackRectangle( SolidBrush brush )
        {
            var rectangle = new Rectangle( );

            _graphics.FillRectangle( brush, rectangle );
        }

        private void DrawBackground( Color color, FontStyle fontStyle )
        {
            var pen = new Pen( color, 4 );
            var brush = new SolidBrush( color );
            var font = new Font( FontFamily.GenericSansSerif, 11, fontStyle );
            var textSize = _graphics.MeasureString( _distance, font );

            var point = CreateTextPoint( _centerLine.X, textSize.Width );

            DrawBackRectangle( brush );
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.DrawLine( pen, _horizontalLine.BegPoint, _horizontalLine.EndPoint );
            _graphics.DrawString( _distance, font, brush, point );

            _graphics.DrawLine( pen, _verticalLeftLine.BegPoint, _verticalLeftLine.EndPoint );
            _graphics.DrawLine( pen, _verticalRigthLine.BegPoint, _verticalRigthLine.EndPoint );
        }

        private void DrawForeground( Color color, FontStyle fontStyle )
        {
            var pen = new Pen( color, 2 );
            var brush = new SolidBrush( color );
            var font = new Font( FontFamily.GenericSansSerif, 9, fontStyle );
            var textPixelLenght = _graphics.MeasureString( _distance, font );

            var point = CreateTextPoint( _centerLine.X, textPixelLenght.Width );
            point.X += 1;
            point.Y -= 2;

            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.DrawLine( pen, _horizontalLine.BegPoint, _horizontalLine.EndPoint );
            
            _graphics.DrawLine( pen, _verticalLeftLine.BegPoint, _verticalLeftLine.EndPoint );
            _graphics.DrawLine( pen, _verticalRigthLine.BegPoint, _verticalRigthLine.EndPoint );
        }

        public void Draw()
        {
            DrawBackground( Color.White, FontStyle.Regular );
            DrawForeground( Color.Black, FontStyle.Bold );
        }
    }
}