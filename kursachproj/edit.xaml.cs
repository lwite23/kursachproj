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
    /// Логика взаимодействия для edit.xaml
    /// </summary>
    public partial class edit : Page
    {
        private qwe _currentqwe = new qwe();
        public edit()
        {
            InitializeComponent();

            if (selectedqwe != null)
                _currentqwe = selectedqwe;

            DataContext = _currentqwe;
        }
    }
    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        StringBuilder errors = new StringBuilder();

        if (string.IsNullOrWhiteSpace(_currentqwe.fullname))
            errors.AppendLine("Укажите ФИО.");
        if (string.IsNullOrWhiteSpace(_currentqwe.yearOfBirth))
            errors.AppendLine("Укажите год рождения.);
        if (string.IsNullOrWhiteSpace(_currentqwe.education))
            errors.AppendLine("Укажите образование.");
        if (_currentqwe.experience == 0)
            errors.AppendLine("Укажите опыт работы.");
        if (_currentqwe.post == 0)
            errors.AppendLine("Укажите должность.");
        if (string.IsNullOrWhiteSpace(_currentqwe.citizenship))
            errors.AppendLine("Укажите гражданство.");
        if (string.IsNullOrWhiteSpace(_currentqwe.typeofemployment))
            errors.AppendLine("Укажите тип занятости.");

        if (errors.Length > 0)
        {
            MessageBox.Show(errors.ToString());
            return;
        }
        if (_currentqwe.Id == 0)
            qweEntities.GetContext().qwe.Add(_currentqwe);

        try
        {
            qweEntities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
}
