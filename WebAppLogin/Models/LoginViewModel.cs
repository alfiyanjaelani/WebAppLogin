using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppLogin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is Requierd")]
        public string Password { get; set; }
    }
}
