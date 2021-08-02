using System.Threading.Tasks;
using CQRSwithCDC.Read.Core;
using Microsoft.EntityFrameworkCore;

namespace CQRSwithCDC.Read.Infrastructure
{
	public class DataContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }

		public DataContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Student>((x) =>
			{
				x.ToTable("Students").HasKey(s => s.Id);
			});
			builder.Entity<Course>((x) =>
			{
				x.ToTable("Courses").HasKey(c => c.Id);
			});
		}

		public async Task<bool> SaveAllAsync()
		{
			return await SaveChangesAsync() > 0;
		}
	}
}
