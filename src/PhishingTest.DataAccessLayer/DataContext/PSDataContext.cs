using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhishingTest.DataAccessLayer.Entities;

namespace PhishingTest.DataAccessLayer.DataContext
{
    public class PSDataContext : DbContext
    {
        public PSDataContext(DbContextOptions<PSDataContext> options)
            : base(options)
        { }

        public DbSet<CompromisedCredential> CompromisedCredential { get; set; }
    }
}
