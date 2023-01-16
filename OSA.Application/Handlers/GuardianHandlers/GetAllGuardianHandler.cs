using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OSA.Application.Queries.GuardianQueries;
using OSA.Application.Response;
using OSA.Domain.Repositories.Base;

namespace OSA.Application.Handlers.GuardianHandlers
{
	public class GetAllGuardianHandler:IRequestHandler<GetAllGuardianQuery, BaseResponseList<GuardianResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllGuardianHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}


		public async Task<BaseResponseList<GuardianResponse>> Handle(GetAllGuardianQuery request, CancellationToken cancellationToken)
		{
			var guardianList = await _unitOfWork.Guardians.GetAll(includes: new List<string> { "Student" }); 
			if (guardianList.Count == 0 || guardianList == null)
			{
				return new BaseResponseList<GuardianResponse>()
				{
					IsSuccess = false,
					Message = "Sorry no guardian data found"
				};
			}
			var response = _mapper.Map<IEnumerable<GuardianResponse>>(guardianList);
			return new BaseResponseList<GuardianResponse>
			{
				IsSuccess = true,
				Message = "Success",
				Result = response
			};
		}
	}
}
