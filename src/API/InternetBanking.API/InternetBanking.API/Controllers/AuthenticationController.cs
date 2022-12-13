using InternetBanking.Application.DTOs.Request;
using InternetBanking.Application.Interfaces;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(AddUserRequest addUserRequest)
        {
            await _authenticationService.AddUser(addUserRequest);

            return Ok();
        }
    }
}
