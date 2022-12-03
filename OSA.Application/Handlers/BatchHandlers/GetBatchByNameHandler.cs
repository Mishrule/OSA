using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OSA.Application.Queries;
using OSA.Application.Response;
using OSA.Domain.Repositories;

namespace OSA.Application.Handlers
{
    public class GetBatchByNameHandler : IRequestHandler<GetBatchByNameQuery, IEnumerable<BatchResponse>>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public GetBatchByNameHandler(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BatchResponse>> Handle(GetBatchByNameQuery request, CancellationToken cancellationToken)
        {
            var batchList = await _batchRepository.GetAsync(b=>b.Name == request.Name);
            var response = _mapper.Map<IEnumerable<BatchResponse>>(batchList);
            return response;
        }
    }
}
