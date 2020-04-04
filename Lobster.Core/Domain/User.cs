using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EncryptionKey { get; set; }
        public string Email { get; set; }
        public int Karma { get; set; }
        public List<Post> Posts { get; set; }
        public List<GroupMessage> Messages { get; set; }
        public List<Follow> Follows { get; set; }
    }
}
