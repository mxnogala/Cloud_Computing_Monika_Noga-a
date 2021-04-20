using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleStorageApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleStorageApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DatabaseContext db;
        public PeopleController(DatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = db.PeopleMobile.ToList();
            return Ok(people);
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            db.PeopleMobile.Add(person);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}/photo")]
        public IActionResult GetPhoto([FromRoute] int id)
        {
            var p = db.PeopleMobile.First(w => w.Id == id);
            return base.File(Convert.FromBase64String(p.PictureBase64), "image/jpeg");
        }
    }
}
