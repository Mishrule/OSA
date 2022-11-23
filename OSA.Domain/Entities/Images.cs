using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Entities.Base;

namespace OSA.Domain.Entities
{
    public class Images : EntityBase
    {
        public string Url { get; set; }
        public string UserName { get; set; }
       // public Student Student { get; set; }
    }
}
