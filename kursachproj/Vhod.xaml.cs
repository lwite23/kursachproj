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
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Page
    {
        public Vhod()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model0db.User.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    switch (userObj.IdRole)
                    {

                        case 1:
                            MessageBox.Show("Здраствуйте, Администратор " + userObj.Name + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                            mainWindow.Show();
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Покупатель " + userObj.Name + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            mainWindow.Show();
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            AppFr.frameMain.Navigate(new Createacc());
        }
    }
}
