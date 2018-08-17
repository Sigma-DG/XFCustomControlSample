using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCustomControlSample.Views;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XFCustomControlSample
{
	public partial class App : Application
	{
        public MainPage RootView { get; set; }

        public App ()
		{
			InitializeComponent();

            MainPage = new LoginPage();
            RootView = new MainPage();
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
