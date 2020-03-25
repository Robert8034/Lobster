using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<User> LoginUser(LoginModel loginModel); 
        Task<User> RegisterUser(RegisterModel registerModel);
    }
}
