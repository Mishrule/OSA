using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OSA.Application.Commands.Validators
{
    public class CreateBatchValidator: AbstractValidator<CreateBatchCommand>
    {
        public CreateBatchValidator()
        {
            RuleFor(v=> v.Name).NotEmpty();
        }
    }
}
