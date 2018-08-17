using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCustomControlSample.Common.Models;
using XFCustomControlSample.Common.ServiceContracts;

namespace XFCustomControlSample.Proxy.Services
{
    public class LoginService : ILoginService
    {
        public async Task<ResultPack<UserInfo>> Login(LoginCredentials credentials)
        {
            if (credentials == null || string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
                return new ResultPack<UserInfo> {
                    IsSucceeded = false,
                    Message = "Credentials are required"
                };

            await Task.Delay(1000);

            return 
                new ResultPack<UserInfo> {
                    IsSucceeded = true,
                    ReturnParam = new UserInfo {
                        FirstName = "John",
                        LastName = "Doe",
                        Title = "Mr."
                    }
                };
        }
    }
}
