using SweetControl_2._0.ViewModels;
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

namespace SweetControl_2._0.Views
{
    /// <summary>
    /// Логика взаимодействия для Graphic.xaml
    /// </summary>
    public partial class UserControlGraphic : UserControl
    {
        // Singleton
        private static UserControlGraphic instance;
        public static UserControlGraphic getInstance()
        {
            if (instance == null)
                instance = new UserControlGraphic();
            return instance;
        }
        // Singleton


        public List<Point> PointList = new List<Point>();
        GraphicPainter painter;

        public UserControlGraphic()
        {
            InitializeComponent();
        }

        public UserControlGraphic(List<Point> _PointList) 
        {
            InitializeComponent();

            //GraphicCanvas.Children.Clear();
            PointList = _PointList;


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

            //PointList.Add(new Point(0, 15));       // ексепшен
            //PointList.Add(new Point(1, 6.5));     // пусто 6.5
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

            //string str = "";
            //foreach (var item in PointList)
            //{
            //    str += $" {item.x} - {item.y}\n";
            //}
            //MessageBox.Show(str);                     // НАШЕЛ!

            painter = new GraphicPainter(GraphicCanvas, PointList);
            painter.PaintGraphic();

            //JsonFileWorker myJson = new JsonFileWorker();

            //myJson.RemoveFileLine("11.02.2021", "13:10", "1", "7.5");

            //myJson.WriteToFile(10.9, 1);

            //WrapperResult[] testRes = myJson.ReadingFromFile();
            //MessageBox.Show($"{testRes[1].Resultation} - {testRes[1].Time}"); // OK B)

            //MessageBox.Show($"{JsonFileWorker.json}\n{JsonFileWorker.restoreRes.Resultation}");
        }

        public void Update(List<Point> _PointList)
        {
            //this.PointList.Clear();
            GraphicCanvas.Children.Clear();
            this.PointList = _PointList;

            //var lol = PointList;
            //string str = "";
            //foreach (var item in lol)
            //{
            //    str += $" {item.x} - {item.y}\n";
            //}
            //MessageBox.Show(str);

            if (PointList.Count != 0)
            {
                painter = new GraphicPainter(GraphicCanvas, PointList);
                painter.PaintGraphic();
            }
            else
                MessageBox.Show("Данных нету");
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

            // ctor
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
                    CalculatingScaleNewPoint();
                }

                // Линии нормлаьного результата
                SolidColorBrush color = new SolidColorBrush(Color.FromRgb(253, 174, 196)); // static line 253,174,196 - 141, 108, 159
                var lineTop = new Line
                {
                    Stroke = color,
                    StrokeThickness = 2,
                    X1 = 0,
                    Y1 = 7.8 * scaleY,  // GraphicCanvas.Height / 2
                    X2 = GraphicCanvas.Width,
                    Y2 = 7.8 * scaleY, // GraphicCanvas.Height / 2
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round
                };

                if (lineTop.Y2 < GraphicCanvas.Height) // Что бы топ лайн не рисовался выше потолка!
                    GraphicCanvas.Children.Add(lineTop);

                var lineBottom = new Line
                {
                    Stroke = color,
                    StrokeThickness = 2,
                    X1 = 0,
                    Y1 = 3.3 * scaleY,  // GraphicCanvas.Height / 2
                    X2 = GraphicCanvas.Width,
                    Y2 = 3.3 * scaleY, // GraphicCanvas.Height / 2
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round
                };
                GraphicCanvas.Children.Add(lineBottom);

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
                this.width = w; // * 1
                //this.height = h * 0.3; // Множитель высоты - old, see sacaleY
                this.height = h;
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
                //scaleY = height / rangeY; // original
                scaleY = (height - 20) / points.Max(points => points.y); // 20 - отсуп от верхней части

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
