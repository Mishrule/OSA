using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OSA.Domain.Entities.Base;
using OSA.Models.Core.Enums;

namespace OSA.Domain.Entities
{
    public class Student : EntityBase
    {
    //public Student()
    //{
    //  Guardian = new HashSet<Guardian>();
    //}

    public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public string Surname { get; set; }
        public int YearGroup { get; set; }
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public string Location { get; set; }
        public Status Status { get; set; }
        [ForeignKey("Batch")]
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }
    //[ForeignKey("Guardian")]
    //public int  GuardianId { get; set; }
    public Guardian Guardian { get; set; }


  }
}
