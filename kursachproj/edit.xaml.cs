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

        if (string.IsNullOrWhiteSpace(_currentqwe.Model))
            errors.AppendLine("Укажите модель машины");
        if (string.IsNullOrWhiteSpace(_currentqwe.Mark))
            errors.AppendLine("Укажите марку машины");
        if (string.IsNullOrWhiteSpace(_currentqwe.Color))
            errors.AppendLine("Укажите цвет машины");
        if (_currentqwe.BodyNumber == 0)
            errors.AppendLine("Укажите номер кузова машины");
        if (_currentqwe.PlateNumber == 0)
            errors.AppendLine("Укажите номер кузова машины");
        if (string.IsNullOrWhiteSpace(_currentqwe.TypeOfDrive))
            errors.AppendLine("Укажите цвет машины");
        if (string.IsNullOrWhiteSpace(_currentqwe.TransmissionType))
            errors.AppendLine("Укажите цвет машины");

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
