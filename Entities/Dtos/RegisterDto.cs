using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }
        
        [Required(ErrorMessage = "You must enter your password again.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; init; }
    }
}
