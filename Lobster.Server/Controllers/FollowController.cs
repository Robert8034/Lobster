using Lobster.Core.Domain;
using Lobster.Core.Models;
using Lobster.Server.Services.FollowServices;
using Lobster.Server.Services.PostingServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Lobster.Core.Data;
using System.Net;

namespace Lobster.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost]
        [Route("getFollows")]
        public RestResponse GetFollows(JsonElement userId)
        {
            return new RestResponse(HttpStatusCode.OK, _followService.GetFollows(userId.GetInt32()));
        }
    }
}
