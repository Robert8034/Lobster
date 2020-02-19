using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Client.Services.Authentication
{
    public class AuthenticationService
    {
        public bool ValidateLoginInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
              return false;
            if (string.IsNullOrEmpty(password))
                return false;

            return true;
        }

        public bool ValidateRegisterInput(string username, string password, string passwordConfirm, string email)
        {
            if (string.IsNullOrEmpty(username))
              return false;
            if (string.IsNullOrEmpty(password))
              return false;
            if (string.IsNullOrEmpty(passwordConfirm))
              return false;
            if (string.IsNullOrEmpty(email))
              return false;

            return true;
        }

    }
}
