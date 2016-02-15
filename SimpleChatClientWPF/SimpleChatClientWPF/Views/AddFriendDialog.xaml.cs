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
using IO.Swagger.Client;

namespace SimpleChatClientWPF.Views
{
    /// <summary>
    /// Interaction logic for AddFriendDialog.xaml
    /// </summary>
    public partial class AddFriendDialog : Window
    {
        public AddFriendDialog()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            try
            {
                var friend = AccountManager.AddFriend(UsernameInput.Text);
                success = friend != null;
            }
            catch (ApiException error)
            {
                var error2 = ErrorCodes.TranslateError(error.ErrorContent);
                ErrorMessage.Text = error2.Message;
                ErrorMessage.Foreground = Brushes.Red;
                success = false;
            }

            if (success)
            {
                DialogResult = true;
                Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
