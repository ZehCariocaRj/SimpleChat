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
    class OptionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.OptionsModel options;

        public OptionsViewModel()
        {
            options = new Models.OptionsModel();     
        }

        public void PopulateOptions()
        {
            var am = AccountManager.GetInstance();
            DisplayName = am.DisplayName;
            Username = am.Username;
            Email = am.Email;
        }

        public string ErrorMessage
        {
            get
            {
                return options.ErrorMessage;
            }
            set
            {
                options.ErrorMessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }

        public string DisplayName
        {
            get
            {
                return options.DisplayName;
            }
            set
            {
                options.DisplayName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayName"));
            }
        }

        public string Username
        {
            get
            {
                return options.Username;
            }
            set
            {
                options.Username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public string Password
        {
            get
            {
                return options.Password;
            }
            set
            {
                options.Password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public string PasswordConfirm
        {
            get
            {
                return options.PasswordConfirm;
            }
            set
            {
                options.PasswordConfirm = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PasswordConfirm"));
            }
        }

        public string Email
        {
            get
            {
                return options.Email;
            }
            set
            {
                options.Email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
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

        public ICommand PerformSaveCommand
        {
            get
            {
                return new DelegateCommand(PerformSave);
            }
        }

        private void PerformSave()
        {
            ErrorMessage = "";

            var am = AccountManager.GetInstance();

            bool usernameChanged = Username != am.Username;
            bool passwordChanged = Password != "" && Password == PasswordConfirm && Password == am.Password;
            bool emailChanged = Email != am.Email;
            bool displayNameChanged = DisplayName != am.DisplayName;

            try
            {
                // Continue with registration process
                DefaultApi api = new DefaultApi("http://localhost:8080/api/");

                bool ret = false;
                ret = AccountManager.UpdateUser(AccountManager.GetInstance().Token, 
                    usernameChanged ? Username : null,
                    passwordChanged ? Password : null,
                    emailChanged ? Email : null,
                    displayNameChanged ? DisplayName : null);

                if (ret)
                {
                    // Get out of registration screen now that we're registered
                    ViewPresenter.PopView();
                }
            }
            catch (ApiException e)
            {
                var error = ErrorCodes.TranslateError(e.ErrorContent);
                ErrorMessage = error.Message;
            }
        }
        
        public ICommand GoBackViewCommand
        {
            get
            {
                return new DelegateCommand(GoBackView);
            }
        }

        private void GoBackView()
        {
            ViewModels.ViewPresenter.PopView();
        }
    }
}
