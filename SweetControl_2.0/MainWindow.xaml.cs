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
    public partial class MainWindow : Window
    {
        // for use in other classes
        private static MainWindow instance;
        public static MainWindow getInstance()
        {
            if (instance == null)
                instance = new MainWindow();
            return instance;
        }

        // instance for replacing controls
        public static UserControlResults results = UserControlResults.getInstance();
        public static UserControlGraphic graphic = UserControlGraphic.getInstance();

        static GraphicViewModel graphicViewModel = GraphicViewModel.getInstance();
        static ResultsViewModel resultsViewModel = ResultsViewModel.getInstance();

        public MainWindow()
        {
            InitializeComponent();

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            MoveBorder.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            ButtonGrid.Content = "Таблица ♡";
        }

        // open UsuerControlResults
        public void openTable()
        {
            contentMain.Content = results;
        }

        // open UserControlGraphic
        public void openGraphic() 
        {
            contentMain.Content = graphic;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Mechanism for changing the appearance of buttons switching
        /// </summary>
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

        // drag and drop top panel
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
