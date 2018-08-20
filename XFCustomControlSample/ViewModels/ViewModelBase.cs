using System.ComponentModel;
using System.Threading;

namespace XFCustomControlSample.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected CancellationTokenSource PageCancellationTokenSource { get; private set; } = new CancellationTokenSource();

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

        public virtual void OnDisappeared()
        {
            CancelRequests();
        }

        public void CancelRequests()
        {
            PageCancellationTokenSource.Cancel();
            PageCancellationTokenSource = new CancellationTokenSource();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
