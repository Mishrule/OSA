using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSA.Application.Commands.StudentCommands;
using OSA.Application.Queries.StudentQueries;
using OSA.Application.Response;
using OSA.Domain.Repositories.Base;

namespace OSA.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetStudents")]
        [ProducesResponseType(typeof(IEnumerable<BaseResponse<StudentResponse>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseList<StudentResponse>>> GetStudents()
        {
            var query = new GetAllStudentsQuery();
            var students = await _mediator.Send(query);
            if (!students.IsSuccess)
            {
                return new BaseResponseList<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry no student records found"
                };
               // return NotFound();
            }

            return Ok(students);
        }

        [HttpGet("GetStudents/{studentname}")]
        [ProducesResponseType(typeof(BaseResponse<StudentResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> GetStudentByName(string studentname)
        {
            var query = new GetStudentByFullNameQuery(studentname);
            var student = await _mediator.Send(query);
            if (!student.IsSuccess)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry no student records found"
                };
            }
            return Ok(student);
        }

        [HttpGet("GetStudentClass/{className}")]
        [ProducesResponseType(typeof(BaseResponseList<StudentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseList<StudentResponse>>> GetStudentClass(string className)
        {
            var query = new GetStudentByClassQuery(className);
            var student = await _mediator.Send(query);
            if (!student.IsSuccess)
            {
                return new BaseResponseList<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry no student records found"
                };
            }
            return Ok(student);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<StudentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> GetStudentById(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var student = await _mediator.Send(query);
            if (!student.IsSuccess)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry no student records found"
                };
            }
            return Ok(student);
        }

        [HttpGet("studentNumber/{studentNumber}")]
        [ProducesResponseType(typeof(BaseResponse<StudentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> GetStudentByStudentNumber(string studentNumber)
        {
            var query = new GetStudentByStudentNumberQuery(studentNumber);
            var student = await _mediator.Send(query);
            if (!student.IsSuccess)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = "Sorry no student records found"
                };
            }
            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(typeof(StudentResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> CreateStudent(
            [FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            var isSuccess = await _unitOfWork.Save(HttpContext);
            if (!isSuccess)
            {
                return new BaseResponse<StudentResponse>
                {
                    IsSuccess = false,
                    Message = "Failed to create Student"
                };
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(StudentResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> DeleteStudent(int id, [FromBody]DeleteStudentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            var isSuccess = await _unitOfWork.Save(HttpContext);
            if (!isSuccess)
            {
                return new BaseResponse<StudentResponse>
                {
                    IsSuccess = false,
                    Message = "Failed to Delete Student"
                };
            }
            return Ok(result);
        }
    }
}
