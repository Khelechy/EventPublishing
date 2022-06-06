using EventMessenger.Dtos;
using EventMessenger.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMessenger.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public AuthController(IRegistrationService registrationService) => _registrationService = registrationService;

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegistrationRequestDto requestDto)
        {
            var response = _registrationService.Register(requestDto); 
            return Ok(response);

        }
    }
}
