using AutoMapper;
using Lobster.Core.Models.Follows;
using Lobster.Core.Models.GroupMessages;
using Lobster.Core.Models.Posts;
using Lobster.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models.Users
{
    [AutoMap(typeof(Domain.User))]

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EncryptionKey { get; set; }
        public string Email { get; set; }
        public int Karma { get; set; }
        public Role Role { get; set; }
        public List<GroupMessage> Messages { get; set; }
        public List<Follow> Follows { get; set; }
    }
}
