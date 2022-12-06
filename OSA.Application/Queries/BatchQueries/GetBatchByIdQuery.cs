using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;

namespace OSA.Application.Queries
{
    public class GetBatchByIdQuery:IRequest<BaseResponse<BatchResponse>>
    {
        public int Id { get; set; }

        public GetBatchByIdQuery(int id)
        {
            Id = id;
        }
    }
}
