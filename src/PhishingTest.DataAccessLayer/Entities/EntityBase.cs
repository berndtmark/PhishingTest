using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhishingTest.DataAccessLayer.Entities
{
    public abstract class EntityBase
    {
        public DateTime CreateDate { get; set; }
    }
}
