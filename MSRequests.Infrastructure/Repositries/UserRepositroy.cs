using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;
using MSRequests.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MSRequests.Infrastructure.Repositries
{
    public class UserRepositroy : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTDTO _jwt;
        public UserRepositroy(UserManager<IdentityUser> userManager, IOptions<JWTDTO> jwt, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
          
        }

        public async Task<Response<AuthenticationDTO>> LoginAsync(UserLoginDTO userLogin)
        {
            var response = new Response<AuthenticationDTO>();
            var auth = new AuthenticationDTO();
            var user = await _userManager.FindByNameAsync(userLogin.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                response.Message = "Email or Password is incorrect!";
                return response;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            auth.IsAuthenticated = true;
            auth.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            auth.Email = user.Email ?? "";
            auth.UserName = user.UserName;
            auth.ExpiresOn = jwtSecurityToken.ValidTo;
            return new Response<AuthenticationDTO> { Success = true, Message = "You are authenticated!", Data = auth };
        }

        public async Task<Response<string>> RegisterAsync(UserInfoDTO DTO)
        {
            var user = new IdentityUser
            {
                UserName = DTO.UserName,
                Email = DTO.Email,
                PhoneNumber = DTO.Phone,

            };
            if (await _userManager.FindByNameAsync(user.UserName) is not null)
                return new Response<string> { Message = "Username is already registered!" };
            else
            {
                var result = await _userManager.CreateAsync(user, DTO.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Empty;

                    foreach (var error in result.Errors)
                        errors += $"{error.Description},";

                    return new Response<string> { Success = false, Message = errors };
                }
                else
                {
                    return new Response<string> { Success = true, Message = "User Registred Succesfully!", Data = null };
                }


            }
        }
        private async Task<JwtSecurityToken> CreateJwtToken(IdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                var roleObject = await _roleManager.FindByNameAsync(role);
                if (roleObject != null)
                {
                    var currentRoleClaims = await _roleManager.GetClaimsAsync(roleObject);
                    roleClaims.AddRange(currentRoleClaims);
                }
                roleClaims.Add(new Claim("roles", role));
            }

            roleClaims = roleClaims.DistinctBy(c => c.Value).ToList();

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

           // var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
          //  var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var expirsOn = DateTime.Now.AddMinutes(_jwt.DurationInMins);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.SpecifyKind(expirsOn, DateTimeKind.Utc)
              );

            return jwtSecurityToken;
        }
    }
}