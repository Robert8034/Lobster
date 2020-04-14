using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lobster.Core.Data;
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
        public async Task<RestResponse> PostLoginModel(LoginModel model)
        {
            return new RestResponse(HttpStatusCode.OK, await _authenticationService.LoginUser(model));
        }

        [HttpPost]
        [Route("register")]
        public async Task<RestResponse> PostRegisterModel(RegisterModel model)
        {
            return new RestResponse(HttpStatusCode.OK, await _authenticationService.RegisterUser(model));
        }
    }
}