using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public TimelineModel GetTimeline(List<Follow> follows)
        {
            TimelineModel timelineModel = new TimelineModel();    

            foreach (var follow in follows)
            {
                timelineModel.Timeline.AddRange(_postRepository.Table.Where(row => row.UserId == follow.FollowId));
            }
            return timelineModel;
        }

        public void CreatePost(PostModel postModel)
        {
            _postRepository.Insert(new Post
            {
                Content = postModel.Content,
                PostDate = DateTime.Now,
                UserId = postModel.UserId
            });
        }
    }
}
