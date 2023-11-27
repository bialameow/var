using onlinecinema.admin;
using onlinecinema.user;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace onlinecinema.login
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    /// 
    public partial class Log : Page
    {

        public Log()
        {
            InitializeComponent();
        }

        private void btn_regi(object sender, RoutedEventArgs e)
        {
            FrameP.frameMain.Navigate(new Register());
        }

        private void btn_log(object sender, RoutedEventArgs e)
        {
            string login = tblog.Text.Trim();
            string pass = tbpass.Password.Trim();

            User authUser = null;
            authUser = onlinecinemaEntities.GetContext().Users.Where(b => b.username == login && b.pass == pass).FirstOrDefault();
            if (authUser == null)
            {
                MessageBox.Show("Пользователя не существует!", "Кинотеатр",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (authUser.usrole == 1)
            {
                adminmain admin = new adminmain();
                admin.Show();
                Application.Current.MainWindow.Close();
            }

            if (authUser.usrole == 2)
            {
                usermain user = new usermain();
                user.Show();
                Application.Current.MainWindow.Close();
            }
        }
    }
}
