using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SimpleChatClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AccountManager.GetInstance(); // Force the login manager to load the current stored login information if available
        }

        private void MainWindow_OnLoad(object sender, RoutedEventArgs e)
        {
            DataContext = ViewModels.ViewPresenter.GetInstance();
            ViewModels.ViewPresenter.PushView(new Views.LoginView());
        }
    }
}
