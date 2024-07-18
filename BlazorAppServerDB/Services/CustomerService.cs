using BlazorAppServerDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace BlazorAppServerDB.Services
{
    public class CustomerService
    {
        private PersonContext dbContext;

        public CustomerService(PersonContext context)
        {
            dbContext = context;
        }
        public async Task<List<Person>> GetPersonsAsync()
        {
            var persons = await dbContext.Persons.ToListAsync();
            // Add the country to the person
            foreach (var person in persons)
			{
				if (person.CountryID != null)
				{
					person.Country = await dbContext.Countries.FirstOrDefaultAsync(c => c.CountryID == person.CountryID);
				}
			}
            return persons;
        }

        public async Task<Person> GetPersonAsync(int personID)
		{
			return await dbContext.Persons.FirstOrDefaultAsync(p => p.ID == personID);
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
