using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Reaction = Lobster.Core.Models.Reactions.Reaction;

namespace Lobster.Server.Services.PostingServices
{
    public interface IPostingService
    {
        public List<Post> GetTimeline(List<Core.Models.Follows.Follow> follows);
        public void CreatePost(PostModel postModel);
        public bool LikePost(int postId, int userId);
        public bool RemoveLike(int postId, int userId);
        public Post GetPost(int postId);
        Post ReactOnPost(Reaction reactionModel);
    }
}
