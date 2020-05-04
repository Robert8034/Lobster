using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models.Reactions
{
    [AutoMap(typeof(Domain.Reaction))]
    public class Reaction
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
