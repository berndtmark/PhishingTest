using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhishingTest.Models.Enums;

namespace PhishingTest.DataAccessLayer.Entities
{
    public class CompromisedCredential : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string UserName { get; set; }

        [MaxLength(500)]
        public string Password { get; set; }

        public PhishingSite PhishingSiteId { get; set; }
    }
}
