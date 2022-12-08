using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using OSA.Application.Commands.BatchCommands;
using OSA.Application.Response;
using OSA.Domain.Entities;
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers
{
    public class CreateBatchHandler : IRequestHandler<CreateBatchCommand, BaseResponse<BatchResponse>>
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateBatchHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<BatchResponse>> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Batches.Exists(b => b.Name == request.Name))
            {
               
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Batch Name already Exist"

                };
            }
            var batchEntity =_mapper.Map<Batch>(request);
            if (batchEntity == null)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Batch is Null"

                };
            }
            var batchResponse = _mapper.Map<BatchResponse>(batchEntity);
             await _unitOfWork.Batches.Insert(batchEntity);
             return new BaseResponse<BatchResponse>()
             {
                 IsSuccess = true,
                 Message = "Batch Created Successfully",
                 Result = batchResponse
             };
        }
    }
}
