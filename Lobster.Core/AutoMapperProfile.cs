using AutoMapper;
using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, Models.Users.User>();
            CreateMap<Post, Models.Posts.Post>();
            CreateMap<Role, Models.Roles.Role>();
            CreateMap<Follow, Models.Follows.Follow>();
            CreateMap<GroupMessage, Models.GroupMessages.GroupMessage>();
            CreateMap<Like, Models.Likes.Like>();
        }
    }
}
