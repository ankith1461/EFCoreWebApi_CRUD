using Microsoft.AspNetCore.Mvc;
using EFCoreWebApi_CRUD.Models;
using System.Linq;

namespace EFCoreWebApi_CRUD.Controllers {

    [Route("api/[controller]")]
    public class ActorsController : Controller {

        private EFCoreWebApi_CRUDDbContext dbContext;

        public ActorsController() {
            string connectionString = "server=localhost;port=3306;database=sakila;userid=root;pwd=admin;sslmode=none";
            dbContext = EFCoreWebApi_CRUDDbContextFactory.Create(connectionString);
        }

        // GET api/actors
        [HttpGet]
        public ActionResult Get() {
            return Ok(dbContext.Actor.ToArray());
        }

        // GET api/actors/101
        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            var actor = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (actor != null) {
                return Ok(actor);
            } else {
                return NotFound();
            }
        }

        // POST api/actors
        [HttpPost]
        public ActionResult Post([FromBody]Actor actor) {
            if (!ModelState.IsValid)
                return BadRequest();

            dbContext.Actor.Add(actor);
            dbContext.SaveChanges();
            return Created("api/actors", actor);
        }

        // PUT api/actors/101
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Actor actor) {
            var target = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (target != null && ModelState.IsValid) {
                dbContext.Entry(target).CurrentValues.SetValues(actor);
                dbContext.SaveChanges();
                return Ok();
            } else {
                return BadRequest();
            }
        }

        // DELETE api/actors/101
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            var actor = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (actor != null) {
                dbContext.Actor.Remove(actor);
                dbContext.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }
        }
    }
}