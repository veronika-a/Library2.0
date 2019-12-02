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
    /// Логика взаимодействия для CabinetReader.xaml
    /// </summary>
    public partial class CabinetReader : Window
    {
        Reader reader;
        public Reader Reader { get => reader; set => reader = value; }

        public CabinetReader()
        {
            InitializeComponent();
           
        }

        public CabinetReader(ref Reader reader)
        {
            CabinetReaderViewModel cabinet= new CabinetReaderViewModel(reader);
            DataContext = cabinet;
            cabinet.Closing += (s, e) => this.Close();
        }

        private void Button_MyBooks(object sender, RoutedEventArgs e)
        {
            BooksReader booksReader = new BooksReader();
            this.Close();
            booksReader.Show();
        }



    }
}
