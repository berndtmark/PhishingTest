using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
