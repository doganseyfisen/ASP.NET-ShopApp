using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class LoginModel
    {
        private string? _returnUrl;

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

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
