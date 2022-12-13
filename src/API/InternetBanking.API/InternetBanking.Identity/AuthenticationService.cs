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

        public async void AuthenticateUser()
        {
            var result = await _signInManager.PasswordSignInAsync("", "", false, false);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {

                }
                else if (result.IsNotAllowed)
                {

                }
                else if (result.RequiresTwoFactor)
                {

                }
                else
                {
                    // user ou senha invalidos
                }
            }
        }

        private async Task GenerateJwtToken()
        {
            var user = await _userManager.FindByEmailAsync("");

            var jwt = new JwtSecurityToken();
        }
    }
}