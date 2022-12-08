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
    public class GetStudentByClassHandler : IRequestHandler<GetStudentByClassQuery, BaseResponseList<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentByClassHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<StudentResponse>> Handle(GetStudentByClassQuery request,
            CancellationToken cancellationToken)
        {
            var studentList = await _unitOfWork.Students.GetAll(s => s.StudentClass == request.StudentClass,
                orderBy: d => d.OrderByDescending(o => o.FullName), includes: new List<string> {"Batch"});
            var response = _mapper.Map<IEnumerable<StudentResponse>>(studentList);
            return new BaseResponseList<StudentResponse>
            {
                IsSuccess = true,
                Message = "Student Records Retrieved Successfully",
                Result = response
            };
        }
    }
}
