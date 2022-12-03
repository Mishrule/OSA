using MediatR;
using OSA.Application.Commands;
using OSA.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OSA.Domain.Entities;
using OSA.Domain.Repositories;
using OSA.Infrastructure.Data;

namespace OSA.Application.Handlers.BatchHandlers
{
    public class UpdateBatchHandler : IRequestHandler<UpdateBatchCommand, BatchResponse>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;
        protected readonly ApplicationDbContext _dbContext;

        public UpdateBatchHandler(IBatchRepository batchRepository, IMapper mapper, ApplicationDbContext dbContext)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<BatchResponse> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {
            //var batchData = await _dbContext.Batches.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
             var batchEntity =  _mapper.Map<Batch>(request);
           // batchData =  _mapper.Map<Batch>(request);
            if (batchEntity == null)
            {
                throw new ApplicationException("Entity could not be mapped");
            }
            //batchEntity.CreatedBy = batchData.CreatedBy;
            //batchEntity.CreatedDate = batchData.CreatedDate;

            var batch = _batchRepository.UpdateAsync(batchEntity);
            if (batch.IsCompleted)
            {
                var batchResponse = _mapper.Map<BatchResponse>(batchEntity);
                return batchResponse;
            }
            
            return new BatchResponse();
        }
    }
}
