using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;

namespace OSA.Application.Commands.GuardianCommands
{
    public class DeleteGuardianCommand:IRequest<BaseResponse<GuardianResponse>>
    {
        public int Id { get; set; }
    }
}
