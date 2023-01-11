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
  public class DeleteGuardianHandler:IRequestHandler<DeleteGuardianCommand, BaseResponse<GuardianResponse>>
  {
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGuardianHandler(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<GuardianResponse>> Handle(DeleteGuardianCommand request, CancellationToken cancellationToken)
    {
      if (_unitOfWork.Guardians == null)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Invalid Request - Guardian database don't exit"
        };
      }

      var guardian = await _unitOfWork.Guardians.Get(g => g.Id == request.Id);
      if (guardian == null)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = "Request not found"
        };
      }

      await _unitOfWork.Guardians.Delete(request.Id);
      return new BaseResponse<GuardianResponse>()
      {
        IsSuccess = true,
        Message = "Student Deleted Successfully"
      };

      
    }
  }
}
