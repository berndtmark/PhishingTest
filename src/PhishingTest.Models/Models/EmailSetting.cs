using System;
using System.Collections.Generic;

namespace PhishingTest.Models.Models
{
    public class EmailSetting
    {
        public string FromAddress { get; set; }

        public string FromName { get; set; }

        public string SmtpServer { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
