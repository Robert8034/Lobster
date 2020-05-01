using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Newtonsoft.Json;

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
            RestResponse response = await _httpClient.PostJsonAsync<RestResponse>("api/User/register", registerModel, typeof(User));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (User)response.ResponseObject;

            }
            return null;
        }

        public async Task<User> Login(LoginModel loginModel)
        { 
            RestResponse response = await _httpClient.PostJsonAsync<RestResponse>("api/User/login", loginModel, typeof(User));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (User) response.ResponseObject;
            }
            return null;
        }
    }
}
