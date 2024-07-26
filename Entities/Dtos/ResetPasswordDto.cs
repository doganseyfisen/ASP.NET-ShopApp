using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ResetPasswordDto
    {
        public string? UserName { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Password and confirm password must be match.")]
        public string? ConfirmPassword { get; init; }
    }
}
