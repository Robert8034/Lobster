using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<LoginResult> LoginUser(LoginModel loginModel); 
        Task<RegisterResult> RegisterUser(RegisterModel registerModel);
    }
}
