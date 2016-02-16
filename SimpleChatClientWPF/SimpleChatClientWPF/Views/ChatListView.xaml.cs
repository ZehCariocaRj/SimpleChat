using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IO.Swagger.Client;

namespace SimpleChatClientWPF.Views
{
    /// <summary>
    /// Interaction logic for ChatListView.xaml
    /// </summary>
    public partial class ChatListView : UserControl
    {
        ViewModels.ChatListViewModel chatListViewModel;
        public ChatListView()
        {
            InitializeComponent();

            chatListViewModel = new ViewModels.ChatListViewModel();
            chatListViewModel.SetListBox(ChatList);
            DataContext = chatListViewModel;

            Loaded += ChatListView_Loaded;
        }

        private void ChatListView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            chatListViewModel.UpdateProfile();
            chatListViewModel.UpdateChatList();
        }

        private void ChatList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Views.ChatListEntry entry = (Views.ChatListEntry)ChatList.SelectedItem;
                chatListViewModel.OpenChat(entry.ChatId);
            }
        }
    }
}
