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
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace SimpleChatClientWPF
{
    class ModelPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Stack<UserControl> viewModels;

        private ModelPresenter()
        {
            viewModels = new Stack<UserControl>();
        }

        static ModelPresenter presenter = null;
        public static ModelPresenter GetPresenter()
        {
            if (presenter == null)
            {
                presenter = new ModelPresenter();
            }

            return presenter;
        }

        public UserControl CurrentView
        {
            get
            {
                return viewModels.LastOrDefault();
            }
            set
            {
                if(value != null)
                {
                    viewModels.Push(value);
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentView"));
                }
            }
        }

        public static void PushView(UserControl view)
        {
            var presenter = GetPresenter();
            presenter.CurrentView = view;
        }

        public static UserControl PopView()
        {
            var presenter = GetPresenter();
            var top = presenter.viewModels.Pop();
            presenter.PropertyChanged(presenter, new PropertyChangedEventArgs("CurrentView"));
            return top;
        }

    }
}
