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
	public partial class ExpandableListPage : ContentPage
	{
        public ExpandableItemsViewModel ViewModel
        {
            get
            {
                if (this.BindingContext == null || !(this.BindingContext is ExpandableItemsViewModel)) return null;
                return (ExpandableItemsViewModel)this.BindingContext;
            }
        }

        public ExpandableListPage ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.ViewModel?.OnAppeared();
        }
    }
}