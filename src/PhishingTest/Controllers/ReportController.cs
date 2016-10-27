using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhishingTest.DataAccessLayer.Repository.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PhisingTest.Controllers
{
    public class ReportController : Controller
    {
        private readonly ICredentialRepository _CredentialRepository;

        public ReportController(ICredentialRepository credentialRepository)
        {
            _CredentialRepository = credentialRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var creds = _CredentialRepository.GetCredentials();

            return View(creds);
        }
    }
}
