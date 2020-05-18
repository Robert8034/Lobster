using Lobster.Core;
using Lobster.Core.Data;
using Lobster.Core.Models.Posts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.Liking
{
    public class LikingService : ILikingService
    {
        private readonly HttpClient _httpClient;
        public LikingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Post> LikePost(int userId, int postId)
        {
            RestResponse response = await _httpClient.PutJsonAsync<RestResponse>("api/Post/" + postId + "/like/" + userId, null, typeof(Post));

            if (response.StatusCode == HttpStatusCode.OK)
            {
               return (Post)response.ResponseObject;
            }

            return null;
        }

    }
}
