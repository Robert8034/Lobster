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

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        { 
           return await _httpClient.PostJsonAsync<RegisterResult>("/User/register", registerModel);
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        { 
           Debug.WriteLine("Hit");
           return await _httpClient.PostJsonAsync<LoginResult>("/api/User", loginModel);
        }

    }
}
