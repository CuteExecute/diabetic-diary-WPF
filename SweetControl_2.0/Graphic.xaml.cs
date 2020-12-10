using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SweetControl_2._0
{
    /// <summary>
    /// Логика взаимодействия для Graphic.xaml
    /// </summary>
    public partial class Graphic : UserControl
    {
        public List<Point> PointList = new List<Point>();
        GraphicPainter painter;

        public Graphic()
        {
            InitializeComponent();

            //PointList.Add(new Point(0, 0));
            //PointList.Add(new Point(1, 1));
            //PointList.Add(new Point(2, 2));
            //PointList.Add(new Point(3, 3));
            //PointList.Add(new Point(4, 4));
            //PointList.Add(new Point(5, 5));
            //PointList.Add(new Point(6, 6));
            //PointList.Add(new Point(7, 7));
            //PointList.Add(new Point(8, 8));
            //PointList.Add(new Point(9, 9));
            //PointList.Add(new Point(10, 10));

            //PointList.Add(new Point(0, 0));
            //PointList.Add(new Point(1, 1));
            //PointList.Add(new Point(2, 2));
            //PointList.Add(new Point(3, 3));
            //PointList.Add(new Point(4, 4));
            //PointList.Add(new Point(5, 5));
            //PointList.Add(new Point(6, 6));
            //PointList.Add(new Point(7, 7));
            //PointList.Add(new Point(8, 8));
            //PointList.Add(new Point(9, 9));
            //PointList.Add(new Point(10, 10));
            //PointList.Add(new Point(11, 11));

            PointList.Add(new Point(0, 15));       // ексепшен
            //PointList.Add(new Point(1, 4.5));     // пусто
            //PointList.Add(new Point(2, 8.9));
            //PointList.Add(new Point(3, 4.1));
            //PointList.Add(new Point(4, 6.2));
            //PointList.Add(new Point(5, 9));
            //PointList.Add(new Point(6, 13.2));
            //PointList.Add(new Point(7, 8.3));
            //PointList.Add(new Point(8, 5));
            //PointList.Add(new Point(9, 7.7));
            //PointList.Add(new Point(10, 10));
            //PointList.Add(new Point(11, 11.9));
            //PointList.Add(new Point(12, 20.9));
            //PointList.Add(new Point(13, 31.5));
            //PointList.Add(new Point(14, 44));
            //PointList.Add(new Point(15, 56.5));

            //PointList.Add(new Point(6, 1));
            //PointList.Add(new Point(12, 2));
            //PointList.Add(new Point(8, 3));
            //PointList.Add(new Point(16, 4));
            //PointList.Add(new Point(4, 5));
            //PointList.Add(new Point(10, 6));
            //PointList.Add(new Point(17, 7));
            //PointList.Add(new Point(2, 8));
            //PointList.Add(new Point(5, 9));

            //PointList.Add(new Point(0, 6));
            //PointList.Add(new Point(1, 12));
            //PointList.Add(new Point(2, 8));
            //PointList.Add(new Point(3, 16));
            //PointList.Add(new Point(4, 4));
            //PointList.Add(new Point(5, 10));
            //PointList.Add(new Point(6, 17));
            //PointList.Add(new Point(7, 9));
            //PointList.Add(new Point(8, 5));

            //DrawGraphic(PointList);

            painter = new GraphicPainter(GraphicCanvas, PointList);
            painter.PaintGraphic();
        }

        public void DrawGraphic(List<Point> points) // TODO а что если элементов нет А!?
        {
            double w = GraphicCanvas.Width * 1; //Ширина зоны построения. 80% от ширины полотна * .8
            double h = GraphicCanvas.Height * .5; //Высота зоны построения. 80% от высоты полотна

            double[] arrayX = new double[points.Count];
            double[] arrayY = new double[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                arrayX[i] = points[i].x;
                arrayY[i] = points[i].y;
            }
            // TODO Сделать блок расчета размаха покрасивше и с учетом первых элементов      -------------------------------------------------------
            // Вычислить размах 
            double rangeX;
            double rangeY;

            // default method (3 and more elements)
            rangeX = arrayX.Max() - arrayX.Min();
            rangeY = arrayY.Max() - arrayY.Min();

            if (points.Count == 1) // Если всего 1 эл не имеет смысл вычислять размах
            {
                rangeY = arrayY[0];
            }
            else if (points.Count == 2)
            {
                rangeX = 1;
                rangeY = arrayY[1];
            }

            //Масштаб по X и Y
            double scaleX = w / rangeX; // Ясно понятно все.... этот придурок просто на 0 делит блять
            double scaleY = h / rangeY;

            if (rangeX == 0)
            {
                scaleX = 0;
            }
            if (rangeY == 0)
            {
                scaleY = 0;
            }
            MessageBox.Show($"{scaleX} and {scaleY}"); // 111111111111111111111111111111111111
            // -----------------------------------------------------------------------------------------------------------------------------------

            // Пересчет точек
            for (int i = 0; i < points.Count; i++)
            {
                points[i].x = points[i].x * scaleX;
                points[i].y = points[i].y * scaleY;
            }

            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(141, 108, 159)); // статик лайн
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
                draw.Add(new Line // Это розовая точка на графике 
                {
                    Stroke = new SolidColorBrush(Color.FromRgb(232, 80, 145)), // 193, 0, 32   rgb(232,80,145)  
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
                if (i == points.Count - 1) // Что бы график не вылазил за пределы и не рисовался там где не нужно
                {
                    GraphicCanvas.Children.Add(new Line  // Это линия графика между двумя точками
                    {
                        Stroke = new SolidColorBrush(Color.FromRgb(159, 144, 176)), // 193, 0, 32  
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
                    GraphicCanvas.Children.Add(new Line  // Это линия графика между двумя точками
                    {
                        Stroke = new SolidColorBrush(Color.FromRgb(159, 144, 176)), // 193, 0, 32  
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

            // конструктор
            public GraphicPainter(Canvas GraphicCanvas, List<Point> points)
            {
                this.GraphicCanvas = GraphicCanvas;

                // initializing arrays
                arrayX = new double[points.Count];
                arrayY = new double[points.Count];

                for (int i = 0; i < points.Count; i++)
                {
                    arrayX[i] = points[i].x;
                    arrayY[i] = points[i].y;
                }

                // point list transmission
                this.points = points;

                // width and height transmission
                this.width = GraphicCanvas.Width;
                this.height = GraphicCanvas.Height;
            }

            public void PaintGraphic()
            {
                {
                    BuildAreaScale(this.width, this.height);
                    CalculatingRangeAndScale();
                    MessageBox.Show($"{this.scaleX} and {this.scaleY}"); // 111111111111111111111111111111111111
                    CalculatingScaleNewPoint();
                }

                SolidColorBrush color = new SolidColorBrush(Color.FromRgb(141, 108, 159)); // статик лайн
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
                    draw.Add(new Line // Это розовая точка на графике 
                    {
                        Stroke = new SolidColorBrush(Color.FromRgb(232, 80, 145)), // 193, 0, 32   rgb(232,80,145)  
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
                    if (i == points.Count - 1) // Что бы график не вылазил за пределы и не рисовался там где не нужно
                    {
                        GraphicCanvas.Children.Add(new Line  // Это линия графика между двумя точками
                        {
                            Stroke = new SolidColorBrush(Color.FromRgb(159, 144, 176)), // 193, 0, 32  
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
                        GraphicCanvas.Children.Add(new Line  // Это линия графика между двумя точками
                        {
                            Stroke = new SolidColorBrush(Color.FromRgb(159, 144, 176)), // 193, 0, 32  
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

                if (points.Count == 1) // Если всего 1 эл не имеет смысл вычислять размах
                {
                    rangeY = arrayY[0];
                }
                else if (points.Count == 2)
                {
                    rangeX = 1;
                    rangeY = arrayY[1];
                }

                //Масштаб по X и Y
                scaleX = width / rangeX; // Ясно понятно все.... этот придурок просто на 0 делит блять
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
                // Пересчет точек
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
