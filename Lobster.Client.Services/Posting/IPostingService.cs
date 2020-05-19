using Lobster.Core.Models;
using Lobster.Core.Models.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.Posting
{
    public interface IPostingService
    {
        Task<List<Post>> GenerateTimeline(int userId);
        Task CreateNewPost(PostModel postModel);
        Task<Post> GetPost(int postId);
    }
}
