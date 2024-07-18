using Microsoft.EntityFrameworkCore;

namespace BlazorAppServerDB.Models
{
	public class PersonContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public PersonContext(DbContextOptions<PersonContext> options, IConfiguration configuration) : base(options)
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
