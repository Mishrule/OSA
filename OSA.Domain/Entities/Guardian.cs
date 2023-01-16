using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OSA.Domain.Entities.Base;
using OSA.Models.Core.Enums;

namespace OSA.Domain.Entities
{
    public class Guardian : EntityBase
    {
	    //public Guardian()
	    //{
		   // OtherGuardian = new HashSet<OtherGuardian>();
	    //}
		public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
		public string FullName { get;set; }
		public string Contact { get; set; }
        public string Relationship { get; set; }
    
        public string Email { get; set; }
        public PartyType PartyType { get; set; }
        //public virtual ICollection<OtherGuardian> OtherGuardian { get; set; }


		public int StudentId { get; set; }
    public Student Student { get; set; }
       
    }
}
