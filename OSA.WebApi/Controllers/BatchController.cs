using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OSA.Application.Commands.BatchCommands;
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
        private readonly IUnitOfWork _unitOfWork;

        public BatchController(IMediator mediator, ILogger<BatchController> logger,  IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetBatches")]
        [ProducesResponseType(typeof(IEnumerable<BatchResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseList<BatchResponse>>> GetBatches()
        {
            try
            {
                var batches = await _mediator.Send(new GetBatchesQuery());
                if (!batches.IsSuccess)
                {
                    return batches;
                }

                return Ok(batches);
            }
            catch (Exception e)
            {
                return new BaseResponseList<BatchResponse>
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpGet("GetBatchByName/{batchName}")]
        [ProducesResponseType(typeof(BaseResponseList<BatchResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseList<BatchResponse>>> GetBatchByName(string batchName)
        {
            try
            {
                var batch = await _mediator.Send(new GetBatchByNameQuery(batchName));
                if (!batch.IsSuccess)
                {
                    return batch;
                }

                return Ok(batch);
            }
            catch (Exception e)
            {
                return new BaseResponseList<BatchResponse>
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpGet("GetBatchById/{id}")]
        [ProducesResponseType(typeof(BatchResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> GetBatchById(int id)
        {
            try
            {
                var batch = await _mediator.Send(new GetBatchByIdQuery(id));
                if (!batch.IsSuccess)
                {
                    return batch;
                }

                return Ok(batch);
            }
            catch (Exception e)
            {
                return new BaseResponse<BatchResponse>
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(BatchResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> CreateBatch([FromBody] CreateBatchCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                var isSuccess = await _unitOfWork.Save(HttpContext);
                if (!isSuccess)
                {
                    return result;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<BatchResponse>
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BatchResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> UpdateBatch(int id, [FromBody] UpdateBatchCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return new BaseResponse<BatchResponse>()
                    {
                        IsSuccess = false,
                        Message = $"Error: {id} is not valid"
                    };
                }

                var result = await _mediator.Send(command);
                var isSuccess = await _unitOfWork.Save(HttpContext);
                if (!isSuccess)
                {
                    return result;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<BatchResponse>
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BatchResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponse<BatchResponse>>> DeleteBatch(int id, [FromBody] DeleteBatchCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return new BaseResponse<BatchResponse>()
                    {
                        IsSuccess = false,
                        Message = $"Error: {id} is not valid"
                    };
                }

                var result = await _mediator.Send(command);
                var isSuccess = await _unitOfWork.Save(HttpContext);
                if (!isSuccess)
                {
                    return result;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<BatchResponse>
                {
                    IsSuccess = false,
                    Message = $"Error: {e.Message}"
                };
            }
            
            
        }
    }
}
