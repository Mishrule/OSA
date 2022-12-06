using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Entities;

namespace OSA.Domain.Repositories.Base
{
  public interface IUnitOfWork: IDisposable
  {
    Task<bool> Save(HttpContext httpContext);
    IRepository<Batch> Batches { get; }
  }
}
