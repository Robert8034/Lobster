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
using AutoMapper;

namespace Lobster.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;
        private readonly IMapper _mapper;

        public FollowController(IFollowService followService, IMapper mapper)
        {
            _followService = followService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("getFollows")]
        public RestResponse GetFollows(JsonElement userId)
        {
            return new RestResponse(HttpStatusCode.OK, _mapper.Map<List<Core.Models.Follows.Follow>>(_followService.GetFollows(userId.GetInt32())));
        }

        [HttpPut]
        [Route("{userId}/follows/{followerId}/add")]
        public RestResponse FollowUser(int userId, int followerId)
        {
            var result = false;

            if (!_followService.CheckIfFollowed(userId, followerId))
            {
                _followService.FollowUser(userId, followerId);
                result = true;
            }

            return result ? new RestResponse(HttpStatusCode.OK, _mapper.Map<List<Core.Models.Follows.Follow>>(_followService.GetFollows(userId))) : new RestResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("{userId}/follows/{followerId}/remove")]
        public RestResponse UnfollowUser(int userId, int followerId)
        {
            var result = false;

            if (_followService.CheckIfFollowed(userId, followerId))
            {
                var follow = _followService.GetFollow(userId, followerId);
                _followService.UnfollowUser(follow);
                result = true;
            }

            return result ? new RestResponse(HttpStatusCode.OK, _mapper.Map<List<Core.Models.Follows.Follow>>(_followService.GetFollows(userId))) : new RestResponse(HttpStatusCode.BadRequest);

        }
    }
}
