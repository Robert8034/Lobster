using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Lobster.Client.Services.Authentication
{
    class AuthenticationService : IAuthenticationService
    {

        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
    }
}
