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
    public class GetBatchByIdHandler: IRequestHandler<GetBatchByIdQuery, BatchResponse>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public GetBatchByIdHandler(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        public async Task<BatchResponse> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            var batch = await _batchRepository.GetByIdAsync(request.Id);
            var response = _mapper.Map<BatchResponse>(batch);
            return response;
        }
    }
}
