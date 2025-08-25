using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniMartHub
{
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void dgUserManagement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Gán UserControl vào MainContentControl
            MainContentControl.Content = new UserManagement();
        }

        private void dgProductManagement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Gán UserControl vào MainContentControl
            MainContentControl.Content = new ProductManagement();
        }
    }
}
