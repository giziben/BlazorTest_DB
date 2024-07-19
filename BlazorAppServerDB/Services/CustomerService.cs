using BlazorAppServerDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace BlazorAppServerDB.Services
{
    public class CustomerService
    {
        private CustomersContext? dbContext;

        public CustomerService(CustomersContext context)
        {
            dbContext = context;
        }
        public async Task<List<Person>> GetPersonsAsync()
        {
            // Include the related country entity
            var persons = await dbContext.Persons.Include(x=>x.Country).ToListAsync();
            return persons;
        }

        public async Task<Person> GetPersonAsync(int personID)
		{
			return await dbContext.Persons.Include(x => x.Country).FirstOrDefaultAsync(p => p.ID == personID);
		}
        public async Task<Person> AddPersonAsync(Person person)
        {
            try
            {
                dbContext.Persons.Add(person);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
        public async Task<Person> UpdatePersonAsync(Person person)
        {
            try
            {
                var productExist = dbContext.Persons.FirstOrDefault(p => p.ID == person.ID);
                if (productExist != null)
                {
                    dbContext.Update(person);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
        public async Task DeletePersonAsync(int personID)
        {
            try
            {
                var person = dbContext.Persons.FirstOrDefault(p => p.ID == personID);
                if (person != null)
                {
                    dbContext.Persons.Remove(person);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
		public async Task<List<Country>> GetAllCountries()
		{
			try
			{
				return await dbContext.Countries.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
