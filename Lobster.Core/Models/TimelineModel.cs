using Lobster.Core.Models.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models
{
    public class TimelineModel
    {
        public TimelineModel()
        {
            Timeline = new List<Post>();
        }
        public List<Post> Timeline { get; set; }
    }
}
