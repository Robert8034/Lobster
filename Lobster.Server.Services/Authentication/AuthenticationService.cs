using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core.Domain;

namespace Lobster.Server.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<LoginResult> LoginUser(LoginModel loginModel)
        {
            return new LoginResult();
        }

        public async Task<RegisterResult> RegisterUser(RegisterModel registerModel)
        {
            return new RegisterResult();
        }
    }
}
