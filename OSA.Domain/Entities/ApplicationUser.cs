using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OSA.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        //[ForeignKey("Image")]
        //public int ImageId { get; set; }
        //public virtual Images Image { get; set; }
        [ForeignKey("Guardian")]
        public int GuardianId { get; set; }
        public virtual Guardian Guardian { get; set; }
    }
}
