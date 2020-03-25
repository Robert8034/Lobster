using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Data
{
    public class Repository  
    {
        public void Test()
        {
            using (var context = new LobsterContext())
            {
                Console.WriteLine("Hittttt");
                var user = new User
                {
                    Username = "Test",
                    Password = "Test123",
                    Email = "Robert.dams@test.nl",
                    Karma = 123
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
