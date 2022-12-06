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
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.BatchHandlers
{
    public class UpdateBatchHandler : IRequestHandler<UpdateBatchCommand, BaseResponse<BatchResponse>>
    {
       // private readonly IBatchRepository _batchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected readonly ApplicationDbContext _dbContext;

        public UpdateBatchHandler( IMapper mapper, ApplicationDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<BatchResponse>> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Request cannot be null"
                };
            }

            var batch = await _unitOfWork.Batches.Get(b => b.Id == request.Id);
            if (batch == null)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Batch not found"
                };
            }

            var batchMapped = _mapper.Map(request,batch);
            _unitOfWork.Batches.Update(batchMapped);

            var response = _mapper.Map<BatchResponse>(batchMapped);
            return new BaseResponse<BatchResponse>()
            {
                IsSuccess = true,
                Message = "Batch Updated Successfully",
                Result = response
            };

           
        }
    }
}
