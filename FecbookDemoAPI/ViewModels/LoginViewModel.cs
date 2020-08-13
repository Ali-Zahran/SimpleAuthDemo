using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FecbookDemoAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "the username is required")]
        [StringLength(100, ErrorMessage = "The maximum length is 100")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="The password is between 5 and 50")]
        public string Password { get; set; }
    }
}
