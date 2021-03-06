﻿using System;
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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        RegisterViewModel viewModel;
        public RegisterView()
        {
            InitializeComponent();

            viewModel = new RegisterViewModel();
            DataContext = viewModel;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.Password = Marshal.PtrToStringAuto(Marshal.SecureStringToGlobalAllocUnicode(Password.SecurePassword));
        }

        private void Password_PasswordConfirmChanged(object sender, RoutedEventArgs e)
        {
            viewModel.PasswordConfirm = Marshal.PtrToStringAuto(Marshal.SecureStringToGlobalAllocUnicode(PasswordConfirm.SecurePassword));
        }
    }
}
