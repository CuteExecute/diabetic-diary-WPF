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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MoveBorder.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // выбранный элемент дополяется сердечком (Хотелось бы отметить что это тоже не самое лучшее решение, но я только осваиваюсь в WPF) <3

        private void ButtonGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonGrid.Content = "Таблица ♥";
        }

        private void ButtonGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonGrid.Content = "Таблица";
        }

        private void ButtonGraphic_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonGraphic.Content = "График ♥";
        }

        private void ButtonGraphic_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonGraphic.Content = "График";
        }

        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
