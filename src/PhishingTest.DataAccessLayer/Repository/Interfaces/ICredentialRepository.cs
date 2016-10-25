using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhishingTest.Models.Models;

namespace PhishingTest.DataAccessLayer.Repository.Interfaces
{
    public interface ICredentialRepository
    {
        IList<Credential> GetCredentials();

        void SaveCredential(Credential creds);
    }
}
