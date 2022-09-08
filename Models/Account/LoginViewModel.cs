using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please enter email address.")]
        [EmailAddress(ErrorMessage ="Invalid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter password.")]
        public string Password { get; set; }
    }
}
