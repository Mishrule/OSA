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
    public class GetBatchesHandler: IRequestHandler<GetBatchesQuery, IEnumerable<BatchResponse>>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public GetBatchesHandler(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BatchResponse>> Handle(GetBatchesQuery request, CancellationToken cancellationToken)
        {
            var batchList = await _batchRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<BatchResponse>>(batchList);
            return response;
        }
    }
}
