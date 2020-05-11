using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lobster.Server.Services.PostingServices
{
    public class PostingService : IPostingService
    {
        private readonly IRepository<Post> _postRepository;

        public PostingService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> GetTimeline(List<Core.Models.Follows.Follow> follows)
        {
            List<Post> posts = new List<Post>();

            foreach (var follow in follows)
            {
                posts.AddRange(_postRepository.Table.Where(row => row.UserId == follow.FollowerId).Include(post => post.Likes).Include(post => post.Reactions).ToList());

            }
            return posts;
        }

        public void CreatePost(PostModel postModel)
        {
            _postRepository.Insert(new Post
            {
                Content = postModel.Content,
                PostDate = DateTime.Now,
                UserId = postModel.UserId,
                Likes = new List<Like>(),
                Reactions = new List<Reaction>()
            });
        }
    }
}
