using Lobster.Core.Domain;
using Lobster.Core.Models;
using Lobster.Server.Services.PostingServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lobster.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostingService _postingService;

        public PostController(IPostingService postingService)
        {
            _postingService = postingService;
        }
        
        [HttpPost]
        [Route("generatetimeline")]
        public async Task<ActionResult<TimelineModel>> GenerateTimeline(List<Follow> follows)
        {
            return new ActionResult<TimelineModel>(await _postingService.GetTimeline(follows));
        }
    }
}
