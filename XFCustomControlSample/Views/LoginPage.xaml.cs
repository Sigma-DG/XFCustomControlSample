using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCustomControlSample.ViewModels;

namespace XFCustomControlSample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginViewModel ViewModel {
            get {
                if (this.BindingContext == null) return null;

                return (LoginViewModel)this.BindingContext;
            }
        }

        public LoginPage ()
		{
			InitializeComponent();

            if(ViewModel != null)
            {
                ViewModel.OnLoginSuccessfulPageChange += (reason) => 
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        await Navigation.PushAsync(((App)App.Current).RootView);
                    });
                };
            }
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.OnAppeared();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel?.OnDisappeared();
        }
    }
}