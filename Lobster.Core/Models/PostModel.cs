using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models
{
    public class PostModel
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
