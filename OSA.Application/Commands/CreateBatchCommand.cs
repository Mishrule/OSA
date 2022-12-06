using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;
using OSA.Models.Core.Enums;

namespace OSA.Application.Commands
{
    public class CreateBatchCommand:IRequest<BaseResponse<BatchResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
