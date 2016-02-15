using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    }
}
