using OSA.Domain.Entities;
using OSA.Domain.Entities.Base;
using OSA.Models.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Application.Response
{
    public class StudentResponse : EntityBase
    {
        public StudentResponse()
        {
            Guardians = new HashSet<Guardian>();
        }

        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public int YearGroup { get; set; }
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public string Location { get; set; }
        
        public Status Status { get; set; }
        [ForeignKey("Batch")]
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }
        public virtual ICollection<Guardian> Guardians { get; private set; }
        
    }
}
