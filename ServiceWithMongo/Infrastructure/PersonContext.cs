using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ServiceWithMongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceWithMongo.Infrastructure
{
    public class PersonContext
    {
        private readonly IMongoDatabase _database = null;

        public PersonContext(IOptions<PersonSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Person> People
        {
            get
            {
                return _database.GetCollection<Person>("Person");
            }
        }
    }
}
