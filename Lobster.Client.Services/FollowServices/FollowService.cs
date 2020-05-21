using Lobster.Core;
using Lobster.Core.Data;
using Lobster.Core.Models.Follows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
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
            RestResponse response = await _httpClient.PostJsonAsync<RestResponse>("api/Follow/getFollows", userId, typeof(List<Follow>));

            return (List<Follow>)response.ResponseObject;
           
        }

        public async Task<List<Follow>> FollowUser(int userId, int followerId)
        {
            RestResponse restResponse = await _httpClient.PutJsonAsync<RestResponse>("api/follow/" + userId + "/follows/" + followerId + "/add", null, typeof(List<Follow>));

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return (List<Follow>)restResponse.ResponseObject;
            }

            return null;
        }

        public async Task<List<Follow>> UnfollowUser(int userId, int followerId)
        {
            RestResponse restResponse = await _httpClient.PutJsonAsync<RestResponse>("api/follow/" + userId + "/follows/" + followerId + "/remove", null, typeof(List<Follow>));

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return (List<Follow>)restResponse.ResponseObject;
            }

            return null;
        }
    }
}
