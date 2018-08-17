﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCustomControlSample.Common.Models;
using XFCustomControlSample.Common.ServiceContracts;

namespace XFCustomControlSample.Proxy.Services
{
    public class LoginService : ILoginService, IDisposable
    {
        public void Dispose()
        {
            //Bye object!!
        }

        public async Task<ResultPack<UserInfo>> Login(LoginCredentials credentials)
        {
            if (credentials == null || string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
                return new ResultPack<UserInfo> {
                    IsSucceeded = false,
                    Message = "Credentials are required"
                };

            await Task.Delay(2000);

            return credentials.Username.ToLower().Equals("a") && credentials.Password.ToLower().Equals("1") ?
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
