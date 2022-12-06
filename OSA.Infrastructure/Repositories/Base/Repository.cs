using OSA.Domain.Entities.Base;
using OSA.Domain.Repositories.Base;
using OSA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OSA.Domain.Entities;

namespace OSA.Infrastructure.Repositories.Base
{

  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public Repository(ApplicationDbContext context)
    {
      _context = context;
      _db = context.Set<T>();
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
    {
      IQueryable<T> query = _db;
      if (expression != null)
      {
        query = query.Where(expression);
      }

      if (includes != null)
      {
        foreach (var include in includes)
        {
          query = query.Include(include);
        }
      }

      if (orderBy != null)
      {
        query = orderBy(query);
      }

      return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
    {
      IQueryable<T> query = _db;
      if (includes != null)
      {
        foreach (var prop in includes)
        {
          query = query.Include(prop);
        }
      }

      return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task Insert(T entity)
    {
      await _db.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T> entities)
    {
      await _db.AddRangeAsync(entities);
      
    }

    public async Task Delete(int id)
    {
      var record = await _db.FindAsync(id);
      _db.Remove(record);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
      _db.RemoveRange(entities);
    }

    public void Update(T entity)
    {
      _db.Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<bool> Exists(Expression<Func<T, bool>> expression)
    {
      return await _db.AnyAsync(expression);
    }

  }
}
