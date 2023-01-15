using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Entities;
using OSA.Domain.Entities.Base;

namespace OSA.Application.Response
{
    public class BatchResponse: EntityBase
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
       // public Student Student { get; set; }
    }
}
