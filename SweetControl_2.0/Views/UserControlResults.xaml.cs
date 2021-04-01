using SweetControl_2._0.Models;
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
    /// Логика взаимодействия для UserControlResults.xaml
    /// </summary>
    public partial class UserControlResults : UserControl
    {
        private static UserControlResults instance;

        public static UserControlResults getInstance()
        {
            if (instance == null)
                instance = new UserControlResults();
            return instance;
        }

        public UserControlResults()
        {
            InitializeComponent();

            EditButton.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;

            TextBoxResult.IsEnabled = false;
            TextBoxTime.IsEnabled   = false;
            TextBoxDate.IsEnabled   = false;

            if (ListBoxResults.SelectedItem == null)
                EditCheckBox.IsEnabled = false;
        }

        private void EditCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EditButton.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;

            TextBoxResult.IsEnabled = true;
            //TextBoxTime.IsEnabled   = false;
            //TextBoxDate.IsEnabled   = false;
        }

        private void EditCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            EditButton.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;

            TextBoxResult.IsEnabled = false;
            //TextBoxTime.IsEnabled   = false;
            //TextBoxDate.IsEnabled   = false;
        }

        private void ListBoxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxResults.SelectedItem == null)
                EditCheckBox.IsEnabled = false;
            if (ListBoxResults.SelectedItem != null)
                EditCheckBox.IsEnabled = true;

            // Делаю дубликат для редактирования
            ResultsViewModel instance = ResultsViewModel.getInstance();

            // Ошибка при переключении страниц и при изменении результата
            if (ListBoxResults.SelectedIndex != -1)
            {
                ResultsViewModel.ListBoxSelectedIndex = ListBoxResults.SelectedIndex;
                ResultsViewModel.TempResult = instance.Results[ListBoxResults.SelectedIndex];
            }
            try
            {
                
            }
            catch
            {

            }

            
            
        }
    }
}
