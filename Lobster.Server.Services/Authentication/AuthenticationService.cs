using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core.Domain;
using Lobster.Data;

namespace Lobster.Server.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<User> LoginUser(LoginModel loginModel)
        {
            Repository repository = new Repository();
            repository.Test();
            return new User();
        }

        public async Task<User> RegisterUser(RegisterModel registerModel)
        {
            return new User();
        }
    }
}
