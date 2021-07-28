using System.Threading.Tasks;
using CQRSwithCDC.Logic.Core;
using Microsoft.EntityFrameworkCore;

namespace CQRSwithCDC.Logic.Infrastructure
{
	public class DataContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }

		public DataContext(DbContextOptions options) : base(options)
		{
			ChangeTracker.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Student>((x) =>
			{
				x.ToTable("Students").HasKey(s => s.Id);
				x.Property(s => s.Id).HasColumnName("Id");
				x.Property(s => s.Name).HasColumnName("Name");
				x.HasMany(s => s.Enrollments).WithOne(e => e.Student);
				x.HasMany(s => s.Disenrollments).WithOne(d => d.Student);
			});
			builder.Entity<Course>((x) =>
			{
				x.ToTable("Courses").HasKey(c => c.Id);
				x.Property(c => c.Id).HasColumnName("Id");
				x.Property(c => c.Name).HasColumnName("Name");
			});
			builder.Entity<Enrollment>((x) =>
			{
				x.ToTable("Enrollments").HasKey(e => e.Id);
				x.Property(e => e.Id).HasColumnName("Id");
				x.Property(e => e.Grade).HasColumnName("Grade");
				x.HasOne(e => e.Student).WithMany(s => s.Enrollments);
				x.HasOne(e => e.Course).WithMany();
			});
			builder.Entity<Disenrollment>((x) =>
			{
				x.ToTable("Disenrollments").HasKey(d => d.Id);
				x.Property(d => d.Id).HasColumnName("Id");
				x.Property(d => d.DateTime).HasColumnName("DateTime");
				x.Property(d => d.Comment).HasColumnName("Comment");
				x.HasOne(d => d.Student).WithMany(s => s.Disenrollments);
				x.HasOne(d => d.Course).WithMany();
			});
		}

		public async Task<bool> SaveAllAsync()
		{
			return await SaveChangesAsync() > 0;
		}

	}
}
