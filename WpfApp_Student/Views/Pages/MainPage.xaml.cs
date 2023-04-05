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
using WpfApp_Student.Context;
using WpfApp_Student.Model;

namespace WpfApp_Student.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SearchTXB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView.ItemsSource = MainClass.db.Student.Where(item => item.LastName.Contains(SearchTXB.Text) 
            || item.FirstName.Contains(SearchTXB.Text)
            || item.MiddleName.Contains(SearchTXB.Text)).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = MainClass.db.Student.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(new Model.Student()));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) 
        {
            var selectedItem = (Student)DataView.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new Page1(selectedItem));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Student)DataView.SelectedItem;
            if (selectedItem != null)
            {
                MainClass.db.Student.Remove(selectedItem);
                MainClass.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Item deleted", "Successfully!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
