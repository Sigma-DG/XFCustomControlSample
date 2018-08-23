using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCustomControlSample.Common.Models;

namespace XFCustomControlSample.Common.ServiceContracts
{
    public interface IPictureService
    {
        Task<ResultPack<ImageList>> GetAllPictures(int imageDimension);
    }
}
