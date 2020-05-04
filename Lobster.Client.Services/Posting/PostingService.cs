using Lobster.Core;
using Lobster.Core.Data;
using Lobster.Core.Models;
using Lobster.Core.Models.Posts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.Posting
{
    public class PostingService : IPostingService
    {
        private readonly HttpClient _httpClient;

        public PostingService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<List<Post>> GenerateTimeline(int userId)
        {
            RestResponse response = await _httpClient.GetJsonAsync<RestResponse>("api/Post/generatetimeline/" + userId, typeof(TimelineModel));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                TimelineModel timelineModel = (TimelineModel)response.ResponseObject;
                return timelineModel.Timeline;
            }
            return null;
        }

        public async Task CreateNewPost(PostModel postModel)
        {
           await _httpClient.PostJsonAsync<RestResponse>("api/Post", postModel, null);
        }
    }
}
