using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core;
using Lobster.Core.Domain;

namespace Lobster.Client.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<User> Register(RegisterModel registerModel)
        { 
           return await _httpClient.PostJsonAsync<User>("api/User/register", registerModel);
        }

        public async Task<User> Login(LoginModel loginModel)
        { 
           return await _httpClient.PostJsonAsync<User>("api/User/login", loginModel);
        }
    }
}
