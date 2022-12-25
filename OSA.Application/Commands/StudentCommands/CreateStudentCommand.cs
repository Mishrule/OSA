using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;
using OSA.Domain.Entities;
using OSA.Models.Core.Enums;

namespace OSA.Application.Commands.StudentCommands
{
    public class CreateStudentCommand:IRequest<BaseResponse<StudentResponse>>
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string FullName => FirstName + MiddleName + Surname;
        public int YearGroup { get; set; }
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public string Location { get; set; }
        
        public Status Status { get; set; }
        public State State { get; set; }
        
        public int BatchId { get; set; }
        public int GuardianId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
