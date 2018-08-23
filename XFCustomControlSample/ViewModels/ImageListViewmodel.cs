using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCustomControlSample.Common.Models;
using XFCustomControlSample.Proxy.Services;

namespace XFCustomControlSample.ViewModels
{
    public class ImageListViewmodel : ViewModelBase
    {
        public ImageListViewmodel()
        {
            _images = new ObservableCollection<ImageSource>();
        }

        private ObservableCollection<ImageSource> _images;
        public ObservableCollection<ImageSource> Images
        {
            get { return _images; }
            set {
                _images = value;
                OnPropertyChanged("Images");
            }
        }
        
        public override void OnAppeared()
        {
            LoadBitmapCollection();
        }

        async Task LoadBitmapCollection()
        {
            int imageDimension = Device.RuntimePlatform == Device.iOS ||
                                 Device.RuntimePlatform == Device.Android ? 240 : 120;

            IsLoading = true;
            using (var pictureSvr = new PictureService())
            {
                StatusMessage = "Loading..";
                IsLoading = true;
                var res = await pictureSvr.GetAllPictures(imageDimension);
                IsLoading = false;
                if (res.IsSucceeded)
                {
                    StatusMessage = "Pictures loaded successfully";
                    Images = new ObservableCollection<ImageSource>(res.ReturnParam.Photos.Select((x)=> ImageSource.FromUri(new Uri(x))));
                }
                else StatusMessage = res.Message;
            }
        }
    }
}
