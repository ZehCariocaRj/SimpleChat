using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for FriendListView.xaml
    /// </summary>
    public partial class FriendListView : UserControl
    {
        ViewModels.FriendListViewModel friendListViewModel;
        public FriendListView()
        {
            InitializeComponent();

            friendListViewModel = new ViewModels.FriendListViewModel();
            friendListViewModel.SetListBox(FriendList);
            DataContext = friendListViewModel;

            Loaded += FriendListView_Loaded;
        }

        private void FriendListView_Loaded(object sender, RoutedEventArgs e)
        {
            friendListViewModel.UpdateProfile();
            friendListViewModel.UpdateFriendList();
        }

        private void FriendList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Views.FriendListEntry entry = (Views.FriendListEntry)FriendList.SelectedItem;
                //friendListViewModel.OpenChat(entry.UserId);
            }
        }
    }
}
