using Chat.Domain.Interfaces.Service_Interfaces;
using Chat.Domain.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginViewModel loginCredentials)
        {
            var existingUser = await _authService.GetUserByCredentials(loginCredentials);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            return Ok(_authService.GenerateToken(existingUser));
        }
    }
}
