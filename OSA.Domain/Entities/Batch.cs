using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Entities.Base;

namespace OSA.Domain.Entities
{
    public class Batch : EntityBase
    {
        public string Name { get; set; }
        public AuditBase Audit { get; set; }
    }
}
