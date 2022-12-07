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
    public class GetBatchesHandler: IRequestHandler<GetBatchesQuery, BaseResponseList<BatchResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBatchesHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseList<BatchResponse>> Handle(GetBatchesQuery request, CancellationToken cancellationToken)
        {
            var batchList = await _unitOfWork.Batches.GetAll();
            var response = _mapper.Map<IEnumerable<BatchResponse>>(batchList);
            //return response;
            return new BaseResponseList<BatchResponse>()
            {
               
                Message = "Success",
                IsSuccess = true,
                Result = response
            };
        }
    }
}
