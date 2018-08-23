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
	public partial class TileListPage : ContentPage
	{
        private ImageListViewmodel ViewModel { get; set; }

        public TileListPage ()
		{
			InitializeComponent ();
            this.BindingContext = ViewModel = new ImageListViewmodel();
            ViewModel.PropertyChanged += ImageListChanged;
        }

        private void ImageListChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Images"))
            {
                this.flexLayout.Children.Clear();
                foreach (var image in ViewModel.Images)
                {
                    flexLayout.Children.Add(new Image{
                        Source = image
                    });
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.OnAppeared();
        }
    }
}