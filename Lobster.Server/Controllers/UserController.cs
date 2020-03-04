using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lobster.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lobster.Server.Controllers
{ 
    [ApiController]
    [Route("api/User")]
  
    public class UserController : ControllerBase
    {


        [HttpPost]
        public async Task<ActionResult<RegisterResult>> PostRegisterModel(RegisterModel model)
        {
            return new ActionResult<RegisterResult>(new RegisterResult());
        }
    }
}