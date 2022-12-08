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
using OSA.Domain.Entities;
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.StudentHandlers
{
    public class CreateStudentHandler:IRequestHandler<CreateStudentCommand, BaseResponse<StudentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Students.Exists(s => s.StudentNumber == request.StudentNumber))
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry Student already Exist"
                };
            }

            var studentEntity = _mapper.Map<Student>(request);
            if (studentEntity == null)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry student is null"
                };
            }

            var studentResponse = _mapper.Map<StudentResponse>(studentEntity);
            await _unitOfWork.Students.Insert(studentEntity);
            return new BaseResponse<StudentResponse>()
            {
                IsSuccess = true,
                Message = "Student Created Successfully",
                Result = studentResponse
            };
        }
    }
}
