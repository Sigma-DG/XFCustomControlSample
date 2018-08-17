using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFCustomControlSample.Common;
using XFCustomControlSample.Common.Models;
using XFCustomControlSample.Proxy.Services;

namespace XFCustomControlSample.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }

        public event PageChangeEventHandler OnLoginSuccessfulPageChange;

        public LoginCredentials Credentials { get; private set; } = new LoginCredentials();

        private string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        
        public string Username
        {
            get { return Credentials.Username; }
            set {
                Credentials.Username = value;
                OnPropertyChanged("Username");
            }
        }
        
        public string Password
        {
            get { return Credentials.Password; }
            set
            {
                Credentials.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(
                async () => {
                    Message = string.Empty;
                    using (var loginSvr = new LoginService())
                    {
                        StatusMessage = "Logging in..";
                        IsLoading = true;
                        var res = await loginSvr.Login(Credentials);
                        StatusMessage = "Logged in successfully";
                        IsLoading = false;
                        if (res.IsSucceeded)
                            OnLoginSuccessfulPageChange?.Invoke(StatusMessage);
                        else Message = res.Message;
                    }
                }, 
                () => {
                    return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
                });

            ResetCommand = new Command(
                () => {
                    Username = Password = string.Empty;
                });
        }

        public override void OnAppeared()
        {
            
        }

        public override void OnDisappeared()
        {
            
        }
        
        public new void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (LoginCommand != null)
                ((Command)LoginCommand).ChangeCanExecute();
        }
    }
}
