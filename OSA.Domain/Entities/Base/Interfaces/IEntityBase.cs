using OSA.Models.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Domain.Entities.Base.Interfaces
{
    public interface IEntityBase
    {
        int Id { get; }
         State State { get; set; }
         string CreatedBy { get; set; }
         DateTime CreatedDate { get; set; }
         string ModifiedBy { get; set; }
         DateTime ModifiedDate { get; set; }
    }
}
