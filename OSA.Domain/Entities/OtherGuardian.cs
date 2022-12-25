using OSA.Domain.Entities.Base;
using OSA.Models.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Domain.Entities
{
    public class OtherGuardian : EntityBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Contact { get; set; }
        public string Relationship { get; set; }
        
        public string Email { get; set; }
        public PartyType PartyType { get; set; }

        [ForeignKey("Guardian")]
        public int GuardianId { get; set; }
        public virtual Guardian Guardian { get; set; }
    }
}
