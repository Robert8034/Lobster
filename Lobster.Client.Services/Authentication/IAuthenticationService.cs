using Lobster.Core.Models;
using Lobster.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.Authentication
{
    public interface IAuthenticationService
    { 
        Task<User> Register(RegisterModel registerModel);
        Task<User> Login(LoginModel loginModel);
    }
}
