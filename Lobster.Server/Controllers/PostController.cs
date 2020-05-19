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
        [Route("user/{userId}")]
        public RestResponse GetUserPosts(int userId)
        {
            return new RestResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("{postId}/like/{userId}")]
        public RestResponse LikePost(int postId, int userId)
        {
            var result = _postingService.LikePost(postId, userId);

            return result ? new RestResponse(HttpStatusCode.OK, _mapper.Map<Core.Models.Posts.Post>(_postingService.GetPost(postId))) : new RestResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("{postId}/like/{userId}/remove")]
        public RestResponse RemoveLike(int postId, int userId)
        {
            var result = _postingService.RemoveLike(postId, userId);

            return result ? new RestResponse(HttpStatusCode.OK, _mapper.Map<Core.Models.Posts.Post>(_postingService.GetPost(postId))) : new RestResponse(HttpStatusCode.BadRequest);

        }

        [HttpGet]
        [Route("{postId}")]
        public RestResponse GetPost(int postId)
        {
            var result = _postingService.GetPost(postId);

            return new RestResponse(HttpStatusCode.OK, _mapper.Map<Core.Models.Posts.Post>(result));
        }
    }
}
