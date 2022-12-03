using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Guardian")]
        public int GuardianId { get; set; }
        public virtual Guardian Guardian { get; set; }
    }
}
