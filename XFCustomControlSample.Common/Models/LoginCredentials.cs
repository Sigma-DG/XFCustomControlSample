using System;

namespace XFCustomControlSample.Common.Models
{
    public class LoginCredentials : RequestBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string DeviceId { get; set; }
    }
}
