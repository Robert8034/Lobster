using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models.GroupMessages
{
    [AutoMap(typeof(Domain.GroupMessage))]
    public class GroupMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Content { get; set; }
    }
}
