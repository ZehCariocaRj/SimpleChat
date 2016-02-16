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
    public partial class ChatListEntry : UserControl
    {
        public ChatListEntry()
        {
            InitializeComponent();
        }

        public int ChatId = -1;
        public ChatListEntry(int id, string chatTitle, string lastMessage)
        {
            InitializeComponent();
            ChatId = id;
            ChatTitle.Text = chatTitle;
            LastMessage.Text = lastMessage;
        }
    }
}
