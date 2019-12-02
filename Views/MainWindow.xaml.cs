using Library.Models;
using Library.ViewModels;
using Library.Views;
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

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            //var db = new MyAppContext();
            //var configuration = new Migrations.Configuration();
            //configuration.RunSeed(db);
        }


        private void Button_SingIn(object sender, RoutedEventArgs e)
        {
            SingIn singIn = new SingIn();
            this.Close();
            singIn.Show();
        }



        private void Button_About(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Registration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            this.Close();
            registration.Show();
        }
    }
}
