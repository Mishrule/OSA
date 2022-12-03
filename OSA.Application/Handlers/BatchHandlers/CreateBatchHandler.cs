using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OSA.Application.Commands;
using OSA.Application.Response;
using OSA.Domain.Entities;
using OSA.Domain.Repositories;

namespace OSA.Application.Handlers
{
    public class CreateBatchHandler : IRequestHandler<CreateBatchCommand, BatchResponse>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;
        public CreateBatchHandler(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }
        public async Task<BatchResponse> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            var batchEntity = _mapper.Map<Batch>(request);
            if (batchEntity == null)
            {
                throw new ApplicationException("Entity could not be mapped");
            }

            var batch = await _batchRepository.AddAsync(batchEntity);
            var batchResponse = _mapper.Map<BatchResponse>(batch);
            return batchResponse;
        }
    }
}
