using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Repositories;
using OSA.Domain.Repositories.Base;
using OSA.Infrastructure.Repositories;
using OSA.Infrastructure.Repositories.Base;

namespace OSA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            #region Repositories

            service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<IBatchRepository, BatchRepository>();
            

            #endregion

            return service;
        }
    }
}
