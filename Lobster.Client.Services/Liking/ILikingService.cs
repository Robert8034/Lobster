using Lobster.Core.Models.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.Liking
{
    public interface ILikingService
    {
        public Task<Post> LikePost(int userId, int postId);
    }
}
