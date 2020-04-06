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
        public Task<TimelineModel> GetTimeline(List<Follow> follows);
    }
}
