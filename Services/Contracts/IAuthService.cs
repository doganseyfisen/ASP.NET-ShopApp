using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        
        IEnumerable<IdentityUser> GetAllUsers();

        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        
        Task<IdentityUser> GetSelectedUser(string userName);

        Task Update(UserDtoForUpdate userDto);

        Task<UserDtoForUpdate> GetSelectedUserForUpdate(string userName);

        Task<IdentityResult> ResetPassword(ResetPasswordDto model);

        Task<IdentityResult> DeleteSelectedUser(string userName);
    }
}