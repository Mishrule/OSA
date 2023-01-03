using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;
using OSA.Models.Core.Enums;

namespace OSA.Application.Commands.GuardianCommands
{
	public class UpdateGuardianCommand:IRequest<BaseResponse<GuardianResponse>>
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string Surname { get; set; }
		public string FullName => FirstName + MiddleName + Surname;
		public string Contact { get; set; }
		public string Relationship { get; set; }
		public string Email { get; set; }
		public PartyType PartyType { get; set; }
		public int StudentId { get; set; }
		public State State { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}
