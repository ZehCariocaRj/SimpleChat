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
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.RegisterModel register;

        public RegisterViewModel()
        {
            register = new Models.RegisterModel();
        }

        public string ErrorMessage
        {
            get
            {
                return register.ErrorMessage;
            }
            set
            {
                register.ErrorMessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }

        public string Username
        {
            get
            {
                return register.Username;
            }
            set
            {
                register.Username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public string Password
        {
            get
            {
                return register.Password;
            }
            set
            {
                register.Password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public string PasswordConfirm
        {
            get
            {
                return register.PasswordConfirm;
            }
            set
            {
                register.PasswordConfirm = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PasswordConfirm"));
            }
        }

        public string Email
        {
            get
            {
                return register.Email;
            }
            set
            {
                register.Email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string DisplayName
        {
            get
            {
                return register.DisplayName;
            }
            set
            {
                register.DisplayName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayName"));
            }
        }

        public ICommand PerformRegisterCommand
        {
            get
            {
                return new DelegateCommand(PerformRegister);
            }
        }

        private void PerformRegister()
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

            if (PasswordConfirm == null)
            {
                ErrorMessage = "Please enter password confirmation";
                return;
            }

            if (Email == null)
            {
                ErrorMessage = "Please enter email";
                return;
            }
            
            if (Password != PasswordConfirm)
            {
                ErrorMessage = "Password does not match";
                return;
            }

            try
            {
                // Continue with registration process
                if(AccountManager.RegisterUser(Username, Password, Email, DisplayName))
                {
                    // Get out of registration screen now that we're registered
                    ViewPresenter.PopView();

                    if (AccountManager.LoginUser(Username, Password))
                    {
                        // If the post-registration login was successful, automatically move to the friend list
                        ViewPresenter.PushView(new Views.FriendListView());
                    }
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
