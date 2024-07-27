using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record EditProfileDto
    {
        private string? _returnUrl;

        public string? UserName { get; init; }
        
        public string? Email { get; init; }

        public string? PhoneNumber { get; init; }

        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                {
                    return "/";
                }
                else
                    return _returnUrl;
            }
            set { _returnUrl = value; }
        }
    }
}