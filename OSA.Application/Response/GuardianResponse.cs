using OSA.Domain.Entities.Base;
using OSA.Domain.Entities;
using OSA.Models.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Application.Response
{
    public class GuardianResponse : EntityBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string Relationship { get; set; }
        public string Email { get; set; }
        public PartyType PartyType { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

    }
}
