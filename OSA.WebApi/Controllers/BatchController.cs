using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OSA.Application.Commands;
using OSA.Application.Handlers;
using OSA.Application.Queries;
using OSA.Application.Response;
using OSA.Domain.Repositories;
using OSA.Domain.Repositories.Base;

namespace OSA.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BatchController> _logger;
        private readonly IBatchRepository _batchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BatchController(IMediator mediator, ILogger<BatchController> logger, IBatchRepository batchRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _logger = logger;
            _batchRepository = batchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetBatches")]
        [ProducesResponseType(typeof(IEnumerable<BatchResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseList<BatchResponse>>> GetBatches()
        {
            var query = new GetBatchesQuery();
            var batches = await _mediator.Send(query);
            if (!batches.IsSuccess)
            {
                return NotFound();
            }

            return Ok(batches);
        }

        [HttpGet("GetBatchByName/{batchName}")]
        [ProducesResponseType(typeof(BaseResponseList<BatchResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseList<BatchResponse>>> GetBatchByName(string batchName)
        {
            var query = new GetBatchByNameQuery(batchName);
            var batch = await _mediator.Send(query);
            if (!batch.IsSuccess)
            {
                return NotFound();
            }
            return Ok(batch);
        }

        [HttpGet("GetBatchById/{id}")]
        [ProducesResponseType(typeof(BatchResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> GetBatchById(int id)
        {
            var query = new GetBatchByIdQuery(id);
            var batch = await _mediator.Send(query);
            if (batch == null)
            {
                return NotFound();
            }
            return Ok(batch);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BatchResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> CreateBatch([FromBody] CreateBatchCommand command)
        {
            var result = await _mediator.Send(command);
            var isSuccess = await _unitOfWork.Save(HttpContext);
            if (!isSuccess)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Failed to Create Batch"
                };
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BatchResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> UpdateBatch(int id, [FromBody] UpdateBatchCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            var isSuccess = await _unitOfWork.Save(HttpContext);
            if (!isSuccess)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Failed to Update Batch"
                };
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BatchResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> DeleteBatch(int id, [FromBody] DeleteBatchCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            var isSuccess = await _unitOfWork.Save(HttpContext);
            if (!isSuccess)
            {
                return new BaseResponse<BatchResponse>()
                {
                    IsSuccess = false,
                    Message = "Failed to Delete Batch"
                };
            }
            return Ok(result);
            
        }
    }
}
