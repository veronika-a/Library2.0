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
    /// Логика взаимодействия для NewBook.xaml
    /// </summary>
    public partial class NewBook : Window
    {
        NewBookViewModel newBook = new NewBookViewModel();
        public NewBook()
        {
            InitializeComponent();
            DataContext = newBook;
            newBook.Closing += (s, e) => this.Close();
        }
       
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            CatalogBooksAdmin catalogBooksAdmin = new CatalogBooksAdmin();
            this.Close();
            catalogBooksAdmin.Show();
        }

    }
}
