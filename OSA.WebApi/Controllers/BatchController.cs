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

namespace OSA.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BatchController> _logger;
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public BatchController(IMediator mediator, ILogger<BatchController> logger, IBatchRepository batchRepository, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        [HttpGet("GetBatches")]
        [ProducesResponseType(typeof(IEnumerable<BatchResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BatchResponse>>> GetBatches()
        {
            var query = new GetBatchesQuery();
            var batches = await _mediator.Send(query);
            //if (batches.Count() == decimal.Zero)
            //{
            //    return NotFound();
            //}

            return Ok(batches);
        }

        [HttpGet("GetBatchByName/{batchName}")]
        [ProducesResponseType(typeof(IEnumerable<BatchResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BatchResponse>>> GetBatchByName(string batchName)
        {
            var query = new GetBatchByNameQuery(batchName);
            var batch = await _mediator.Send(query);
            if (batch.Count() == decimal.Zero)
            {
                return NotFound();
            }
            return Ok(batch);
        }

        [HttpGet("GetBatchById/{id}")]
        [ProducesResponseType(typeof(BatchResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BatchResponse>> GetBatchById(int id)
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
        public async Task<ActionResult<BatchResponse>> CreateBatch([FromBody] CreateBatchCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BatchResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BatchResponse>> UpdateBatch([FromBody] UpdateBatchCommand command)
        { 
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BatchResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BatchResponse>> DeleteBatch([FromBody] DeleteBatchCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
