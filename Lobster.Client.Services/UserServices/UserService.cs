using Lobster.Core;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetTimelineUsers(List<Follow> follows)
        {
            List<User> TimelineUsers = new List<User>();
            foreach (var follow in follows)
            {
                TimelineUsers.Add(await GetPublicUserInfo(follow.FollowId));
            }

            return TimelineUsers;
        }

        public async Task<User> GetPublicUserInfo(int userId)
        {
            RestResponse restResponse = await _httpClient.GetJsonAsync<RestResponse>("api/User/" + userId + "/public", typeof(User));

            if (restResponse.StatusCode == HttpStatusCode.OK) return (User)restResponse.ResponseObject;

            return null;
        }
    }
}
