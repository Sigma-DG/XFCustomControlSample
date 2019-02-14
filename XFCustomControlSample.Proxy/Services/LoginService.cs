using Common.Contracts.Data;
using Common.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XFCustomControlSample.Proxy.Services
{
    public class LoginService : ILoginService, IDisposable
    {
        public void Dispose()
        {
            //Bye object!!
        }

        public async Task<ResultPack<UserInfo>> Login(LoginCredentials credentials, CancellationToken? cancellationToken = null)
        {
            if (credentials == null || string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
                return new ResultPack<UserInfo> {
                    IsSucceeded = false,
                    Message = "Credentials are required"
                };

            if (!cancellationToken.HasValue) cancellationToken = CancellationToken.None;

            await Task.Delay(2000, cancellationToken.Value);

            return credentials.Username.ToLower().Equals("a") && credentials.Password.Equals("1") ?
                new ResultPack<UserInfo>
                {
                    IsSucceeded = true,
                    ReturnParam = new UserInfo
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Title = "Mr."
                    }
                } :
                new ResultPack<UserInfo>
                {
                    IsSucceeded = false,
                    Message = "Wrong credentials!\nPlease try again.."
                };
        }
    }
}
