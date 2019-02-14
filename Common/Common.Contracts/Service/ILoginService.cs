using Common.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Contracts.Service
{
    public interface ILoginService
    {
        Task<ResultPack<UserInfo>> Login(LoginCredentials credentials, CancellationToken? cancellationToken = null);
    }
}