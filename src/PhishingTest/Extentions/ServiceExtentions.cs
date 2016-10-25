using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PhishingTest.DataAccessLayer.Repository;
using PhishingTest.DataAccessLayer.Repository.Interfaces;
using PhisingTest.BusinessLayer.Services;
using PhisingTest.BusinessLayer.Services.Interfaces;

namespace PhisingTest.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICredentialRepository, CredentialRepository>();
        }
    }
}