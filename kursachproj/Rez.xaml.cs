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
    /// Логика взаимодействия для Rez.xaml
    /// </summary>
    public partial class Rez : Page
    {
        public Rez()
        {
            InitializeComponent();
            var currentCars = qweEntities1.GetContext().rez.ToList();

            DGridRez.ItemsSource = currentCars;


        }

        private void Updaterez()
        {
            var currentCars = qweEntities1.GetContext().rez.ToList();

            currentCars = currentCars.Where(p => p.fullname.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            DGridRez.ItemsSource = currentCars;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manage.MaimFrame.Navigate(new edit(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            manage.MaimFrame.Navigate(new edit((sender as Button).DataContext as rez));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            manage.MaimFrame.Navigate(new edit(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = DGridRez.SelectedItems.Cast<rez>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    qweEntities1.GetContext().rez.RemoveRange(productForRemoving);
                    qweEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridRez.ItemsSource = qweEntities1.GetContext().rez.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                qweEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridRez.ItemsSource = qweEntities1.GetContext().rez.ToList();
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Updaterez();
        }
    }
}
