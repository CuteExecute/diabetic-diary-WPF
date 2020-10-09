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

        public Graphic()
        {
            InitializeComponent();

            CenterLine();

            //PointList.Add(new Point(1, 1));
            //PointList.Add(new Point(2, 2));
            //PointList.Add(new Point(3, 3));
            //PointList.Add(new Point(4, 4));
            //PointList.Add(new Point(-1, -1));
            //PointList.Add(new Point(-2, -2));
            //PointList.Add(new Point(-3, -3));
            //PointList.Add(new Point(-4, -4));

            PointList.Add(new Point(1, 1));
            PointList.Add(new Point(2, 2));
            PointList.Add(new Point(3, 3));
            PointList.Add(new Point(4, 4));
            PointList.Add(new Point(5, 5));
            PointList.Add(new Point(6, 6));
            PointList.Add(new Point(7, 7));
            PointList.Add(new Point(8, 8));
            PointList.Add(new Point(9, 9));
            PointList.Add(new Point(10, 10));

            //PointList.Add(new Point(6, 1));
            //PointList.Add(new Point(12, 2));
            //PointList.Add(new Point(8, 3));
            //PointList.Add(new Point(16, 4));
            //PointList.Add(new Point(4, 5));
            //PointList.Add(new Point(10, 6));
            //PointList.Add(new Point(17, 7));
            //PointList.Add(new Point(2, 8));
            //PointList.Add(new Point(5, 9));

            DrawGraphic(PointList);
        }

        public void CenterLine()
        {
            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(141, 108, 159));
            var line = new Line
            {
                Stroke = color,
                StrokeThickness = 2,
                X1 = 0, Y1 = GraphicCanvas.Height / 2,
                X2 = GraphicCanvas.Width, Y2 = GraphicCanvas.Height / 2,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round
            };
            GraphicCanvas.Children.Add(line);
        }

        public void DrawGraphic(List<Point> points)
        {
            var w = GraphicCanvas.Width * .8;//Ширина зоны построения. 80% от ширины полотна
            var h = GraphicCanvas.Height * .8;//Высота зоны построения. 80% от высоты полотна

            double[] arrayX = new double[points.Count];
            double[] arrayY = new double[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                arrayX[i] = points[i].x;
                arrayY[i] = points[i].y;
            }

            // Вычислить размах
            var rangeX = arrayX.Max() - arrayX.Min();
            var rangeY = arrayY.Max() - arrayY.Min();

            //Масштаб по X
            var scaleX = w / rangeX;
            //Масштаб по Y
            var scaleY = h / rangeY;

            // Пересчет точек
            for (int i = 0; i < points.Count; i++)
            {
                points[i].x = points[i].x * scaleX;
                points[i].y = points[i].y * scaleY;
            }

            List<Line> draw = new List<Line>();

            for (int i = 0; i < points.Count; i++)
            {
                draw.Add(new Line {
                    Stroke = new SolidColorBrush(Color.FromRgb(193, 0, 32)),
                    StrokeThickness = 10,
                    X1 = points[i].x,
                    Y1 = points[i].y,
                    X2 = points[i].x,
                    Y2 = points[i].y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round
                });

                //var line = new Line
                //{
                //    Stroke = new SolidColorBrush(Color.FromRgb(193, 0, 32)),
                //    StrokeThickness = 10,
                //    X1 = points[i].x,
                //    Y1 = points[i].y,
                //    X2 = points[i].x,
                //    Y2 = points[i].y,
                //    StrokeStartLineCap = PenLineCap.Round,
                //    StrokeEndLineCap = PenLineCap.Round
                //};

                //GraphicCanvas.Children.Add(line);
            }

            for (int i = 0; i < draw.Count; i++)
            {
                GraphicCanvas.Children.Add(draw[i]);
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
