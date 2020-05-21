using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core;
using Lobster.Core.Data;
using Lobster.Core.Models.Posts;
using Lobster.Core.Models.Reactions;

namespace Lobster.Client.Services.Reacting
{
    public class ReactionService : IReactionService
    {
        private readonly HttpClient _httpClient;
        public ReactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Post> ReactOnPost(int userId, int postId, string content)
        {
            RestResponse response = await _httpClient.PutJsonAsync<RestResponse>("api/Post/react", new Reaction
            {
                Content = content,
                PostId = postId,
                UserId = userId
            }, typeof(Post));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (Post)response.ResponseObject;
            }

            return null;
        }
    }
}
