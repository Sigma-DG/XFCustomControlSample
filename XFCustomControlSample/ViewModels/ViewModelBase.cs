using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XFCustomControlSample.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set {
                _statusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }
        
        public abstract void OnAppeared();

        public abstract void OnDisappeared();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
