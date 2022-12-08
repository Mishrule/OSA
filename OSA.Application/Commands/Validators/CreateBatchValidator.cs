using FluentValidation;
using OSA.Application.Commands.BatchCommands;

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
