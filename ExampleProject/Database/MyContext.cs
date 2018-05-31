using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Database
{
	public class MyContext : DbContext
	{
		public MyContext(DbContextOptions<MyContext> options) : base(options)
		{
			
		}

		public DbSet<ExampleModel> Examples { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ExampleModel>().HasKey(x => x.Id);
			builder.Entity<ExampleModel>()
				.Property(b => b.Id)
				.UseSqlServerIdentityColumn();

			builder.Entity<ExampleModel>().Property(x => x.Name).HasMaxLength(100);
		}

	}

	public class ExampleModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
	}
}