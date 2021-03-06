﻿using Library.Models;
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
    /// Логика взаимодействия для NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        NewBookViewModel newBookViewModel;
        public NewUser(ref Reader reader)
        {
            InitializeComponent();
            newBookViewModel = new NewBookViewModel(reader);
            DataContext = newBookViewModel;
            newBookViewModel.Closing += (s, e) => Close();
        }

        
    }
}
