using System;
using AutoMapper;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Core.Models;
using Lobster.Server.Services.FollowServices;
using Lobster.Server.Services.PostingServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Lobster.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostingService _postingService;
        private readonly IMapper _mapper;
        private readonly IFollowService _followService;

        public PostController(IPostingService postingService, IFollowService followService, IMapper mapper)
        {
            _postingService = postingService;
            _mapper = mapper;
            _followService = followService;

        }

        [HttpGet]
        [Route("generatetimeline/{userId}")]
        public RestResponse GenerateTimeline(int userId)
        {
            var follows = _followService.GetFollows(userId);

            var posts = _postingService.GetTimeline(_mapper.Map<List<Core.Models.Follows.Follow>>(follows));

            TimelineModel timelineModel = new TimelineModel
            {
                Timeline = _mapper.Map<List<Core.Models.Posts.Post>>(posts)
            };

            return new RestResponse(HttpStatusCode.OK, timelineModel);
        }

        [HttpPost]
        public RestResponse CreateNewPost(PostModel postModel)
        {
            _postingService.CreatePost(postModel);
            return new RestResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("/user/{userId}")]
        public RestResponse GetUserPosts(int userId)
        {
            return new RestResponse(HttpStatusCode.OK);
        }
    }
}
