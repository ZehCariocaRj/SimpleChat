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
    class FriendListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.FriendListModel friendList;

        public FriendListViewModel()
        {
            friendList = new Models.FriendListModel();
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

        public ICommand DeleteFriendCommand
        {
            get
            {
                return new DelegateCommand(DeleteFriend);
            }
        }

        private void DeleteFriend()
        {
            if (_friendList != null && _friendList.SelectedItem != null)
            {
                Views.FriendListEntry friend = (Views.FriendListEntry)_friendList.SelectedItem;
                AccountManager.DeleteFriend(friend.UserId);

                UpdateFriendList();
            }
        }

        public ICommand AddFriendCommand
        {
            get
            {
                return new DelegateCommand(AddFriend);
            }
        }

        private void AddFriend()
        {
            if (_friendList != null)
            {
                var addFriendDialog = new Views.AddFriendDialog();
                var res = addFriendDialog.ShowDialog();

                UpdateFriendList();
            }
        }

        ListBox _friendList;
        public void SetListBox(ListBox friendList)
        {
            _friendList = friendList;
        }

        internal void UpdateFriendList()
        {
            if (_friendList != null)
            {
                _friendList.Items.Clear();

                var friends = AccountManager.GetFriendList();
                for (int i = 0; i < friends.Count; i++)
                {
                    var friend = new Views.FriendListEntry(friends[i].Id.Value, friends[i].DisplayName, friends[i].Username);
                    friend.MouseDoubleClick += Friend_MouseDoubleClick;
                    _friendList.Items.Add(friend);
                }
            }
        }

        private void Friend_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Open chat window");
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
    }
}
