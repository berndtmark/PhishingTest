using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhishingTest.DataAccessLayer.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            CreateDate = DateTime.UtcNow;
        }

        public DateTime CreateDate { get; set; }
    }
}
