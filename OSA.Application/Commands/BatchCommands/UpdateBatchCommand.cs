using MediatR;
using OSA.Application.Response;
using OSA.Models.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Application.Commands.BatchCommands
{
    public class UpdateBatchCommand : IRequest<BaseResponse<BatchResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
