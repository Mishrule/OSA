using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Entities;
using OSA.Domain.Repositories;
using OSA.Infrastructure.Data;
using OSA.Infrastructure.Repositories.Base;

namespace OSA.Infrastructure.Repositories
{
	public class GuardianRepository : Repository<Guardian>, IGuardianRepository
	{
		public GuardianRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
