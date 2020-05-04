using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lobster.Core.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public LoginModel()
        {
                
        }
    }
}
