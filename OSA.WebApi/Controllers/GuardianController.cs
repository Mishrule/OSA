using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OSA.Application.Commands.BatchCommands;
using OSA.Application.Commands.GuardianCommands;
using OSA.Application.Queries.GuardianQueries;
using OSA.Application.Response;
using OSA.Domain.Repositories.Base;

namespace OSA.WebApi.Controllers
{

  [Route("api/v1/[controller]")]
  [ApiController]
  public class GuardianController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ILogger<GuardianController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GuardianController(IMediator mediator, ILogger<GuardianController> logger, IUnitOfWork unitOfWork)
    {
      _mediator = mediator;
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet("GetGuardians")]
    [ProducesResponseType(typeof(IEnumerable<GuardianResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BaseResponseList<GuardianResponse>>> GetGuardians()
    {
      try
      {
        var guardians = await _mediator.Send(new GetAllGuardianQuery());
        if (!guardians.IsSuccess)
        {
          return new BaseResponseList<GuardianResponse>
          {
            IsSuccess = false,
            Message = "Sorry no records found"
          };
        }

        return Ok(guardians);
      }
      catch (Exception e)
      {
        return new BaseResponseList<GuardianResponse>
        {
          IsSuccess = false,
          Message = $"Error: {e.Message}"
        };
      }
      
    }

    [HttpGet("GetGuardianByContact/{contact}")]
    [ProducesResponseType(typeof(BaseResponse<GuardianResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BaseResponse<GuardianResponse>>> GetGuardianByContact(string contact)
    {
      try
      {
        var guardian = await _mediator.Send(new GetGuardianByContactQuery(contact));
        if (!guardian.IsSuccess)
        {
          return new BaseResponse<GuardianResponse>
          {
            IsSuccess = false,
            Message = $"Sorry no contact of {contact} was found"
          };
        }

        return Ok(guardian);
      }
      catch (Exception e)
      {
        return new BaseResponse<GuardianResponse>
        {
          IsSuccess = false,
          Message = $"Error: {e.Message}"
        };
      }
    }

    [HttpGet("GetGuardianByFullName/{fullName}")]
    [ProducesResponseType(typeof(BaseResponse<GuardianResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BaseResponse<GuardianResponse>>> GetGuardianByFullName(string fullName)
    {
      try
      {
        var guardian = await _mediator.Send(new GetGuardianByFullNameQuery(fullName));
        if (!guardian.IsSuccess)
        {
          return guardian;
        }

        return Ok(guardian);
      }
      catch (Exception e)
      {
        return new BaseResponse<GuardianResponse>
        {
          IsSuccess = false,
          Message = $"Error: {e.Message}"
        };
      }
    }

    [HttpGet("GetGuardianById/{id}")]
    [ProducesResponseType(typeof(BaseResponse<GuardianResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BaseResponse<GuardianResponse>>> GetGuardianById(int id)
    {
      try
      {
        var guardian = await _mediator.Send(new GetGuardianByIdQuery(id));
        if (!guardian.IsSuccess)
        {
          return guardian;
        }

        return Ok(guardian);
      }
      catch (Exception e)
      {
        return new BaseResponse<GuardianResponse>
        {
          IsSuccess = false,
          Message = $"Error: {e.Message}"
        };
      }
    }

    [HttpPost]
    [ProducesResponseType(typeof(GuardianResponse), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<BaseResponse<GuardianResponse>>> CreateGuardian(
      [FromBody] CreateGuardianCommand command)
    {
      try
      {
        var result = await _mediator.Send(command);
        if (!await _unitOfWork.Save(HttpContext))
        {
          return result;
        }
        return Ok(result);
      }
      catch (Exception e)
      {
        return new BaseResponse<GuardianResponse>()
        {
          IsSuccess = false,
          Message = $"Error: {e.Message}"
        };
      }
    }

    

  }
}
