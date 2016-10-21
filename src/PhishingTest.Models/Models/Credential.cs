using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhishingTest.Models.Models
{
    public class Credential
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
