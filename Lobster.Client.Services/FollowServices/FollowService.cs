using Lobster.Core;
using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.FollowServices
{
    public class FollowService : IFollowService
    {
        private readonly HttpClient _httpClient;

        public FollowService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Follow>> GetFollows(int userId)
        {
           return await _httpClient.PostJsonAsync<List<Follow>>("api/Post/generatetimeline", userId);
        }
    }
}
