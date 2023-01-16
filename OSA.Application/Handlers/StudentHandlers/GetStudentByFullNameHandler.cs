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
    public class GetStudentByFullNameHandler : IRequestHandler<GetStudentByFullNameQuery, BaseResponse<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentByFullNameHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<StudentResponse>> Handle(GetStudentByFullNameQuery request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.Get(s => s.FullName == request.FullName, includes:new List<string>{"Batch","Guardian"});
            var response = _mapper.Map<StudentResponse>(student);
            return new BaseResponse<StudentResponse>()
            {
                IsSuccess = true,
                Message = "Student record retrieved successfully",
                Result = response
            };
        }
    }
}
