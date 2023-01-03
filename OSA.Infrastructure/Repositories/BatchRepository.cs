using OSA.Domain.Entities;
using OSA.Domain.Repositories;
using OSA.Infrastructure.Data;
using OSA.Infrastructure.Repositories.Base;

namespace OSA.Infrastructure.Repositories
{
  public class BatchRepository: Repository<Batch>, IBatchRepository
    {
        public BatchRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
