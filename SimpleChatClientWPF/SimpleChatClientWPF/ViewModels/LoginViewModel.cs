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
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.LoginModel login;

        public LoginViewModel()
        {
            login = new Models.LoginModel();
        }

        public void PopulateAccountInfo()
        {
            var lm = AccountManager.GetInstance(); // Force the login manager to load the current stored login information if available

            Username = lm.Username;
            Password = lm.Password;

            if(AutomaticSignIn)
            {
                PerformLogin();
            }
        }

        public string ErrorMessage
        {
            get
            {
                return login.ErrorMessage;
            }
            set
            {
                login.ErrorMessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }

        public string Username
        {
            get
            {
                return login.Username;
            }
            set
            {
                login.Username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public string Password
        {
            get
            {
                return login.Password;
            }
            set
            {
                login.Password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public bool AutomaticSignIn
        {
            get
            {
                return AccountManager.GetInstance().AutomaticSignIn;
            }
            set
            {
                AccountManager.GetInstance().AutomaticSignIn = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AutomaticSignIn"));
            }
        }

        public bool RememberPassword
        {
            get
            {
                return AccountManager.GetInstance().RememberPassword;
            }
            set
            {
                AccountManager.GetInstance().RememberPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RememberPassword"));
            }
        }

        public ICommand PerformLoginCommand
        {
            get
            {
                return new DelegateCommand(PerformLogin);
            }
        }

        private void PerformLogin()
        {
            ErrorMessage = "";

            if (Username == null)
            {
                ErrorMessage = "Please enter username";
                return;
            }

            if (Password == null)
            {
                ErrorMessage = "Please enter password";
                return;
            }

            try
            {
                if(AccountManager.LoginUser(Username, Password))
                {
                    // Login was successful, move to friend list
                    ViewPresenter.PushView(new Views.FriendListView());
                }
            }
            catch (ApiException e)
            {
                var error = ErrorCodes.TranslateError(e.ErrorContent);
                ErrorMessage = error.Message;
            }
        }

        public ICommand ChangeRegisterViewCommand
        {
            get
            {
                return new DelegateCommand(ChangeRegisterView);
            }
        }

        private void ChangeRegisterView()
        {
            ViewModels.ViewPresenter.PushView(new Views.RegisterView());
        }
    }
}
