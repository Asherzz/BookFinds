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
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : UserControl
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var product = this.DataContext as Product;

            string error = "";
            if (string.IsNullOrWhiteSpace(product.Title))
                error += "Вы не ввели название\n";

            Cos.Text = Cos.Text.Trim();
            Cos.Text = Cos.Text.Replace('.', ',');

            if (!decimal.TryParse(Cos.Text, out decimal a))
                error += "Вы не ввели цену\n";

            if (product.Product1 == null)
                error += "Вы не создали продукт\n";

            if (!string.IsNullOrWhiteSpace(error))
                MessageBox.Show(error, "123");
            else
            {
                if (product.ID == 0)
                    AppData.Context.Product.Add(product);
                AppData.Context.SaveChanges();
            }
        }

    }
}

