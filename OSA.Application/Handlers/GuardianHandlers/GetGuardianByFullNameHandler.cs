using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OSA.Application.Queries.GuardianQueries;
using OSA.Application.Response;
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.GuardianHandlers
{
  public class GetGuardianByFullNameHandler:IRequestHandler<GetGuardianByFullNameQuery, BaseResponse<GuardianResponse>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGuardianByFullNameHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<BaseResponse<GuardianResponse>> Handle(GetGuardianByFullNameQuery request, CancellationToken cancellationToken)
    {
      var guardian = await _unitOfWork.Guardians.Get(g => g.FullName == request.FullName);
      if (guardian == null)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Sorry no record found",
          Result = null
        };
      }

      var response = _mapper.Map<BaseResponse<GuardianResponse>>(guardian);
      return response;
    }
  }
}
