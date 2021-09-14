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
using System.Windows.Media.Animation;
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
        MainWindowViewModel DataContext;
        public MainWindow()
        {
            
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            DataContext.Closing += (s, e) => Close();

            //// анимация для ширины
            //DoubleAnimation widthAnimation = new DoubleAnimation();
            //widthAnimation.From = helloButton.ActualWidth;
            //widthAnimation.To = 250;
            //widthAnimation.Duration = TimeSpan.FromSeconds(5);
            
            //// анимация для высоты
            //DoubleAnimation heightAnimation = new DoubleAnimation();
            //heightAnimation.From = helloButton.ActualHeight;
            //heightAnimation.To = 40;
            //heightAnimation.Duration = TimeSpan.FromSeconds(5);

            //helloButton.BeginAnimation(Button.WidthProperty, widthAnimation);
            //helloButton.BeginAnimation(Button.HeightProperty, heightAnimation);


        }
        private void ButtonAnimation_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Анимация завершена");
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
