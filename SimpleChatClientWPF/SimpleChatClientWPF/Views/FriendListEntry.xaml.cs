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

namespace SimpleChatClientWPF.Views
{
    /// <summary>
    /// Interaction logic for FriendListEntry.xaml
    /// </summary>
    public partial class FriendListEntry : UserControl
    {
        public FriendListEntry()
        {
            InitializeComponent();
        }

        public int UserId = -1;
        public FriendListEntry(int id, string displayName, string username)
        {
            InitializeComponent();
            UserId = id;
            DisplayName.Text = displayName;
            Username.Text = username;
        }
    }
}
