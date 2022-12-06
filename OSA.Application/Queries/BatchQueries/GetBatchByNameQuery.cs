using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;

namespace OSA.Application.Queries
{
    public class GetBatchByNameQuery:IRequest<BaseResponseList<BatchResponse>>
    {
        public string Name { get; set; }

        public GetBatchByNameQuery(string name)
        {
            Name = name;
        }
    }
}
