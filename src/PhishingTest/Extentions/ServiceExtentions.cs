using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PhisingTest.BusinessLayer.Services;

namespace PhisingTest.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}