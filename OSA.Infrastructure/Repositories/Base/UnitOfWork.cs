using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OSA.Domain.Entities;
using OSA.Domain.Repositories.Base;
using OSA.Infrastructure.Data;

namespace OSA.Infrastructure.Repositories.Base
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
       private readonly UserManager<ApplicationUser> _userManager;
       private IRepository<Batch> _batches;
       private IRepository<Student> _students;
       private IRepository<Guardian> _guardians;

       public UnitOfWork(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
       {
           _userManager = userManager;
           _context = context;
       }

       public void Dispose()
        {
      _context.Dispose();
      GC.SuppressFinalize(this);
    }

        public async Task<bool> Save(HttpContext httpContext)
        {
      //var userId = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      //var user = await _userManager.FindByEmailAsync(userId);

      //var entries = _context.ChangeTracker.Entries()
      //    .Where(q => q.State == EntityState.Modified ||
      //                q.State == EntityState.Added);

      //foreach (var entry in entries)
      //{
      //    if (entry.State == EntityState.Modified)
      //    {
      //        ((EntityBase)entry.Entity).ModifiedDate = DateTime.Now;
      //        ((EntityBase)entry.Entity).ModifiedBy = user?.UserName;
      //    }
      //    else if (entry.State == EntityState.Added)
      //    {
      //        ((EntityBase)entry.Entity).CreatedDate = DateTime.Now;
      //        ((EntityBase)entry.Entity).CreatedBy = user?.UserName;
      //    }
      //}

      


      var changes = await _context.SaveChangesAsync();
      return changes > 0;
    }


        public IRepository<Batch> Batches => _batches ??= new Repository<Batch>(_context);
        public IRepository<Student> Students => _students ??= new Repository<Student>(_context);
        public IRepository<Guardian> Guardians => _guardians ??= new Repository<Guardian>(_context);
    }

   
}
