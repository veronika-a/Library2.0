using Library.ViewModels;
using System;
using System.Windows;

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
