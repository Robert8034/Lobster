using AutoMapper;
using Lobster.Core.Models.Likes;
using Lobster.Core.Models.Reactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models.Posts
{
    [AutoMap(typeof(Domain.Post))]
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public List<Like> Likes { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}
