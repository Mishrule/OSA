using MediatR;
using OSA.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Application.Queries.StudentQueries
{
    public class GetStudentByStudentNumberQuery :  IRequest<BaseResponse<StudentResponse>>
    {
        public string StudentNumber { get; set; }
        public GetStudentByStudentNumberQuery(string studentNumber)
        {
            StudentNumber = studentNumber;
        }
    }
}
