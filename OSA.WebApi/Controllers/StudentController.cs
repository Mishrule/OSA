using System;
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
            try
            {
                var students = await _mediator.Send(new GetAllStudentsQuery());
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
            catch (Exception e)
            {
                return new BaseResponseList<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpGet("GetStudents/{studentname}")]
        [ProducesResponseType(typeof(BaseResponse<StudentResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> GetStudentByName(string studentname)
        {
            try
            {
                var student = await _mediator.Send(new GetStudentByFullNameQuery(studentname));
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
            catch (Exception e)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpGet("GetStudentClass/{className}")]
        [ProducesResponseType(typeof(BaseResponseList<StudentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseList<StudentResponse>>> GetStudentClass(string className)
        {
            try
            {
                var student = await _mediator.Send(new GetStudentByClassQuery(className));
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
            catch (Exception e)
            {
                return new BaseResponseList<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<StudentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> GetStudentById(int id)
        {
            try
            {
                var student = await _mediator.Send(new GetStudentByIdQuery(id));
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
            catch (Exception e)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpGet("studentNumber/{studentNumber}")]
        [ProducesResponseType(typeof(BaseResponse<StudentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> GetStudentByStudentNumber(string studentNumber)
        {
            try
            {
                var student = await _mediator.Send(new GetStudentByStudentNumberQuery(studentNumber));
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
            catch (Exception e)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(StudentResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> CreateStudent([FromBody] CreateStudentCommand command)
        {
            try
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
            catch (Exception e)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(StudentResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<StudentResponse>>> DeleteStudent(int id, [FromBody]DeleteStudentCommand command)
        {
            try
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
            catch (Exception e)
            {
                return new BaseResponse<StudentResponse>()
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }
    }
}
