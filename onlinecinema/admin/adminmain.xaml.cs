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
    /// Логика взаимодействия для adminmain.xaml
    /// </summary>
    public partial class adminmain : Window
    {
        public adminmain()
        {

            InitializeComponent();
            dggenre.ItemsSource = onlinecinemaEntities.GetContext().Genres.ToList();
            dgdir.ItemsSource = onlinecinemaEntities.GetContext().Directors.ToList();
            dgmovie.ItemsSource = onlinecinemaEntities.GetContext().Movies.ToList();
            dgusers.ItemsSource = onlinecinemaEntities.GetContext().Users.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void RefreshGenre()
        {
            dggenre.ItemsSource = onlinecinemaEntities.GetContext().Genres.ToList();
        }

        private void RefreshDir()
        {
            dgdir.ItemsSource = onlinecinemaEntities.GetContext().Directors.ToList();
        }

        private void RefreshMovie()
        {
            dgmovie.ItemsSource = onlinecinemaEntities.GetContext().Movies.ToList();
        }

        private void genreadd(object sender, RoutedEventArgs e)
        {
            GenreWin genrewindow = new GenreWin(new Genre());
            if (genrewindow.ShowDialog() == true)
            {
                Genre Genre = genrewindow.Genre;
                onlinecinemaEntities.GetContext().Genres.Add(Genre);
                onlinecinemaEntities.GetContext().SaveChanges();

                RefreshGenre();
            }
        }

        private void genreedit(object sender, RoutedEventArgs e)
        {
            if (!(dggenre.SelectedItem is Genre genre)) return;

            GenreWin genrewindow = new GenreWin(new Genre
            {
                id_genre = genre.id_genre,
                genrename = genre.genrename
            });

            if (genrewindow.ShowDialog() == true)
            {
                // получаем измененный объект
                genre = onlinecinemaEntities.GetContext().Genres.Find(genrewindow.Genre.id_genre);
                if (genre != null)
                {
                    genre.genrename = genrewindow.Genre.genrename;
                    onlinecinemaEntities.GetContext().SaveChanges();
                    RefreshGenre();
                }
            }
        }

        private void diradd(object sender, RoutedEventArgs e)
        {
            DirWin dirwindow = new DirWin(new Director());
            if (dirwindow.ShowDialog() == true)
            {
                Director Director = dirwindow.Director;
                onlinecinemaEntities.GetContext().Directors.Add(Director);
                onlinecinemaEntities.GetContext().SaveChanges();

                RefreshDir();
            }
        }

        private void diredit(object sender, RoutedEventArgs e)
        {
            if (!(dgdir.SelectedItem is Director director)) return;

            DirWin dirwindow = new DirWin(new Director
            {
                id_dir = director.id_dir,
                dirname = director.dirname
            });

            if (dirwindow.ShowDialog() == true)
            {
                // получаем измененный объект
                director = onlinecinemaEntities.GetContext().Directors.Find(dirwindow.Director.id_dir);
                if (director != null)
                {
                    director.dirname = dirwindow.Director.dirname;
                    onlinecinemaEntities.GetContext().SaveChanges();
                    RefreshDir();
                }
            }
        }





        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void delgenre(object sender, RoutedEventArgs e)
        {
            if (!(dggenre.SelectedItem is Genre genre)) return;
            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотите удалить жанр " + genre.genrename + "?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                onlinecinemaEntities.GetContext().Genres.Remove(genre);
                onlinecinemaEntities.GetContext().SaveChanges();
                RefreshGenre();
            }
        }

        private void deldir(object sender, RoutedEventArgs e)
        {
            if (!(dgdir.SelectedItem is Director director)) return;
            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотите удалить режиссера " + director.dirname + "?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                onlinecinemaEntities.GetContext().Directors.Remove(director);
                onlinecinemaEntities.GetContext().SaveChanges();
                RefreshDir();
            }
        }


        private void movieadd(object sender, RoutedEventArgs e)
        {
            MovieWin mwindow = new MovieWin(new Movie());
            if (mwindow.ShowDialog() == true)
            {
                Movie Movie = mwindow.Movie;
                onlinecinemaEntities.GetContext().Movies.Add(Movie);
                onlinecinemaEntities.GetContext().SaveChanges();

                RefreshMovie();
            }
        }

        private void movieedit(object sender, RoutedEventArgs e)
        {
            if (!(dgmovie.SelectedItem is Movie movie)) return;

            MovieWin mwindow = new MovieWin(new Movie
            {
                id_movie = movie.id_movie,
                moviename = movie.moviename,
                genrem = movie.genrem,
                release = movie.release,
                dir = movie.dir,
                descriptionm = movie.descriptionm
            });

            if (mwindow.ShowDialog() == true)
            {
                // получаем измененный объект
                movie = onlinecinemaEntities.GetContext().Movies.Find(mwindow.Movie.id_movie);
                if (movie != null)
                {
                    movie.moviename = mwindow.Movie.moviename;
                    movie.genrem = mwindow.Movie.genrem;
                    movie.release = mwindow.Movie.release;
                    movie.dir = mwindow.Movie.dir;
                    movie.descriptionm = mwindow.Movie.descriptionm;
                    onlinecinemaEntities.GetContext().SaveChanges();
                    RefreshMovie();
                }
            }
        }

        private void delmovie(object sender, RoutedEventArgs e)
        {
            if (!(dgmovie.SelectedItem is Movie movie)) return;
            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотите удалить фильм " + movie.moviename + "?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                onlinecinemaEntities.GetContext().Movies.Remove(movie);
                onlinecinemaEntities.GetContext().SaveChanges();
                RefreshMovie();
            }
        }
    }
}
