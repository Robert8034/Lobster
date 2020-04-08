using Lobster.Core;
using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
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

        public async Task<List<Post>> GenerateTimeline(List<Follow> follows)
        {
            TimelineModel timelineModel = await _httpClient.PostJsonAsync<TimelineModel>("api/Post/generatetimeline", follows);
            return timelineModel.Timeline;
        }
    }
}
