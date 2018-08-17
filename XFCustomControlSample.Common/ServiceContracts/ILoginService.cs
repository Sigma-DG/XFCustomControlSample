using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCustomControlSample.Common.Models;

namespace XFCustomControlSample.Common.ServiceContracts
{
    public interface ILoginService
    {
        Task<ResultPack<UserInfo>> Login(LoginCredentials credentials);
    }
}
