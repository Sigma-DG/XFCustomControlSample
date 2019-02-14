using Common.Contracts.Data;
using Common.Contracts.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace XFCustomControlSample.Proxy.Services
{
    public class PictureService : IPictureService, IDisposable
    {
        public void Dispose()
        {
            
        }

        public async Task<ResultPack<ImageList>> GetAllPictures(int imageDimension)
        {
            string urlSuffix = String.Format("?width={0}&height={0}&mode=max", imageDimension);

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    // Download the list of stock photos
                    Uri uri = new Uri("http://docs.xamarin.com/demo/stock.json");
                    byte[] data = await webClient.DownloadDataTaskAsync(uri);

                    ImageList imageList = null;
                    // Convert to a Stream object
                    using (Stream stream = new MemoryStream(data))
                    {
                        // Deserialize the JSON into an ImageList object
                        var jsonSerializer = new DataContractJsonSerializer(typeof(ImageList));
                        imageList = (ImageList)jsonSerializer.ReadObject(stream);
                    }

                    return new ResultPack<ImageList>
                    {
                        IsSucceeded = true,
                        ReturnParam = new ImageList{
                            Photos = imageList.Photos.Where(x=>!string.IsNullOrWhiteSpace(x)).Select(x=> string.Format("{0}{1}",x, urlSuffix)).ToList()
                        }
                    };
                }
                catch (Exception ex)
                {
                    return new ResultPack<ImageList>
                    {
                        IsSucceeded = false,
                        Message = ex.Message,
                        ErrorMetadata = ex.StackTrace
                    };
                }
            }
        }
    }
}
