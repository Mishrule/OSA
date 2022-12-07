using AutoMapper;
using MediatR;
using OSA.Application.Commands;
using OSA.Application.Response;
using OSA.Domain.Entities;
using OSA.Domain.Repositories;
using OSA.Domain.Repositories.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSA.Application.Handlers.BatchHandlers
{
    public class DeleteBatchHandler : IRequestHandler<DeleteBatchCommand, BaseResponse<BatchResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBatchHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<BatchResponse>> Handle(DeleteBatchCommand request, CancellationToken cancellationToken)
        {
            if (_unitOfWork.Batches == null)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Invalid Request"
                };
            }

            var batch = await _unitOfWork.Batches.Get(b => b.Id == request.Id);
            if (batch == null)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Request not found"
                };
            }

            await _unitOfWork.Batches.Delete(request.Id);
            return new BaseResponse<BatchResponse>()
            {
                IsSuccess = true,
                Message = "Batch Deleted Successfully"
            };

            
        }
    }
}
