﻿using System;
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
  public class GetGuardianByContactHandler : IRequestHandler<GetGuardianByContactQuery, BaseResponse<GuardianResponse>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGuardianByContactHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<BaseResponse<GuardianResponse>> Handle(GetGuardianByContactQuery request, CancellationToken cancellationToken)
    {
      var guardian = await _unitOfWork.Guardians.Get(g => g.Contact == request.Contact);
      if (guardian == null)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Sorry no record found",
          Result = null
        };
      }

      var response = _mapper.Map<GuardianResponse>(guardian);
      return new BaseResponse<GuardianResponse>()
      {
        IsSuccess = true,
        Message = "Records retrieve successfully",
        Result = response
      };
    }
  }
}
