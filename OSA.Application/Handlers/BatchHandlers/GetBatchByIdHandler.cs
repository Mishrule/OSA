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
    public class GetBatchByIdHandler: IRequestHandler<GetBatchByIdQuery, BaseResponse<BatchResponse>>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public GetBatchByIdHandler(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BatchResponse>> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            var batch = await _batchRepository.Get(q=>q.Id == request.Id);
            var response = _mapper.Map<BatchResponse>(batch);
            return new BaseResponse<BatchResponse>()
            {
                IsSuccess = true,
                Message = "Item Retrieved Successfully",
                Result = response
            };
        }
    }
}
