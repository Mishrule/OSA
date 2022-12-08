using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OSA.Application.Commands.StudentCommands;
using OSA.Application.Response;
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.StudentHandlers
{
    public class DeleteStudentHandler: IRequestHandler<DeleteStudentCommand, BaseResponse<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if ( _unitOfWork.Students == null)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Invalid Request"
                };
            }

            var student = await _unitOfWork.Students.Get(s => s.Id == request.Id);
            if (student == null)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Request not found"
                };
            }

            await _unitOfWork.Students.Delete(request.Id);
            return new BaseResponse<StudentResponse>()
            {
                IsSuccess = true,
                Message = "Student Deleted Successfully"
            };
        }
    }
}
