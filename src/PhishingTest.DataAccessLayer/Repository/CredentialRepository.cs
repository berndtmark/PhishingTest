using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhishingTest.DataAccessLayer.DataContext;
using PhishingTest.DataAccessLayer.Entities;
using PhishingTest.DataAccessLayer.Repository.Interfaces;
using PhishingTest.Models.Models;

namespace PhishingTest.DataAccessLayer.Repository
{
    public class CredentialRepository : RepositoryBase, ICredentialRepository
    {
        public CredentialRepository(PSDataContext context) : base(context)
        {
        }

        public IList<Credential> GetCredentials()
        {
            var creds = FindAll<CompromisedCredential>();

            return creds.Select(c => new Credential() { Email = c.UserName, Password = c.Password }).ToList();
        }

        public void SaveCredential(Credential creds)
        {
            try
            {
                var cred = new CompromisedCredential();
                cred.UserName = creds.Email;
                cred.Password = creds.Password;

                Insert(cred);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}