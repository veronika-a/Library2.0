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
    /// Логика взаимодействия для EditBook.xaml
    /// </summary>
    public partial class EditBook : Window
    {
        EditBookViewModel editBook;
        //EditBookViewModel editBookViewModel = new EditBookViewModel();
        public EditBook(ref Book book)
        {
            InitializeComponent();

            editBook = new EditBookViewModel(book);
            DataContext = editBook;
            editBook.Closing += (s, e) => Close();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            CatalogBooksAdmin catalogBooksAdmin = new CatalogBooksAdmin();
            this.Close();
            catalogBooksAdmin.Show();
        }
    }
}
