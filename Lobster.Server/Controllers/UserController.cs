using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lobster.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Lobster.Server.Controllers
{
    [ApiController]

    public class UserController : ControllerBase
    {
        private const string Route = "api/User";

        [HttpPost]
        [Route(Route + "/login")]
        public async Task<ActionResult<LoginResult>> PostLoginModel(LoginModel model)
        {
            Console.WriteLine(model.Username);
            return new ActionResult<LoginResult>(new LoginResult());
        }

        [HttpPost]
        [Route(Route + "/register")]
        public async Task<ActionResult<RegisterResult>> PostRegisterModel(RegisterModel model)
        {
            Console.WriteLine(model.Username);
            return new ActionResult<RegisterResult>(new RegisterResult());
        }
    }
}