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
    public class GetBatchByNameHandler : IRequestHandler<GetBatchByNameQuery, BaseResponseList<BatchResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBatchByNameHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseList<BatchResponse>> Handle(GetBatchByNameQuery request, CancellationToken cancellationToken)
        {
            var batchList = await _unitOfWork.Batches.GetAll(b=>b.Name == request.Name);
            var response = _mapper.Map<IEnumerable<BatchResponse>>(batchList);
            return new BaseResponseList<BatchResponse>()
            {
                IsSuccess = true,
                Message = "Batch names retrieved successful",
                Result = response
            };
        }
    }
}
