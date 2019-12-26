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
    /// Логика взаимодействия для CatalogBooksAdmin.xaml
    /// </summary>
    public partial class CatalogBooksAdmin : Window
    {
        CatalogBooksAdminViewModel catalog;
        public CatalogBooksAdmin(ref Reader reader)
        {
            InitializeComponent();
            catalog = new CatalogBooksAdminViewModel(reader);
            DataContext = catalog;

            catalog.Closing += (s, e) => this.Close();
        }
        
        //private void Button_AddBook(object sender, RoutedEventArgs e)
        //{
        //    NewBook newBook = new NewBook();
        //    this.Close();
        //    newBook.Show();
        //}

        //private void Button_Back(object sender, RoutedEventArgs e)
        //{
        //    CabinetAdmin cabinet = new CabinetAdmin();
        //    this.Close();
        //    cabinet.Show();
        //}
    }
}
