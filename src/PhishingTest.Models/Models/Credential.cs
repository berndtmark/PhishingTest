using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhishingTest.Models.Models
{
    public class Credential
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string DisplayPassword
        {
            get
            {
                return GetPasswordMask(Password);
            }
        }

        private string GetPasswordMask(string password)
        {
            var displayPassword = new StringBuilder();

            if (password.Length > 0)
            {
                displayPassword.Append(Password[0]);

                if (password.Length > 2)
                {
                    for (int i = 0; i < password.Length - 2; i++)
                    {
                        displayPassword.Append('*');
                    }
                }

                if (password.Length > 1)
                {
                    displayPassword.Append(Password[Password.Length-1]);
                }
            }

            return displayPassword.ToString();
        }
    }
}
