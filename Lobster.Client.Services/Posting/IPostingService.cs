using Lobster.Core.Domain;
using Lobster.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.Posting
{
    public interface IPostingService
    {
        Task<List<Post>> GenerateTimeline(List<Follow> follows);

        Task CreateNewPost(PostModel postModel);
    }
}
