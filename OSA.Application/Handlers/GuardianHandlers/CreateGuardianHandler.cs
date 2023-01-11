using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OSA.Application.Commands.GuardianCommands;
using OSA.Application.Response;
using OSA.Domain.Entities;
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.GuardianHandlers
{
  public class CreateGuardianHandler : IRequestHandler<CreateGuardianCommand, BaseResponse<GuardianResponse>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGuardianHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<BaseResponse<GuardianResponse>> Handle(CreateGuardianCommand request, CancellationToken cancellationToken)
    {
      
      if (await _unitOfWork.Guardians.Exists(g => g.Contact == request.Contact))
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Sorry Guardian already Exist"
        };
      }

      
      var guardianEntity = _mapper.Map<Guardian>(request);
      if (guardianEntity == null)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Sorry Guardian is null"
        };
      }

      var guardianResponse = _mapper.Map<GuardianResponse>(guardianEntity);
      await _unitOfWork.Guardians.Insert(guardianEntity);
      return new BaseResponse<GuardianResponse>()
      {
        IsSuccess = true,
        Message = "Student Created Successfully",
        Result = guardianResponse
      };

    }
  }
}
