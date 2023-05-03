using BookFind.Core;
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

namespace BookFind
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppData.MainFrame = Frame;

            Home.IsChecked = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RowDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Settings_Checked(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Views.AccountPage());
        }

        private void Account_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Home_Checked(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Views.DatabaseView());

            // Frame frame = new Views.DatabaseView();
            // ContentControl.Content = new Views.DatabaseView();
        }
    }
}
