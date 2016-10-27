using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhishingTest.DataAccessLayer.DataContext;
using PhishingTest.DataAccessLayer.Repository;
using PhishingTest.DataAccessLayer.Repository.Interfaces;
using PhishingTest.Models.Models;
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

        public static void ConfigureConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
        {
            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));

            // *If* you need access to generic IConfiguration this is **required**
            services.AddSingleton<IConfiguration>(configuration);

            services.AddDbContext<PSDataContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}