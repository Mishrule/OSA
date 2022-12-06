using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;

namespace OSA.Application.Queries
{
    public class GetBatchesQuery:IRequest<BaseResponseList<BatchResponse>>
    {
        public GetBatchesQuery()
        {
            
        }
    }
}
