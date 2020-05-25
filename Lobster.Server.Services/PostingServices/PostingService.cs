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
        private readonly IRepository<Reaction> _reactionRepository;

        public PostingService(IRepository<Post> postRepository, IRepository<Like> likeRepository, IRepository<Reaction> reactionRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _reactionRepository = reactionRepository;
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
                Reactions = new List<Core.Domain.Reaction>()
            });
        }

        public bool CheckIfLiked(int postId, int userId)
        {
            if (_likeRepository.TableNoTracking.Any(e => e.PostId == postId && e.UserId == userId)) return true;

            return false;

        }

        public void LikePost(int postId, int userId)
        {
            _likeRepository.Insert(new Like
            {
                PostId = postId,
                UserId = userId
            });
        }

        public Like GetLike(int postId, int userId)
        {

           return _likeRepository.TableNoTracking.SingleOrDefault(e =>
                e.PostId == postId && e.UserId == userId);
        }

        public void RemoveLike(Like like)
        {
            _likeRepository.Delete(like);
        }

        public Post GetPost(int postId)
        {
            Post post = _postRepository.TableNoTracking.Include(e => e.Likes).Include(e => e.Reactions).SingleOrDefault(e => e.Id == postId);
            post.Reactions.Sort((x, y) => DateTime.Compare(x.PostDate, y.PostDate));
            post.Reactions.Reverse();
            return post;
        }

        public void ReactOnPost(Core.Models.Reactions.Reaction reactionModel)
        {
            _reactionRepository.Insert(new Reaction
            {
                Content = reactionModel.Content,
                PostId = reactionModel.PostId,
                UserId = reactionModel.UserId,
                PostDate = DateTime.Now
            });
        }

        public bool CheckIfPostExists(int postId)
        {
            if (_postRepository.TableNoTracking.Any(e => e.Id == postId)) return true;

            return false;
        }

        public Reaction GetReaction(int reactionId)
        {
            return _reactionRepository.TableNoTracking.SingleOrDefault(e => e.Id == reactionId);
        }
    }
}
