using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.PostingServices
{
    public interface IPostingService
    {
        public List<Post> GetTimeline(List<Core.Models.Follows.Follow> follows);
        public void CreatePost(PostModel postModel);
        public void LikePost(int postId, int userId);
        public void RemoveLike(Like like);
        public bool CheckIfLiked(int postId, int userId);
        public Post GetPost(int postId);
        void ReactOnPost(Core.Models.Reactions.Reaction reactionModel); 
        Like GetLike(int postId, int userId);
        bool CheckIfPostExists(int postId);
        Reaction GetReaction(int reactionId);

    }
}
