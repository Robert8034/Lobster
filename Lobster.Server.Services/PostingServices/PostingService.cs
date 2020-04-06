using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.PostingServices
{
    public class PostingService : IPostingService
    {
        private readonly IRepository<Post> _postRepository;

        public PostingService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<TimelineModel> GetTimeline(List<Follow> follows)
        {
            return new TimelineModel();
        }
    }
}
