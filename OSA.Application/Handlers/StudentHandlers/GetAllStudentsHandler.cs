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
    public class GetAllStudentsHandler:IRequestHandler<GetAllStudentsQuery, BaseResponseList<StudentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStudentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseList<StudentResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _unitOfWork.Students.GetAll(includes:new List<string>{"Batch"});
            if (studentList.Count == 0 || studentList == null)
            {
                return new BaseResponseList<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry no student data found"
                };
            }
            var response = _mapper.Map<IEnumerable<StudentResponse>>(studentList);
            return new BaseResponseList<StudentResponse>()
            {
                IsSuccess = true,
                Message = "Students data retrieved successfully",
                Result = response
            };

        }
    }
}
