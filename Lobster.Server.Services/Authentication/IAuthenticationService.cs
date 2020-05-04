using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.Authentication
{
    public interface IAuthenticationService
    {
        User LoginUser(LoginModel loginModel); 
        User RegisterUser(RegisterModel registerModel);
    }
}
