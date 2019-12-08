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
    /// Логика взаимодействия для CatalogReaders.xaml
    /// </summary>
    public partial class CatalogReaders : Window
    {
        
        CatalogReadersViewModel catalog = new CatalogReadersViewModel();
        public CatalogReaders()
        {
            InitializeComponent();
            DataContext = catalog;

            catalog.Closing += (s, e) => this.Close();
        }
    }
}
