using BookFind.Core;
using BookFind.Model;
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

namespace BookFind.Views
{
    /// <summary>
    /// Логика взаимодействия для DatabaseView.xaml
    /// </summary>
    public partial class DatabaseView : UserControl
    {
        public DatabaseView()
        {
            InitializeComponent();
            lvBooks.ItemsSource = AppData.Context.Product.ToList();
            List<Manufacturer> IsActive = AppData.Context.Manufacturer.ToList();
            IsActive.Insert(0, new Manufacturer { Name = "Все категории" });
            CbFilter.ItemsSource = IsActive;
            CbSort.ItemsSource = new List<string>() { "По возрастанию", "По убыванию"};
            UpdateLvSource();
        }


        private void UpdateLvSource()
        {
            var products = AppData.Context.Product.ToList();
            if (CbFilter.SelectedIndex != 0)
                products = products.Where(p => p.ID == (CbFilter.SelectedItem as Manufacturer).ID).ToList();
            if (!string.IsNullOrWhiteSpace(Search.Text))
                products = products.Where(p => p.Title.ToLower().Trim().Contains(Search.Text.ToLower().Trim())).ToList();
            switch (CbSort.SelectedIndex)
            {

                case 0:
                    products = products.OrderBy(p => p.Title).ToList();
                    break;
                case 1:
                    products = products.OrderBy(p => p.Title).Reverse().ToList();
                    break;
            }
            lvBooks.ItemsSource = products;
        }

        private void LvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLvSource();
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLvSource();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLvSource();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Views.AddPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Views.EditPage());

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Context.Product.Remove((sender as Button).DataContext as Product);
                AppData.Context.SaveChanges();
            }
            lvBooks.ItemsSource = AppData.Context.Product.ToList();
        }
    }
}
