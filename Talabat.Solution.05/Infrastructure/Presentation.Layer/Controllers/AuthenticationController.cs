using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Layer;
using Shared.DTOs.IdentityDtos;

namespace Presentation.Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IServiceManager _serviceManager) : ControllerBase
    {

        //Login     Post   BaseUrl/api/Authentication/Login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _serviceManager.AuthenticationService.LoginAsync(loginDto);
            return Ok(user);
        }

        //Register     Post   BaseUrl/api/Authentication/Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Login(RegisterDto registerDto)
        {
            var user = await _serviceManager.AuthenticationService.RgisterAsync(registerDto);
            return Ok(user);
        }

        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var result = await _serviceManager.AuthenticationService.CheckEmailAsync(email);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var appUser = await _serviceManager.AuthenticationService.GetCurrentUserAsync(email!);
            return Ok(appUser);
        }

        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var address = await _serviceManager.AuthenticationService.GetCurrentUserAddressAsync(email!);
            return Ok(address);
        }

        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDto>> UpdateCurrentUserAddress(AddressDto addressDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var Updatedaddress = await _serviceManager.AuthenticationService.UpdateUserAddressAsync(email!, addressDto);
            return Ok(Updatedaddress);
        }

    }
}
