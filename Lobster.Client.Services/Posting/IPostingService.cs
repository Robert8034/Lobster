using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.Posting
{
    public interface IPostingService
    {
        Task<List<Post>> GenerateTimeline(List<Follow> follows);
    }
}
