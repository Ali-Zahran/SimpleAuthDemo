using FecbookDemoAPI.Shared;
using FecbookDemoAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FecbookDemoAPI.Services
{
    public interface IUserService
    {
        // For Registeration
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        // For Logging-in
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }

    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        // for Registeration
        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Rgister Model is null");
            }

            var identityUser = new IdentityUser
            {
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber
            };

            // for create register
            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    IsSuccess = true,
                    Message = "You have registered successfully"
                };
            }

            return new UserManagerResponse
            {
                Message = "Sorry You have not registered",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        //==========================================================================================

        // For Logging-in
        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            // check username
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid Username",
                    IsSuccess = false
                };
            }

            // check password
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid Password",
                    IsSuccess = false
                };
            }

            // Claims
            var claims = new[]
            {
                new Claim("Username", model.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            // JWT Tokens
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpirationDate = token.ValidTo
            };
        }
        //==========================================================================================
    }
}
