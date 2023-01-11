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
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.GuardianHandlers
{
  public class UpdateGuardianHandler: IRequestHandler<UpdateGuardianCommand, BaseResponse<GuardianResponse>>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateGuardianHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<BaseResponse<GuardianResponse>> Handle(UpdateGuardianCommand request, CancellationToken cancellationToken)
    {
      if (request == null)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Request cannot be null"
        };
      }

      var guardian = await _unitOfWork.Guardians.Get(g => g.Id == request.Id);
      if (guardian == null)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Student not found"
        };
      }

      var guardianMapped = _mapper.Map(request, guardian);
      _unitOfWork.Guardians.Update(guardianMapped);

      var response = _mapper.Map<GuardianResponse>(guardianMapped);
      return new BaseResponse<GuardianResponse>()
      {
        IsSuccess = true,
        Message = "Guardian updated successfully",
        Result = response
      };

      
    }
  }
}
