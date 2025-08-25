using BLL.Service;
using DAL.Entities;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Shapes;

namespace MiniMartHub
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private AccountService _accountService;
        public LoginWindow()
        {
            InitializeComponent();
            _accountService = new ();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (email.IsNullOrEmpty())
            {
                MessageBox.Show("Email is required", "Field is required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string password = txtPassword.Password.Trim();
            if (password.IsNullOrEmpty())
            {
                MessageBox.Show("Password is required", "Field is required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Account? account = _accountService.GetAccount(email, password);
            if(account == null)
            {
                MessageBox.Show("Invalid Email Or Password", "Invalid Field", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
