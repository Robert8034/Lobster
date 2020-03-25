using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lobster.Core.Domain;
using Lobster.Server.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Lobster.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> PostLoginModel(LoginModel model)
        {
            Console.WriteLine(model.Username);
            return new ActionResult<User>(await _authenticationService.LoginUser(model));
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> PostRegisterModel(RegisterModel model)
        {
            Console.WriteLine(model.Username);
            return new ActionResult<User>(await _authenticationService.RegisterUser(model));
        }
    }
}