using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core.Domain;

namespace Lobster.Client.Services.Authentication
{
    public interface IAuthenticationService
    { 
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
    }
}
