using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleWebApp.Models;
using PeopleWebApp.Context;

namespace PeopleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly AzureDbContext db;
        public PeopleController(AzureDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var people = db.People.ToList();
            return Ok(people);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var person = db.People.First(findPerson => findPerson.PersonId == id);
            if (person == null)
            {
                return BadRequest();
            }
            else
            {

                return Ok(person);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Person updatePerson)
        {

            var person = db.People.First(findPerson => findPerson.PersonId == id);
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                string name = updatePerson.FirstName;
                string lastname = updatePerson.LastName;

                if (name != null)
                {
                    person.FirstName = name;
                }

                if (lastname != null)
                {
                    person.LastName = lastname;
                }
                db.SaveChanges();
                return Ok(person);
            }
        }

        [HttpPost]
        public IActionResult Post(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                db.People.Add(person);
                db.SaveChanges();
                return Ok(person);
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var person = db.People.First(findPerson => findPerson.PersonId == id);
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                db.People.Remove(person);
                db.SaveChanges();
                return Ok(person); 
            }

        }

    }

}
