using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public RegisterModel(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public RegisterModel()
        {
            
        }
    }
}
