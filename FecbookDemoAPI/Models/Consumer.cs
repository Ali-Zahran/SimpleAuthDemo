using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FecbookDemoAPI.Models
{
    public class Consumer
    {
        public int ConsumerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength =3)]
        public string Username { get; set; }

        [Required]
        [StringLength(11, MinimumLength =11)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
