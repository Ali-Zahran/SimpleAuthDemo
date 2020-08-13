using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FecbookDemoAPI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "user name")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 5)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
    }
}
