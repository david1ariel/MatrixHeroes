using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class CredentialsModel
    {
        [Required(ErrorMessage = "Missing Username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Missing Password!")]
        public string Password { get; set; }
    }
}
