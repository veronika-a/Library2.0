using Library.Models;
using Library.ViewModels;
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
using System.Windows.Shapes;

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для CabinetAdmin.xaml
    /// </summary>
    public partial class CabinetAdmin : Window
    {
        CabinetAdminViewModel cabinet;

        public CabinetAdmin(ref Reader reader)
        {
            InitializeComponent();

            cabinet = new CabinetAdminViewModel(reader);
            DataContext = cabinet;
            cabinet.Closing += (s, e) => Close();
        }
        public CabinetAdmin()
        {
            InitializeComponent();

            cabinet = new CabinetAdminViewModel();
            DataContext = cabinet;
            cabinet.Closing += (s, e) => Close();
        }

        private void Button_CalalogReaders(object sender, RoutedEventArgs e)
        {
            CatalogReaders catalogReaders = new CatalogReaders();
            this.Close();
            catalogReaders.Show();
        }

        private void Button_CalalogBookAdmin(object sender, RoutedEventArgs e)
        {
            CatalogBooksAdmin catalogBooksAdmin = new CatalogBooksAdmin();
            this.Close();
            catalogBooksAdmin.Show();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Button_Orders(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            this.Close();
            orders.Show();
        }
    }
}
