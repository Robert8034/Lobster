using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core.Models.Posts;

namespace Lobster.Client.Services.Reacting
{
    public interface IReactionService
    {
        public Task<Post> ReactOnPost(int userId, int postId, string content);
    }
}
