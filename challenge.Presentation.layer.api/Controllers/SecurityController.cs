using challenge.application.layer.Services.Security;
using challenge.presentation.layer.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.presentation.layer.Controllers
{
    public class SecurityController : BaseController
    {
        private readonly ISecurityServices _securityServices;
        public SecurityController(ISecurityServices securityServices)
        {
            _securityServices = securityServices;
        }

        [HttpGet("GetToken")]

        public async Task<ActionResult> GetToken([FromQuery] string code)
        {
            return Ok(await _securityServices.GetToken(code));
        }
    }
}
