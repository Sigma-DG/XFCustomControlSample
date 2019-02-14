using Common.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Service
{
    public interface IPictureService
    {
        Task<ResultPack<ImageList>> GetAllPictures(int imageDimension);
    }
}
