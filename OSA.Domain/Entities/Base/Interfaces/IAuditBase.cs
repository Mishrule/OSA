using System;
using OSA.Models.Core.Enums;

namespace OSA.Domain.Entities.Base.Interfaces
{
    public interface IAuditBase
    {
        public State State { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
