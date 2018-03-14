using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ServiceWithMongo.Model;

namespace ServiceWithMongo.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(IOptions<PersonSettings> settings)
        {
            _context = new PersonContext(settings);
        }

        public async Task AddAsync(Person person)
        {
            await _context.People.InsertOneAsync(person);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.People.Find(Builders<Person>.Filter.Empty).ToListAsync();
        }
    }
}
