using Microsoft.Win32;
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
using System.IO;
using System.Data.SqlClient;
using System.Drawing;

using System.Data;

namespace kursachproj
{
    /// <summary>
    /// Логика взаимодействия для edit.xaml
    /// </summary>
    public partial class edit : Page
    {
        byte[] imageData;
        private rez _currentqwe = new rez();
        public edit(rez selectedqwe)
        {
            InitializeComponent();

            if (selectedqwe != null)
                _currentqwe = selectedqwe;

            DataContext = _currentqwe;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentqwe.fullname))
                errors.AppendLine("Укажите ФИО.");
           
            if (string.IsNullOrWhiteSpace(_currentqwe.education))
                errors.AppendLine("Укажите образование.");
            if (string.IsNullOrWhiteSpace(_currentqwe.experience))
                errors.AppendLine("Укажите опыт работы.");
            if (string.IsNullOrWhiteSpace(_currentqwe.post))
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
            if (_currentqwe.id == 0)
                qweEntities1.GetContext().rez.Add(_currentqwe);

            try
            {
                qweEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }
        private void MouseLeftButtonUp_Click(object sender, MouseButtonEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image (*.png, *.jpg, *.jpeg) |*.png; *.jpg; *.jpeg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                imageData = File.ReadAllBytes(openFileDialog.FileName);
                PhotoService.Source = new ImageSourceConverter()
                    .ConvertFrom(imageData) as ImageSource;
                _currentqwe.photo = imageData;
            }


        }
        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
