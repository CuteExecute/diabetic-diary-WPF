using SweetControl_2._0.ViewModels;
using SweetControl_2._0.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Singleton
        private static MainWindow instance;
        public static MainWindow getInstance()
        {
            if (instance == null)
                instance = new MainWindow();
            return instance;
        }

        // Для замены контролов
        public static UserControlResults results = UserControlResults.getInstance();
        public static UserControlGraphic graphic = UserControlGraphic.getInstance();
        //static UserControlGraphic graphic = new UserControlGraphic(); // фикс ошибки
        //static UserControlGraphic graphic = new UserControlGraphic(ResultViewModel._PointList); // old

        static GraphicViewModel graphicViewModel = GraphicViewModel.getInstance();
        static ResultsViewModel resultsViewModel = ResultsViewModel.getInstance();

        public MainWindow()
        {
            //instance = getInstance(); // Инициализируем экземпляр класса
            InitializeComponent();

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            MoveBorder.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            ButtonGrid.Content = "Таблица ♡";
        }

        public void openTable()
        {
            //contentMain.Content = new UserControlResults();
            contentMain.Content = results;
        }

        public void openGraphic() // Это открывает новый юзер контрол с графиком, добавить графику синглтон?
        {
            contentMain.Content = graphic;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        // выбранный элемент дополняется сердечком (Хотелось бы отметить что это тоже не самое лучшее решение, но я только осваиваюсь в WPF) <3

        bool isGrid = true;
        private void ButtonGrid_Click(object sender, RoutedEventArgs e)
        {
            openTable(); // ♡

            ButtonGraphic.Content = "График";
            ButtonGrid.Content = "Таблица ♡";
            isGrid = true;
        }

        private void ButtonGraphic_Click(object sender, RoutedEventArgs e)
        {
            openGraphic();

            ButtonGrid.Content = "Таблица";
            ButtonGraphic.Content = "График ♡";
            isGrid = false;
        }

        private void ButtonGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonGrid.Content = "Таблица ♥";
        }

        private void ButtonGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isGrid)
                ButtonGrid.Content = "Таблица ♡";
            else
                ButtonGrid.Content = "Таблица";
        }

        private void ButtonGraphic_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonGraphic.Content = "График ♥";
        }

        private void ButtonGraphic_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isGrid == false)
                ButtonGraphic.Content = "График ♡";
            else
                ButtonGraphic.Content = "График";
        }

        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
