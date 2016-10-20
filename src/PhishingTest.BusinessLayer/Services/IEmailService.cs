using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhisingTest.BusinessLayer.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailAddress, string subject, string message);
    }
}
