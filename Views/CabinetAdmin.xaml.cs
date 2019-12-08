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
    /// Логика взаимодействия для CabinetAdmin.xaml
    /// </summary>
    public partial class CabinetAdmin : Window
    {
        CabinetAdminViewModel cabinet;

        public CabinetAdmin(ref Reader reader)
        {
            InitializeComponent();

            cabinet = new CabinetAdminViewModel(reader);
            DataContext = cabinet;
            cabinet.Closing += (s, e) => Close();
        }

        private void Button_CalalogReaders(object sender, RoutedEventArgs e)
        {
            CatalogReaders catalogReaders = new CatalogReaders();
            this.Close();
            catalogReaders.Show();
        }
    }
}
