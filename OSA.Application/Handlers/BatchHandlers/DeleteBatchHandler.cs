using AutoMapper;
using MediatR;
using OSA.Application.Commands;
using OSA.Application.Response;
using OSA.Domain.Entities;
using OSA.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSA.Application.Handlers.BatchHandlers
{
    public class DeleteBatchHandler : IRequestHandler<DeleteBatchCommand, BatchResponse>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public DeleteBatchHandler(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        public async Task<BatchResponse> Handle(DeleteBatchCommand request, CancellationToken cancellationToken)
        {
            var batchEntity = _mapper.Map<Batch>(request);
            if (batchEntity == null)
            {
                throw new ApplicationException("Entity could not be mapped");
            }

            var batch = _batchRepository.DeleteAsync(batchEntity);
            var batchResponse = _mapper.Map<BatchResponse>(batch);
            return batchResponse; ;
        }
    }
}
