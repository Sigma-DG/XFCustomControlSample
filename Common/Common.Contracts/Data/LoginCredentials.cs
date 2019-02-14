using System;

namespace Common.Contracts.Data
{
    public class LoginCredentials : RequestBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string DeviceId { get; set; }
    }
}
