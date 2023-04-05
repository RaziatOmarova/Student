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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Student Student { get; set; }
        public Page1(Student student) 
        {
            InitializeComponent();
            Student = student;
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Student.ID == 0)
            {
                MainClass.db.Student.Add(Student);
            }
            MainClass.db.SaveChanges();
            MessageBox.Show("Data saved.", "Successfully", MessageBoxButton.OK, MessageBoxImage.Question);
            NavigationService.GoBack();
        }
    }
}
