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
    public class UpdatStudentHandler:IRequestHandler<UpdateStudentCommand, BaseResponse<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Request cannot be null"
                };
            }

            var student = await _unitOfWork.Students.Get(s => s.Id == request.Id);
            if (student == null)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Student not found"
                };
            }

            var studentMapped = _mapper.Map(request, student);
            _unitOfWork.Students.Update(studentMapped);

            var response = _mapper.Map<StudentResponse>(studentMapped);
            return new BaseResponse<StudentResponse>()
            {
                IsSuccess = false,
                Message = "Student updated successfully",
                Result = response
            };
        }
    }
}
