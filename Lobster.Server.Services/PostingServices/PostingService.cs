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
        private readonly IRepository<Like> _likeRepository;

        public PostingService(IRepository<Post> postRepository, IRepository<Like> likeRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }

        public List<Post> GetTimeline(List<Core.Models.Follows.Follow> follows)
        {
            List<Post> posts = new List<Post>();

            foreach (var follow in follows)
            {
                posts.AddRange(_postRepository.Table.Where(row => row.UserId == follow.FollowerId).Include(post => post.Likes).Include(post => post.Reactions).ToList());

            }
            posts.Sort((x, y) => DateTime.Compare(x.PostDate, y.PostDate));
            posts.Reverse();
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

        public bool LikePost(int postId, int userId)
        {
           if (_likeRepository.TableNoTracking.Any(e => e.PostId == postId && e.UserId == userId)) return false;

            _likeRepository.Insert(new Like
            {
                PostId = postId,
                UserId = userId
            });

            return true;
        }

        public Post GetPost(int postId)
        {
            return _postRepository.TableNoTracking.Include(e => e.Likes).Include(e => e.Reactions).SingleOrDefault(e => e.Id == postId);
        }
    }
}
