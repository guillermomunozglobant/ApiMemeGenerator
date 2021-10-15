using System;
using ApiMemeGenerator.Auth;
using ApiMemeGenerator.Context;
using ApiMemeGenerator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMemeGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtAuthenticationService _authService;

        public AuthController(ILogger<AuthController> logger, 
            IJwtAuthenticationService authService, 
            AppDBContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
            _authService.SetContext(context);
        }

        [Authorize]
        [HttpGet]
        public object Get()
        {
            var responseObject = new { Status = "Running" };
            _logger.LogInformation($"Status: {responseObject.Status}");

            return responseObject;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Usuario user)
        {
            var token = _authService.Authenticate(user.Name, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
