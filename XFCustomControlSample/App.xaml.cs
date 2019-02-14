using Common.Contracts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCustomControlSample.Proxy;
using XFCustomControlSample.Views;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XFCustomControlSample
{
	public partial class App : Application
	{
        public event VoidEventHandler OnMinuteCount;

        public NavigationPage RootView { get; set; }
        public NavigationPage TileListView { get; set; }

        public App()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            RootView = new NavigationPage(new MainPage());
            TileListView = new NavigationPage(new TileListPage());

            NotificationKernel.Current.OnMinuteTicked += MinuteTick;
        }

        private void MinuteTick()
        {
            OnMinuteCount?.Invoke();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
