﻿using Library.ViewModels;
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

        SingInViewModel singInViewModel = new SingInViewModel();
        public SingIn()
        {
            InitializeComponent();
            DataContext = new SingInViewModel();

            singInViewModel.Closing += (s, e) => this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CabinetReader cabinetReader = new CabinetReader();
            this.Close();
        }
    }
}
