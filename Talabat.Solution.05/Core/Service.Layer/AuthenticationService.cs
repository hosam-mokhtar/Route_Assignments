using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Layer.Exceptions;
using Domain.Layer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction.Layer;
using Shared.DTOs.IdentityDtos;

namespace Service.Layer
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager,
                                       IConfiguration _configuration,
                                       IMapper _mapper)
                 : IAuthenticationService
    {

        #region Login & Register
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            //Check If Email Exist
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null)
                throw new UserNotFoundException(loginDto.Email);
            //Check Path
            var isPassValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (isPassValid)
            {
                return new UserDto
                {
                    Email = user.Email!,
                    DisplayName = user.DisplayName,
                    Token = /*CreateTokenAsync(user)*/ await CreateTokenAsync(user)
                };
            }
            else
                throw new UnauthorizedException();
        }

        public async Task<UserDto> RgisterAsync(RegisterDto RegisterDto)
        {
            //Convert Dto to Entity
            var user = new ApplicationUser
            {
                DisplayName = RegisterDto.DisplayName,
                Email = RegisterDto.Email,
                UserName = RegisterDto.Email,
                PhoneNumber = RegisterDto.PhoneNumber
            };
            var res = await _userManager.CreateAsync(user, RegisterDto.Password);

            if (res.Succeeded)
                return new UserDto
                {
                    Email = user.Email!,
                    DisplayName = user.DisplayName,
                    Token = /*CreateTokenAsync(user)*/ await CreateTokenAsync(user)
                };
            else
            {
                var errors = res.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException(errors);
            }
        }

        //private string CreateTokenAsync(ApplicationUser user)
        //{
        //    return "Token";
        //}

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id!)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            //or
            //claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            //{
            //var SecretKey = "69d4317ea0a1e76863da5d8320a2ebbe";
            //in appsettings.json
            var SecretKey = _configuration["JwtOptions:SecretKey"];
            //}

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey!));

            var Credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                issuer: /*"My Issuer Back End",*/ _configuration["JwtOptions:Issuer"],
                audience: /*"My Audience : From End",*/ _configuration["JwtOptions:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: Credentials
            );

            var TokenHandler = new JwtSecurityTokenHandler().WriteToken(Token);

            return TokenHandler;
        }

        #endregion

        public async Task<bool> CheckEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user is not null;
        }

        public async Task<UserDto> GetCurrentUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                throw new UserNotFoundException(email);

            return new UserDto()
            {
                Email = user.Email!,
                DisplayName = user.DisplayName,
                Token = await CreateTokenAsync(user)
            };
        }
        public async Task<AddressDto> GetCurrentUserAddressAsync(string email)
        {
            var user = await _userManager.Users
                            .Include(u => u.Address)
                            .FirstOrDefaultAsync(u => u.Email == email) ??
                            throw new UserNotFoundException(email);

            if (user.Address is not null)
                return _mapper.Map<AddressDto>(user.Address);
            else
                throw new AddressNotFoundException(user.UserName!);
        }

        public async Task<AddressDto> UpdateUserAddressAsync(string email, AddressDto addressDto)
        {
            var user = await _userManager.Users
                            .Include(u => u.Address)
                            .FirstOrDefaultAsync() ??
                             throw new UserNotFoundException(email);
            if (user.Address is not null) //Update
            {
                user.Address.FirstName = addressDto.FirstName;
                user.Address.LastName = addressDto.LastName;
                user.Address.Street = addressDto.Street;
                user.Address.City = addressDto.City;
                user.Address.Country = addressDto.Country;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    throw new BadRequestException(errors);
                }
            }
            else //Create
            {
                user.Address = _mapper.Map<Address>(addressDto);
            }

            await _userManager.UpdateAsync(user);
            return _mapper.Map<AddressDto>(user.Address);
        }

    }
}
