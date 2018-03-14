using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceWithMongo.Infrastructure.Repositories;
using ServiceWithMongo.Model;

namespace ServiceWithMongo.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<Person>))]
        public async Task<IActionResult> GetAll()
        {
            var ret = await _personRepository.GetAllAsync();
            return Ok(ret);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            await _personRepository.AddAsync(person);
            return Ok(person);
        }
    }
}