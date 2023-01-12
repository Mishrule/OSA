using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
          Message = $"Sorry no records found {e.Message}"
        };
      }
      
    }
  }
}
