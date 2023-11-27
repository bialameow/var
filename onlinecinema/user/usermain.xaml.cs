﻿using System;
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

namespace onlinecinema.user
{
    /// <summary>
    /// Логика взаимодействия для usermain.xaml
    /// </summary>
    public partial class usermain : Window
    {

        public usermain()
        {
            InitializeComponent();
            dgmovie.ItemsSource = onlinecinemaEntities.GetContext().Movies.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}
