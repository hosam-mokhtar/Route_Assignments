using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs.IdentityDtos;

namespace ServiceAbstraction.Layer
{
    public interface IAuthenticationService
    {

        //Login (Email , Password) => Token, Email, Display Name 
        Task<UserDto> LoginAsync(LoginDto loginDto);

        //register (Email , Password , ........) => Token, Email, Display Name 
        Task<UserDto> RgisterAsync(RegisterDto RegisterDto);

        //Check Email
        Task<bool> CheckEmailAsync(string email);

        //Get Current User
        Task<UserDto> GetCurrentUserAsync(string email);

        //Get Current User Address
        Task<AddressDto> GetCurrentUserAddressAsync(string email);

        //Create or Update User Address
        Task<AddressDto> UpdateUserAddressAsync(string email, AddressDto addressDto);

    }
}
