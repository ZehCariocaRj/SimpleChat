using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace SimpleChatClientWPF.ViewModels
{
    class ChatListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.ChatListModel chatList;

        public ChatListViewModel()
        {
            chatList = new Models.ChatListModel();
        }

        internal void UpdateProfile()
        {
            // Force fields to be updated
            MyUsername = MyUsername;
            MyDisplayName = MyDisplayName;
        }

        public string MyUsername
        {
            get
            {
                return AccountManager.GetInstance().Username;
            }
            set
            {
                AccountManager.GetInstance().Username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyUsername"));
            }
        }

        public string MyDisplayName
        {
            get
            {
                return AccountManager.GetInstance().DisplayName;
            }
            set
            {
                AccountManager.GetInstance().DisplayName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MyDisplayName"));
            }
        }
        
        public ICommand CreateChatCommand
        {
            get
            {
                return new DelegateCommand(CreateChat);
            }
        }

        private void CreateChat()
        {
            if (_chatList != null)
            {
                var createChatDialog = new Views.CreateChatDialog();
                var res = createChatDialog.ShowDialog();

                UpdateChatList();
            }
        }

        ListBox _chatList;
        public void SetListBox(ListBox chatList)
        {
            _chatList = chatList;
        }

        internal void UpdateChatList()
        {
            if (_chatList != null)
            {
                _chatList.Items.Clear();

                var chats = AccountManager.GetChatList();
                for (int i = 0; i < chats.Count; i++)
                {
                    var chat = new Views.ChatListEntry(chats[i].Id.Value, chats[i].ChatTitle, "");
                    chat.MouseDoubleClick += Chat_MouseDoubleClick;
                    _chatList.Items.Add(chat);
                }
            }
        }

        public void OpenChat(int chatId)
        {
            Views.ChatView chatView = new Views.ChatView(chatId);
            chatView.Show();
            
            UpdateChatList();
        }

        private void Chat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Views.ChatListEntry entry = (Views.ChatListEntry)sender;
            OpenChat(entry.ChatId);
        }

        public ICommand OptionsViewCommand
        {
            get
            {
                return new DelegateCommand(OptionsView);
            }
        }

        private void OptionsView()
        {
            ViewPresenter.PushView(new Views.OptionsView());
        }

        public ICommand SignoutCommand
        {
            get
            {
                return new DelegateCommand(Signout);
            }
        }

        private void Signout()
        {
            AccountManager.Signout();
            ViewPresenter.PopView();
        }
    }
}
