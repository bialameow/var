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

namespace onlinecinema.admin
{
    /// <summary>
    /// Логика взаимодействия для GenreWin.xaml
    /// </summary>
    public partial class GenreWin : Window
    {
        public Genre Genre { get; private set; }
        public GenreWin(Genre genre)
        {
            InitializeComponent();
            Genre = genre;
            DataContext = Genre;
        }

        

        private void btn_close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_add(object sender, RoutedEventArgs e)
        {

            if (tbgenre.Text == "")
            {
                MessageBox.Show("Поле пустое", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
                this.Close();
            }
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
