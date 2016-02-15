using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using SimpleChatClientWPF.ViewModels;

namespace SimpleChatClientWPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        LoginViewModel viewModel;
        public LoginView()
        {
            InitializeComponent();
            
            viewModel = new LoginViewModel();
            DataContext = viewModel;

            Loaded += LoginView_OnLoaded;
        }

        private void LoginView_OnLoaded(object sender, RoutedEventArgs e)
        {
            viewModel.PopulateAccountInfo();
            Password.Password = viewModel.Password;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.Password = Marshal.PtrToStringAuto(Marshal.SecureStringToGlobalAllocUnicode(Password.SecurePassword));
        }
    }
}
