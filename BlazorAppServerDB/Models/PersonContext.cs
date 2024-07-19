using Microsoft.EntityFrameworkCore;

namespace BlazorAppServerDB.Models
{
	// This represents the database context that communicates with the SQLite database.
	public class CustomersContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public CustomersContext(DbContextOptions<CustomersContext> options, IConfiguration configuration) : base(options)
		{
			Configuration = configuration;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(Configuration.GetConnectionString("CustomersDB"));
		}
		public DbSet<Person> Persons { get; set; }
		public DbSet<Country> Countries { get; set; }
	}
}
