using System;
using System.Collections.Generic;
using System.Text;
using Lobster.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lobster.Data
{
    public class LobsterContext : DbContext
    {
            
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<GroupPost> GroupPosts { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                   "Server=localhost;Port=3306;Database=LobsterBase;User=root;Password=Wachtwoord12345;");

            this.Database.Migrate();
        }
    }
}
