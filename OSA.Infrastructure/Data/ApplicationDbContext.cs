using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OSA.Domain.Entities;
using OSA.Domain.EntityConfigurations;

namespace OSA.Infrastructure.Data
{
	public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{
				
		}
		public DbSet<Batch> Batches { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(typeof(BatchConfiguration).Assembly);
			builder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
			base.OnModelCreating(builder);
		}
	}
}
