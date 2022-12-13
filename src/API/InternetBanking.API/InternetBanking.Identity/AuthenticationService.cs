using InternetBanking.Application.DTOs.Request;
using InternetBanking.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace InternetBanking.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task AddUser(AddUserRequest addUserRequest)
        {
            IdentityUser identityUser = new IdentityUser();

            identityUser.UserName = addUserRequest.UserName;
            identityUser.Email = addUserRequest.Email;
            identityUser.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(identityUser, addUserRequest.Password);

            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
                await _signInManager.SignInAsync(identityUser, isPersistent: false);
            }
                
        }

        public async Task<bool> AuthenticateUser(AuthenticateUserRequest authenticateUserRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(authenticateUserRequest.UserName, authenticateUserRequest.Password, false, false);

            return result.Succeeded;
        }

        private async Task GenerateJwtToken()
        {
            var user = await _userManager.FindByEmailAsync("");

            var jwt = new JwtSecurityToken();
        }
    }
}