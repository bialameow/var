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

namespace onlinecinema.admin
{
    /// <summary>
    /// Логика взаимодействия для MovieWin.xaml
    /// </summary>
    public partial class MovieWin : Window
    {
        public Movie Movie { get; private set; }
        public MovieWin(Movie movie)
        {
            InitializeComponent();
            Movie = movie;
            DataContext = Movie;

            List<Genre> genres = onlinecinemaEntities.GetContext().Genres.ToList();
            cmbgenre.ItemsSource = genres;
            cmbgenre.DisplayMemberPath = "genrename";
            cmbgenre.SelectedValuePath = "id_genre";
            List<Director> directors = onlinecinemaEntities.GetContext().Directors.ToList();
            cmbdir.ItemsSource = directors;
            cmbdir.DisplayMemberPath = "dirname";
            cmbdir.SelectedValuePath = "id_dir";

            //cmbgenre.ItemsSource = onlinecinemaEntities.GetContext().Genres.ToList();
            //cmbdir.ItemsSource = onlinecinemaEntities.GetContext().Directors.ToList();

        }



        private void btn_close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_add(object sender, RoutedEventArgs e)
        {

            if (tbmovie.Text == "")
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
