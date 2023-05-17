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

namespace kursachproj
{
    /// <summary>
    /// Логика взаимодействия для Createacc.xaml
    /// </summary>
    public partial class Createacc : Page
    {
        public Createacc()
        {
            InitializeComponent();
        }
        private void BtnRegIn_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model0db.User.Count(x => x.Login == Login.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User userObj = new User()
                {
                    Login = Login.Text,
                    Name = Name.Text,
                    Password = Password.Text,
                    IdRole = 2
                };
                AppConnect.model0db.User.Add(userObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFr.frameMain.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFr.frameMain.GoBack();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPass.Password != Password.Text)
            {
                btnRegIn.IsEnabled = false;
                psbPass.Background = Brushes.LightCoral;
                psbPass.BorderBrush = Brushes.Red;
            }
            else
            {
                btnRegIn.IsEnabled = true;
                psbPass.Background = Brushes.LightGreen;
                psbPass.BorderBrush = Brushes.Green;
            }
        }
    }
}
