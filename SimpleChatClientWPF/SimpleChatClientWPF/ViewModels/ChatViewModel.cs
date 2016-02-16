using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace SimpleChatClientWPF.ViewModels
{
    class ChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.ChatModel chat;

        public ChatViewModel()
        {
            chat = new Models.ChatModel();
            ChatId = -1;
        }

        public ChatViewModel(int chatId)
        {
            chat = new Models.ChatModel();
            ChatId = chatId;
        }

        public void PopulateChat()
        {
            UpdateChat();
        }

        private void UpdateChat()
        {
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            AccountManager lm = AccountManager.GetInstance();

            var chatInfo = AccountManager.GetChatInfo(ChatId);
            var chatMessages = AccountManager.GetChatMessages(ChatId);

            ChatTitle = chatInfo.ChatTitle;
            ChatId = chatInfo.Id.Value;

            string chatLog = "";
            foreach(var message in chatMessages)
            {
                var profile = AccountManager.GetProfileById(message.UserId.Value);
                var displayName = profile.DisplayName;
                chatLog += String.Format("[{0}] {1}: {2}", message.Timestamp, displayName, message._Message) + Environment.NewLine;
            }
            ChatLog = chatLog;

            if(_chatScrollViewer != null)
            {
                _chatScrollViewer.ScrollToBottom();
            }

            if (_chatlist != null)
            {
                _chatlist.Items.Clear();
                foreach (var userId in chatInfo.Users)
                {
                    var profile = AccountManager.GetProfileById(userId.Value);
                    Views.FriendListEntry entry = new Views.FriendListEntry(userId.Value, profile.DisplayName, profile.Username);
                    _chatlist.Items.Add(entry);
                }
            }
        }

        ItemsControl _chatlist;
        public void SetListBox(ItemsControl chatList)
        {
            _chatlist = chatList;
        }

        ScrollViewer _chatScrollViewer;
        public void SetScrollViewer(ScrollViewer chatScrollviewer)
        {
            _chatScrollViewer = chatScrollviewer;
        }

        public List<Views.FriendListEntry> Participants
        {
            get
            {
                return chat.Participants;
            }
            set
            {
                chat.Participants = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Participants"));
            }
        }

        public int ChatId
        {
            get
            {
                return chat.ChatId;
            }
            set
            {
                chat.ChatId = value;
            }
        }

        public string ChatText
        {
            get
            {
                return chat.ChatText;
            }
            set
            {
                chat.ChatText = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ChatText"));
            }
        }

        public string ChatLog
        {
            get
            {
                return chat.ChatLog;
            }
            set
            {
                chat.ChatLog = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ChatLog"));
            }
        }

        public string ChatTitle
        {
            get
            {
                return chat.ChatTitle;
            }
            set
            {
                chat.ChatTitle = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ChatTitle"));
            }
        }

        public ICommand SetChatTitleCommand
        {
            get
            {
                return new DelegateCommand(SetChatTitle);
            }
        }

        private void SetChatTitle()
        {
            var changeChatTitleDialog = new Views.ChangeChatTitleDialog(ChatId);
            var res = changeChatTitleDialog.ShowDialog();
        }

        public ICommand InviteChatCommand
        {
            get
            {
                return new DelegateCommand(InviteChat);
            }
        }

        private void InviteChat()
        {
            var inviteUserDialog = new Views.InviteUserDialog(ChatId);
            if(inviteUserDialog.ShowDialog() == true)
            {
                UpdateChat();
            }
        }

        public ICommand LeaveChatCommand
        {
            get
            {
                return new DelegateCommand(LeaveChat);
            }
        }

        private void LeaveChat()
        {
        }

        public ICommand SendChatCommand
        {
            get
            {
                return new DelegateCommand(SendChat);
            }
        }

        private void SendChat()
        {
            if (ChatText != null)
            {
                AccountManager.SendChatMessage(ChatId, ChatText);
                ChatText = "";
            }
        }
    }
}
