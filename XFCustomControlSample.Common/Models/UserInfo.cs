using System;
using System.Collections.Generic;
using System.Text;

namespace XFCustomControlSample.Common.Models
{
    public class UserInfo : LoginCredentials
    {
        public UserInfo(LoginCredentials credentials)
        {
            if (credentials != null)
            {
                this.Username = credentials.Username;
                this.Password = credentials.Password;
            }
        }

        public UserInfo():this(new LoginCredentials()) { }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string ProfileImage { get; set; }
    }
}
