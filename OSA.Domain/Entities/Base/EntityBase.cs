using System;
using System.ComponentModel.DataAnnotations.Schema;
using OSA.Domain.Entities.Base.Interfaces;
using OSA.Models.Core.Enums;

namespace OSA.Domain.Entities.Base
{
    public abstract class EntityBase: IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public State State { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        
    }
}
