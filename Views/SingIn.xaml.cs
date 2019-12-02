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
    /// Логика взаимодействия для SingIn.xaml
    /// </summary>
    public partial class SingIn : Window
    {
        public SingIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CabinetReader cabinetReader = new CabinetReader();
            this.Close();
            cabinetReader.Width = this.Width;
            cabinetReader.Height = this.Height;
            cabinetReader.WindowStartupLocation = this.WindowStartupLocation;
            cabinetReader.Show();
        }
    }
}
