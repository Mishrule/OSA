﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Entities.Base.Interfaces;
using OSA.Infrastructure.Core.Enums;

namespace OSA.Domain.Entities.Base
{
	public class AuditBase: IAuditBase
	{
		public State State { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}