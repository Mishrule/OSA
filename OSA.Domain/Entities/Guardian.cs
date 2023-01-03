using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OSA.Domain.Entities.Base;
using OSA.Models.Core.Enums;

namespace OSA.Domain.Entities
{
    public class Guardian : EntityBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
		public string FullName { get;set; }
		public string Contact { get; set; }
        public string Relationship { get; set; }
    
        public string Email { get; set; }
        public PartyType PartyType { get; set; }

		// [ForeignKey("Student")]
		public int StudentId { get; set; }
        public virtual Student Student { get; set; }
       
    }
}
