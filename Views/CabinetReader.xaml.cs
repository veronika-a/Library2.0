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
    /// Логика взаимодействия для CabinetReader.xaml
    /// </summary>
    public partial class CabinetReader : Window
    {

        CabinetReaderViewModel cabinet;
        public CabinetReader()
        {
            InitializeComponent();
           
        }

        public CabinetReader(ref Reader reader)
        {
            InitializeComponent();

            cabinet= new CabinetReaderViewModel(reader);
            DataContext = cabinet;
            cabinet.Closing += (s, e) => Close();
        }

        //private void Button_MyBooks(object sender, RoutedEventArgs e)
        //{

        //    BooksReader booksReader = new BooksReader(reader);
        //    this.Close();
        //    booksReader.Show();
        //}

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
