using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OSA.Application.Commands.StudentCommands;

namespace OSA.Application.Commands.Validators
{
    public class CreateStudentValidator:AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(s=>s.StudentNumber).NotEmpty();
            RuleFor(s=>s.FirstName).NotEmpty();
            RuleFor(s=>s.Surname).NotEmpty();
        }
    }
}
