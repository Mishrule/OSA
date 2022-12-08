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
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers
{
    public class GetBatchByIdHandler: IRequestHandler<GetBatchByIdQuery, BaseResponse<BatchResponse>>
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBatchByIdHandler( IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<BatchResponse>> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            var batch = await _unitOfWork.Batches.Get(q=>q.Id == request.Id);
            var response = _mapper.Map<BatchResponse>(batch);
            return new BaseResponse<BatchResponse>()
            {
                IsSuccess = true,
                Message = "Batch Retrieved Successfully",
                Result = response
            };
        }
    }
}
