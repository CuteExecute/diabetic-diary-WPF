using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SweetControl_2._0
{
    public partial class Graphic : UserControl
    {
        public List<Point> PointList = new List<Point>();

        public Graphic()
        {
            InitializeComponent();
        }

        public class GraphicPainter
        {
            Canvas GraphicCanvas;

            List<Point> points = new List<Point>();
            double width { get; set; }
            double height { get; set; }

            double[] arrayX;
            double[] arrayY;

            double scaleX { get; set; } 
            double scaleY { get; set; }

            // ctor - passing parameters
            public GraphicPainter(Canvas GraphicCanvas, List<Point> points)
            {
                this.GraphicCanvas = GraphicCanvas;

                arrayX = new double[points.Count];
                arrayY = new double[points.Count];

                for (int i = 0; i < points.Count; i++)
                {
                    arrayX[i] = points[i].x;
                    arrayY[i] = points[i].y;
                }

                this.points = points;

                this.width = GraphicCanvas.Width;
                this.height = GraphicCanvas.Height;
            }

            public void PaintGraphic()
            {
                {
                    BuildAreaScale(this.width, this.height);
                    CalculatingRangeAndScale();
                    CalculatingScaleNewPoint();
                }

                SolidColorBrush color = new SolidColorBrush(Color.FromRgb(141, 108, 159)); // static line
                var line = new Line
                {
                    Stroke = color,
                    StrokeThickness = 2,
                    X1 = 0,
                    Y1 = 7.3 * scaleY,  // GraphicCanvas.Height / 2
                    X2 = GraphicCanvas.Width,
                    Y2 = 7.3 * scaleY, // GraphicCanvas.Height / 2
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round
                };
                GraphicCanvas.Children.Add(line);

                List<Line> draw = new List<Line>();

                for (int i = 0; i < points.Count; i++)
                {
                    draw.Add(new Line // pink point on graph
                    {
                        Stroke = new SolidColorBrush(Color.FromRgb(232, 80, 145)), 
                        StrokeThickness = 6,
                        X1 = points[i].x,
                        Y1 = points[i].y,
                        X2 = points[i].x,
                        Y2 = points[i].y,
                        StrokeStartLineCap = PenLineCap.Round,
                        StrokeEndLineCap = PenLineCap.Round
                    });
                }

                for (int i = 0; i < points.Count; i++)
                {
                    if (i == points.Count - 1) 
                    {
                        GraphicCanvas.Children.Add(new Line  // closing line if there are no further points
                        {
                            Stroke = new SolidColorBrush(Color.FromRgb(159, 144, 176)),  
                            StrokeThickness = 4,
                            X1 = points[i].x,
                            Y1 = points[i].y,
                            X2 = points[i].x,
                            Y2 = points[i].y,
                            StrokeStartLineCap = PenLineCap.Round,
                            StrokeEndLineCap = PenLineCap.Round
                        });
                    }
                    else
                    {
                        GraphicCanvas.Children.Add(new Line  // line between two points
                        {
                            Stroke = new SolidColorBrush(Color.FromRgb(159, 144, 176)), 
                            StrokeThickness = 4,
                            X1 = points[i].x,
                            Y1 = points[i].y,
                            X2 = points[i + 1].x,
                            Y2 = points[i + 1].y,
                            StrokeStartLineCap = PenLineCap.Round,
                            StrokeEndLineCap = PenLineCap.Round
                        });
                    }
                    GraphicCanvas.Children.Add(draw[i]);
                }
            }

            // build area width and height
            private void BuildAreaScale(double w, double h)
            {
                this.width = w * 1;
                this.height = h * .5;
            }

            private void CalculatingRangeAndScale()
            {
                double rangeX;
                double rangeY;

                // default method (3 and more elements)
                rangeX = arrayX.Max() - arrayX.Min();
                rangeY = arrayY.Max() - arrayY.Min();

                if (points.Count == 1) // do not calculate span if only 1 element
                {
                    rangeY = arrayY[0];
                }
                else if (points.Count == 2)
                {
                    rangeX = 1;
                    rangeY = arrayY[1];
                }

                // scale X and Y
                scaleX = width / rangeX; 
                scaleY = height / rangeY;

                if (rangeX == 0)
                {
                    scaleX = 0;
                }
                if (rangeY == 0)
                {
                    scaleY = 0;
                }
            }

            private void CalculatingScaleNewPoint()
            {
                // Recalculating points to the desired scale
                for (int i = 0; i < points.Count; i++)
                {
                    points[i].x = points[i].x * scaleX;
                    points[i].y = points[i].y * scaleY;
                }
            }
        }

        public class Point
        {
            public double x { get; set; }
            public double y { get; set; }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
