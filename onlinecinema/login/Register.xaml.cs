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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btn_back(object sender, RoutedEventArgs e)
        {
            FrameP.frameMain.GoBack();
        }

        private void btn_reg(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tblog.Text) || string.IsNullOrWhiteSpace(tbpass.Password))
                    MessageBox.Show("Введите данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    User userObj = new User()
                    {
                        username = tblog.Text,
                        pass = tbpass.Password,
                        usrole = 2
                    };


                    onlinecinemaEntities.GetContext().Users.Add(userObj);
                    onlinecinemaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Вы зарегистрированы!", "Успешно",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            catch
            {
                MessageBox.Show("Не получилось зарегистрироваться!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
