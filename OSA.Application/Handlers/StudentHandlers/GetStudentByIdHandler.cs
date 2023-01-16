using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OSA.Application.Queries.StudentQueries;
using OSA.Application.Response;
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.StudentHandlers
{
    public class GetStudentByIdHandler: IRequestHandler<GetStudentByIdQuery, BaseResponse<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.Get(s => s.Id == request.id, includes: new List<string> { "Batch", "Guardian" });
            if (student == null)
            {
                return new BaseResponse<StudentResponse>
                {
                    IsSuccess = false,
                    Message = "Sorry no student  record found"
                };
            }
            var response = _mapper.Map<StudentResponse>(student);
            return new BaseResponse<StudentResponse>
            {
                IsSuccess = true,
                Message = "Student records retrieved successfully",
                Result = response
            };
        }
    }
}
